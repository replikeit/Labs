#pragma once
#include "windows.h"
#include "stdio.h"

int max;
int min;
float averageValue;
size_t	len;

DWORD WINAPI _min_max(LPVOID arr);
DWORD WINAPI _average(LPVOID arr);

int main()
{

	printf("Input a len of array: ");
	scanf_s("%d",&len);
	int* arr = (int*)malloc(sizeof(int)*len);
	
	printf("Input mass: ");
	for (size_t i = 0; i < len; i++)
	{
		int temp;
		scanf_s("%d", &arr[i]);
	}
	
	HANDLE thMin_Max = CreateThread(NULL, 0, _min_max, (LPVOID)arr, 0, NULL);
	if (thMin_Max == NULL) return 0;
	HANDLE thAverage = CreateThread(NULL, 0, _average, (LPVOID)arr, 0, NULL);
	if (thAverage == NULL) return 0;

	WaitForSingleObject(thMin_Max, INFINITE);
	WaitForSingleObject(thAverage, INFINITE);

	CloseHandle(thMin_Max);
	CloseHandle(thAverage);

	printf("Array: ");
	for (size_t i = 0; i < len; i++)
	{
		if (arr[i] == min || arr[i] == max)
		{
			arr[i] = (int)(averageValue);
			printf("%.1f ", averageValue);
		}
		else
		{
			printf("%d ", arr[i]);
		}
	}
	
	free(arr);
	
	return 0;
}

