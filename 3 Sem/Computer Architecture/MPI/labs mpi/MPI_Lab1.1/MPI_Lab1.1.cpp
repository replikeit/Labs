#include <mpi.h>
#include <iostream>
#include "Process.h"
#include <ctime>



void outVec(float* vec, int len)
{
	std::cout << "(" << vec[0];
	for (int i = 1;i < len;i++)
	{
		std::cout << "," << vec[i];
	}
	std::cout << ")" << std::endl;
}



class Program
{
public:
	static void Main()
	{
		float* vec1 = nullptr;
		float* vec2 = nullptr;
		float* vecR = nullptr;
		auto process = MPI::Process();
		int mainSliceSize  = 1;
		int sliceSize =  1;
		int l = 0;
		if (process.IsMaster())
		{
			std::cout << "Input L: ";
			std::cin >> l;
			if (l > process.GetProcessCount())
			{
				sliceSize = l / process.GetProcessCount();
				mainSliceSize = l % process.GetProcessCount();
			}
			vec1 = new float[l];
			vec2 = new float[l];
			vecR = new float[l];
			for (int i = 0;i < l;i++)
			{
				vec1[i] = float((rand() % 200 - 100)) / 100;
				vec2[i] = float((rand() % 200 - 100)) / 100;
			}
			outVec(vec1, l);
			outVec(vec2, l);

		}

		MPI_Bcast(&sliceSize,1,MPI_DOUBLE,  MPI::MasterRank,MPI_COMM_WORLD);

		auto slice1 = new float[sliceSize];
		auto slice2 = new float[sliceSize];

		Scatter(vec1, slice1, sliceSize); // 1. Разрезаем на равные(!) куски.
		Scatter(vec2, slice2, sliceSize);

		ChangeData(slice1,slice2, sliceSize); // 2. Изменяем кусок.
		Gather(vecR, slice1, sliceSize); // 3. Собираем из равных кусков.

		if(process.IsMaster())
		{
			for(int i = l - mainSliceSize; i < l;i++)
			{
				vecR[i] = vec1[i] * vec2[i];
			}
			outVec(vecR,l);
		}
		
	}

private:

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

	static void ChangeData(float* data1, float* data2, int length)
	{
		for(int i = 0;i < length;i++)
		{
			data1[i] = data1[i] * data2[i];
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