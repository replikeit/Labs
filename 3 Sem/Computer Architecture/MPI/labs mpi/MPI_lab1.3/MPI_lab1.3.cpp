#include <mpi.h>
#include <iostream>
#include "Process.h"
#include <ctime>
#include <iomanip>

using namespace std;

bool check = false;

void max(int& a, int& b)
{
	if (b > a)
	{
		int x = a;
		a = b;
		b = x;
		check = true;
	}
}

void outVec(float** mat, int l, int m)
{
	cout.precision(4);
	if (check)
	{
		for (int i = 0; i < m;i++)
		{
			for (int j = 0; j < l;j++)
			{
				std::cout << setw(8) << mat[j][i];
			}
			std::cout << std::endl;
		}
		std::cout << std::endl;
		return;
	}
	for (int i = 0; i < l;i++)
	{
		for (int j = 0; j < m;j++)
		{
			std::cout << setw(8) << mat[i][j];
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;
}

void fillMatrix(float** mat, int l, int m)
{
	for (int i = 0; i < l;i++)
	{
		for (int j = 0; j < m;j++)
		{
			mat[i][j] = float(((rand() % 200) - 100))/100;
		}
	}
}


class Program
{
public:
	static void Main()
	{
		float** vec1 = nullptr;
		float** vec2 = nullptr;
		float** vecR = nullptr;

		auto process = MPI::Process();

		int mainSliceSize = 1;
		int sliceSize = 1;

		int k = 0;
		int l = 0;
		int m = 0;

		unsigned int start_time = 0;

		if (process.IsMaster())
		{
			std::cout << "Input K: ";
			std::cin >> k;
			std::cout << "Input L: ";
			std::cin >> l;
			std::cout << "Input M: ";
			std::cin >> m;
			
			if (m > process.GetProcessCount())
			{
				sliceSize = m / process.GetProcessCount();
				mainSliceSize = m % process.GetProcessCount();
			}				
			vec1 = new float* [k];
			vec2 = new float* [l];
			vecR = new float* [k];
			for (int i = 0;i < k;i++)  
			{
				vec1[i] = new float[l];
				vecR[i] = new float[m];
			}
			for (int i = 0;i < l;i++)
			{
				vec2[i] = new float[m];
			}
			fillMatrix(vec1, k, l);
			fillMatrix(vec2, l, m);
			outVec(vec1, k, l);
			outVec(vec2, l, m);
			start_time = clock();
		}

		MPI_Bcast(&sliceSize, 1, MPI_INT, MPI::MasterRank, MPI_COMM_WORLD);
		MPI_Bcast(&l, 1, MPI_INT, MPI::MasterRank, MPI_COMM_WORLD);
		MPI_Bcast(&k, 1, MPI_INT, MPI::MasterRank, MPI_COMM_WORLD);

		if (!process.IsMaster())
		{
			vec1 = new float* [k];
			for (int i = 0; i < k; i++)
			{
				vec1[i] = new float[l];
			}
			vec2 = new float* [l];
			vecR = new float* [k];
		}

		for (int i = 0; i < k; i++)
		{
			MPI_Bcast(vec1[i], l, MPI_FLOAT, MPI::MasterRank, MPI_COMM_WORLD);
		}

		float* slice1 = new float[sliceSize];
		float* slice2 = new float[sliceSize];

		for (int i = 0;i < k;i++)
		{
			float* tmpVec = new float[sliceSize];
			nullFillVec(tmpVec, sliceSize);
			for (int j = 0; j < l;j++)
			 
				Scatter(vec2[j], slice2, sliceSize);
				ChangeData(vec1[i], tmpVec ,slice2, sliceSize, j);
			}
			Gather(vecR[i], tmpVec, sliceSize);
		}

		if (process.IsMaster())
		{
			for (int i = 0;i < k;i++)
			{
				for (int j = m - mainSliceSize;j < m;j++)
				{
					vecR[i][j] = 0;
					for (int k = 0;k < l; k++)
					{
						vecR[i][j] += vec1[i][k] * vec2[k][j];
					}
				}
			}

			unsigned int end_end = clock();


			outVec(vecR, k, m);

			std::cout << std::endl;
			std::cout << std::endl;
			
			cout << "work time: " << end_end - start_time;

		}



	}

private:

	static void nullFillVec(float* vec, int len)
	{
		for (int i = 0;i < len;i++)
			vec[i] = 0;
	}
	
	static void Scatter(float* data, float* slice, int sliceSize)
	{
		MPI_Scatter(		   // 1: Разрезает массив на равные куски и пересылает каждому процессу свой кусок:
			data, 			   // Исходный массив (для мастер-процесса), для остальных процессов не используется.
			sliceSize, 		   // Размер куска (для мастер-процесса), для остальных процессов не используется.
			MPI_FLOAT, 	   // Тип данных (для мастер-процесса), для остальных процессов не используется.
			slice, 		       // Массив, куда будет записываться кусок.
			sliceSize, 		   // Размер куска.
			MPI_FLOAT, 	   // Тип данных.
			MPI::MasterRank,   // Ранг раздающего процесса.
			MPI_COMM_WORLD);   // Рабочая группа.
	}

	static void ChangeData(float* mat,float* tmpVec, float* data2, int length, int index)
	{
		for (int i = 0;i < length;i++)
		{
			tmpVec[i] += mat[index]*data2[i];
		}
	}

	static void Gather(float* data, float* slice, int sliceSize)
	{
		MPI_Gather(            // 3. Собираем куски в главном процессе:
			slice, 		       // Кусок.
			sliceSize, 		   // Размер куска.
			MPI_FLOAT, 	   // Тип данных.
			data, 			   // Массив, в который будут склеиваться куски (для мастер-процесса), для остальных процессов не используется.
			sliceSize, 		   // Размер куска (для мастер-процесса), для остальных процессов не используется.
			MPI_FLOAT, 	   // Тип данных (для мастер-процесса), для остальных процессов не используется.
			MPI::MasterRank,   // Ранг собирающего процесса.
			MPI_COMM_WORLD);   // Рабочая группа.
	}
};



int main()
{
	srand(time(0));
	Program::Main();
	return 0;
}