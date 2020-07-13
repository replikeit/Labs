#include <stdio.h> 
#include <stdlib.h> 
#include <windows.h> 

#include "thread_params.h" 

DWORD WINAPI marker(LPVOID* p);

void out_arr(const int* arr, int size)
{
	printf("\n***Array***\n");
	for (int i = 0; i < size; i++)
		printf("%d ", arr[i]);
	printf("\n");
}

int main()
{
	HANDLE wait_thread_num_event = CreateEvent(NULL, TRUE, FALSE, NULL);
	HANDLE wait_thread_completion_event = CreateEvent(NULL, TRUE, FALSE, NULL);

	int size, thread_count;
	printf("Input size of array: ");
	scanf("%d", &size);
	printf("Input count of threads: ");
	scanf("%d", &thread_count);

	int* arr = calloc(size, sizeof(int));
	int* check_threads_completion_arr = calloc(thread_count, sizeof(int));

	HANDLE* pause_events = (HANDLE*)malloc(thread_count * sizeof(HANDLE));
	HANDLE* thread_handles = (HANDLE*)malloc(thread_count * sizeof(HANDLE));
	CRITICAL_SECTION* critical_sections = (CRITICAL_SECTION*)malloc(size * sizeof(CRITICAL_SECTION));

	for (size_t i = 0; i < size; i++)
		InitializeCriticalSection(&critical_sections[i]);
	
	for (size_t i = 0; i < thread_count; i++)
	{
		pause_events[i] = CreateEvent(NULL, TRUE, FALSE, NULL);
		

		THREAD_PARAMS* params = (THREAD_PARAMS*)malloc(sizeof(THREAD_PARAMS));
		params->thread_number = i + 1;
		params->size = size;
		params->thread_count = thread_count;
		params->arr = arr;
		params->check_threads_completion_arr = check_threads_completion_arr;
		params->wait_thread_num = wait_thread_num_event;
		params->wait_thread_completion = wait_thread_completion_event;
		params->pause_event = pause_events[i];
		params->critical_sections = critical_sections;

		thread_handles[i] = CreateThread(NULL, 0, marker, (LPVOID)params, CREATE_SUSPENDED, NULL);
	}

	for (size_t i = 0; i < thread_count; i++)
		ResumeThread(thread_handles[i]);

	int kill_counter = 0;

	while (kill_counter != thread_count)
	{
		WaitForMultipleObjects(thread_count, pause_events, TRUE, INFINITE);

		out_arr(arr, size);

		int stop_thread_num;
		printf("\nInput thread number for complete: ");
		scanf("%d", &stop_thread_num);

		if (check_threads_completion_arr[stop_thread_num - 1] != 1)
		{
			check_threads_completion_arr[stop_thread_num - 1] = 1;
			kill_counter++;
		}

		ResetEvent(wait_thread_completion_event);
		SetEvent(wait_thread_num_event);

		WaitForSingleObject(thread_handles[stop_thread_num - 1], INFINITE);

		out_arr(arr, size);

		for (size_t i = 0; i < thread_count; i++)
			if (check_threads_completion_arr[i] != 1)
				ResetEvent(pause_events[i]);

		ResetEvent(wait_thread_num_event);
		SetEvent(wait_thread_completion_event);
	}

	for (int i = 0; i < thread_count; i++)
	{
		CloseHandle(thread_handles[i]);
		CloseHandle(pause_events[i]);
		DeleteCriticalSection(&critical_sections[i]);
	}
	
	CloseHandle(wait_thread_num_event);
	CloseHandle(wait_thread_completion_event);

	free(arr);
	free(check_threads_completion_arr);
	free(thread_handles);
	free(pause_events);
	free(critical_sections);
	
	return 0;
}
