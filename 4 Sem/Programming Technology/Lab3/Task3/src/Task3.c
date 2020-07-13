#pragma warning(disable : 4996)

#include "worker.h"
#include "stdio.h"

int main(int argc, char* argv[])
{
	
	FILE* f = fopen("input.txt", "r");
	FILE* fo = fopen("output.txt", "w");

	unsigned int size;
	WORKER* worker_arr = read(f, &size);
	out_by_working_started(worker_arr, fo, size, 2010);
	
	fclose(f);
	fclose(fo);

	return 0;
}

