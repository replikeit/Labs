#pragma once
#include "windows.h"
#include "stdio.h"

extern float averageValue;
extern size_t len;

DWORD WINAPI _average(LPVOID arr)
{

	for (size_t i = 0; i < len; i++)
	{
		averageValue += ((int*)arr)[i];
		Sleep(14);
	}

	averageValue /= 2;

	printf("average: %.1f\n", averageValue);

	return 0;
}