#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

#include "thread_params.h"

DWORD WINAPI marker(LPVOID* p)
{
	THREAD_PARAMS params = *((THREAD_PARAMS*)p);

	srand(params.thread_number);
	unsigned int mark_counter = 0;
	int* mark_check_arr = calloc(sizeof(int), params.size);
	
	while(1)
	{
		int rand_num = rand() % params.size;
		
		EnterCriticalSection(&params.critical_sections[rand_num]);
		if (params.arr[rand_num] == 0)
		{
			Sleep(5);
			params.arr[rand_num] = params.thread_number;
			Sleep(5);
			mark_check_arr[rand_num] = 1;
			mark_counter++;
			LeaveCriticalSection(&params.critical_sections[rand_num]);
		}
		else
		{
			LeaveCriticalSection(&params.critical_sections[rand_num]);

			printf("Info about %d-st thread: mark_count: %d\t impossible to tag index: %d\n", 
					params.thread_number, mark_counter++, rand_num);

			SetEvent(params.pause_event);

			WaitForSingleObject(params.wait_thread_num, INFINITE);

			if(params.check_threads_completion_arr[params.thread_number - 1] == 1)
			{
				for (int i = 0; i < params.thread_count; i++)
					if (mark_check_arr[i] == 1) params.arr[i] = 0;

				break;
			}

			WaitForSingleObject(params.wait_thread_completion, INFINITE);
			
			free(mark_check_arr);
			
			mark_check_arr = calloc(sizeof(int), params.size);
			mark_counter = 0;
		}
	}

	free(p);
	free(mark_check_arr);
	
	return 0;
}
