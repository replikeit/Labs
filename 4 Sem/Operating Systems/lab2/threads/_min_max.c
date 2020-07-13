#pragma once
#include "windows.h"
#include "stdio.h"

extern int max = INT_MIN;
extern int min = INT_MAX;
extern size_t len;

DWORD WINAPI _min_max(LPVOID arr)
{

	for (size_t i = 0; i < len; i++)
	{
		if (max < ((int*)arr)[i]) max = ((int*)arr)[i];
		Sleep(7);
		if (min > ((int*)arr)[i]) min = ((int*)arr)[i];
		Sleep(7);
	}

	printf("min: %d\t max: %d\n", min, max);

	return 0;
}
