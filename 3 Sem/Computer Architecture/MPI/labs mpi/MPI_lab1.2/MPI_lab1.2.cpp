#include <mpi.h>
#include <iostream>
#include "Process.h"
#include <ctime>
#include <iomanip>

using namespace std;

bool check = false;

void max(int &a,int &b)
{
	if (b>a)
	{
		int x = a;
		a = b;
		b = x;
		check = true;
	}
}

void outVec(int** mat, int l,int m)
{
	if(check)
	{
		for (int i = 0; i < m;i++)
		{
			for (int j = 0; j < l;j++)
			{
				std::cout << setw(3) << mat[j][i];
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
			std::cout << setw(3) << mat[i][j];
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;
}

void fillMatrix(int** mat, int l, int m)
{
	for (int i = 0; i < l;i++)
	{
		for (int j = 0; j < m;j++)
		{
			mat[i][j] = rand()%10 - 5;
		}
	}
}


class Program
{
public:
	static void Main()
	{
		int** vec1 = nullptr;
		int** vec2 = nullptr;
		int** vecR = nullptr;
		auto process = MPI::Process();
		int mainSliceSize = 1;
		int sliceSize = 1;
		int l = 0;
		int m = 0;
		if (process.IsMaster())
		{
			std::cout << "Input L: ";
			std::cin >> l;
			std::cout << "Input M: ";
			std::cin >> m;
			max(m, l);
			if (m > process.GetProcessCount())
			{
				sliceSize = m / process.GetProcessCount();
				mainSliceSize = m % process.GetProcessCount();
			}
			vec1 = new int* [l];
			vec2 = new int* [l];
			vecR = new int* [l];
			for (int i = 0;i < l;i++)
			{
				vec1[i] = new int[m];
				vec2[i] = new int[m];
				vecR[i] = new int[m];
			}
			fillMatrix(vec1, l, m);
			fillMatrix(vec2, l, m);
			outVec(vec1, l, m);
			outVec(vec2, l, m);
		}
		MPI_Bcast(&sliceSize, 1, MPI_INT, MPI::MasterRank, MPI_COMM_WORLD);
		MPI_Bcast(&l, 1, MPI_INT, MPI::MasterRank, MPI_COMM_WORLD);
		if (!process.IsMaster())
		{
			vec1 = new int* [l];
			vec2 = new int* [l];
			vecR = new int* [l];
		}
	
		int* slice1 = new int [sliceSize];
		int* slice2 = new int [sliceSize];

		for(int i = 0;i < l;i++)
		{
			Scatter(vec1[i], slice1, sliceSize); // 1. Разрезаем на равные(!) куски.
			Scatter(vec2[i], slice2, sliceSize);
			ChangeData(slice1, slice2, sliceSize); // 2. Изменяем кусок.
			Gather(vecR[i], slice1, sliceSize);
		}
			
		
		 // 3. Собираем из равных кусков.

		if (process.IsMaster())
		{
			for (int i = 0; i < l; i++)
				for (int j = m - mainSliceSize; j < m;j++)
					vecR[i][j] = vec1[i][j] + vec2[i][j];
			outVec(vecR, l, m);
		}

	}

private:

	static void Scatter(int* data, int* slice, int sliceSize)
	{
		MPI_Scatter(		   // 1: Разрезает массив на равные куски и пересылает каждому процессу свой кусок:
			data, 			   // Исходный массив (для мастер-процесса), для остальных процессов не используется.
			sliceSize, 		   // Размер куска (для мастер-процесса), для остальных процессов не используется.
			MPI_INT, 	   // Тип данных (для мастер-процесса), для остальных процессов не используется.
			slice, 		       // Массив, куда будет записываться кусок.
			sliceSize, 		   // Размер куска.
			MPI_INT, 	   // Тип данных.
			MPI::MasterRank,   // Ранг раздающего процесса.
			MPI_COMM_WORLD);   // Рабочая группа.
	}

	static void ChangeData(int* data1, int* data2, int length)
	{
		for (int i = 0;i < length;i++)
		{
			data1[i] = data1[i] + data2[i];
		}
	}

	static void Gather(int* data, int* slice, int sliceSize)
	{
		MPI_Gather(            // 3. Собираем куски в главном процессе:
			slice, 		       // Кусок.
			sliceSize, 		   // Размер куска.
			MPI_INT, 	   // Тип данных.
			data, 			   // Массив, в который будут склеиваться куски (для мастер-процесса), для остальных процессов не используется.
			sliceSize, 		   // Размер куска (для мастер-процесса), для остальных процессов не используется.
			MPI_INT, 	   // Тип данных (для мастер-процесса), для остальных процессов не используется.
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