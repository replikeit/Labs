#include <windows.h>
#include <stdio.h>

int main(int argc, char* argv[])
{
	PROCESS_INFORMATION proc_info;
	STARTUPINFO	start_info = { sizeof(start_info) };
	char bin_file_name[255];
	unsigned int notes_count, processes_count;
	HANDLE read_handle, write_handle;

	if (!CreatePipe(&read_handle, &write_handle, NULL, 0))
	{
		fprintf(stderr, "Create pipe failed.\n");
		return GetLastError();
	}

	int x = 0;
	DWORD dwBytesWritten;
	if (!WriteFile(write_handle, &x, sizeof(&x), &dwBytesWritten, NULL))
	{
		fprintf(stderr, "Write to the pipe failed.\n");
		return GetLastError();
	}
	
	printf("Input the name of bin file: ");
	scanf("%s", &bin_file_name);
	printf("Input count of notes: ");
	scanf("%d", &notes_count);
	printf("Input count of processes: ");
	scanf("%d", &processes_count);
	
	fclose(fopen(bin_file_name, "wb"));	
	
	HANDLE* handle_arr = (HANDLE*)malloc(sizeof(HANDLE) * processes_count);
	HANDLE* ready_events = (HANDLE*)malloc(sizeof(HANDLE) * processes_count);
	
	for (unsigned int i = 0; i < processes_count; i++)
	{
		HANDLE duplicate_read_handle, duplicate_write_handle, duplicate_ready_event;
		ready_events[i] = CreateEvent(NULL, TRUE, FALSE, NULL);

		if (!DuplicateHandle(GetCurrentProcess(), ready_events[i],
			GetCurrentProcess(), &duplicate_ready_event, 0,
			TRUE, DUPLICATE_SAME_ACCESS))
		{
			fprintf(stderr, "Duplicate handle failed.\n");
			return GetLastError();
		}
		
		if (!DuplicateHandle(GetCurrentProcess(),write_handle,
			GetCurrentProcess(), &duplicate_write_handle, 0, 	
			TRUE, DUPLICATE_SAME_ACCESS))
		{
			fprintf(stderr, "Duplicate handle failed.\n");
			return GetLastError();
		}

		if (!DuplicateHandle(GetCurrentProcess(), read_handle,
			GetCurrentProcess(), &duplicate_read_handle, 0,
			TRUE, DUPLICATE_SAME_ACCESS))
		{
			fprintf(stderr, "Duplicate handle failed.\n");
			return GetLastError();
		}
		
		char tmp[255];
		sprintf(tmp, "Sender.exe \"%s\" \"%d\" \"%d\" \"%d\" \"%d\" \"%d\"", 
			bin_file_name, notes_count, (int)duplicate_ready_event,(int)duplicate_read_handle, (int)duplicate_write_handle, i + 1);
		WCHAR full_name_args_process[255];
		mbstowcs(&full_name_args_process[0], tmp, 255);

		CreateProcess(NULL, full_name_args_process, NULL,
			NULL, TRUE, CREATE_NEW_CONSOLE,
			NULL, NULL, &start_info, &proc_info);
		handle_arr[i] = proc_info.hProcess;

		CloseHandle(duplicate_read_handle);
		CloseHandle(duplicate_write_handle);
		CloseHandle(duplicate_ready_event);
	}

	WaitForMultipleObjects(processes_count, ready_events, TRUE, INFINITE);

	char lpsz_read[] = "EnableRead";
	HANDLE read_event = OpenEvent(EVENT_ALL_ACCESS, FALSE, lpsz_read);
	
	while (1)
	{
		int action;
		printf("1 - read\t2 - exit\n");
		scanf("%d", &action);

		if (action == 1)
		{
			WaitForSingleObject(read_event, INFINITE);

			HANDLE duplicate_read_handle;
			if (!DuplicateHandle(GetCurrentProcess(), read_handle,
				GetCurrentProcess(), &duplicate_read_handle, 0,
				TRUE, DUPLICATE_SAME_ACCESS))
			{
				fprintf(stderr, "Duplicate handle failed.\n");
				return GetLastError();
			}
			
			unsigned int current_count;
			DWORD dwBytesRead;
			if (!ReadFile(duplicate_read_handle, &current_count, sizeof(current_count), &dwBytesRead, NULL))
			{
				fprintf(stderr, "Read from the pipe failed.\n");
				return GetLastError();
			}
			
			
			for (size_t i = 0; i < current_count; i++)
			{
				FILE* file = fopen(bin_file_name, "rb");
				
				char str[20];
				fread(&str, sizeof(char), 20, file);
				printf("%s\n", str);

				fclose(file);
			}
		}
		else if (action == 2)
		{
			break;
		}
		else
		{
			printf("Wrong Action\n");
		}
	}

	for (size_t i = 0; i < processes_count; i++)
	{
		CloseHandle(handle_arr[i]);
		CloseHandle(ready_events[i]);
	}
	CloseHandle(write_handle);
	CloseHandle(write_handle);

	free(handle_arr);
	free(ready_events);
}

