#pragma warning(disable:4996)
#include <windows.h>
#include <stdio.h>

int main(int argc, char* argv[])
{
	if (argc != 7)
	{	
		fprintf(stderr, "Wrong count of arguments\n");
		exit(1);
	}

	char lpsz_read[] = "EnableRead";
	HANDLE read_event = OpenEvent(EVENT_ALL_ACCESS, FALSE, lpsz_read);
	
	char* bin_file_name = argv[1];
	unsigned int notes_count = atoi(argv[2]);
	HANDLE ready_event = (HANDLE)atoi(argv[3]);
	HANDLE read_handle = (HANDLE)atoi(argv[4]);
	HANDLE write_handle = (HANDLE)atoi(argv[5]);
	unsigned int id = atoi(argv[6]);

	printf("*** Process number %d is ready***\n", id);
	SetEvent(ready_event);
	
	while (1)
	{
		int action;
		printf("1 - input\t2 - exit\n");
		scanf("%d", &action);

		if (action == 1)
		{
			char str[20];
			printf("Input string: ");
			scanf("%s", &str);
				
			unsigned int current_count;
			DWORD dwBytesRead;
			if (!ReadFile(read_handle,&current_count,sizeof(current_count),&dwBytesRead,NULL))
			{
				fprintf(stderr, "Read from the pipe failed.\n");
				return GetLastError();
			}
			
			if (current_count < notes_count)
			{
				WaitForSingleObject(read_event, INFINITE);
				
				current_count++;
				DWORD dwBytesWritten;
				if (!WriteFile(write_handle, &current_count,sizeof(current_count),&dwBytesWritten,NULL))
				{
					fprintf(stderr, "Write to the pipe failed.\n");
					return GetLastError();
				}
				
				FILE* out_file = fopen(bin_file_name, "a+b");
				fwrite(&str, sizeof(char), 20, out_file);
				fclose(out_file);
				
				printf("Write in file is done\n");
			}
			else
			{
				printf("Write Error: File is full.\n");
				system("PAUSE");
				break;
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

	CloseHandle(read_handle);
	CloseHandle(write_handle);
}

