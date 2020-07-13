#pragma once

#include <windows.h>

struct _THREAD_PARAMS
{
	int thread_number;
	int size;
	int thread_count;
	int* arr;
	int* check_threads_completion_arr;

	HANDLE wait_thread_num;
	HANDLE wait_thread_completion;
	HANDLE pause_event;

	CRITICAL_SECTION* critical_sections;
}typedef THREAD_PARAMS;
