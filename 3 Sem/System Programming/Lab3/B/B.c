#include <windows.h>
#include <stdio.h>
#include <TlHelp32.h>

int main(void)
{
	DWORD wrBuf, memBuf, readBuf;
	LPCWSTR pipe = L"\\\\.\\pipe\\Pipe";

	printf("Waiting string...\n");	
	HANDLE HPipe = CreateNamedPipe(pipe, PIPE_ACCESS_DUPLEX,
		PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT,
		PIPE_UNLIMITED_INSTANCES, sizeof(DWORD),
		sizeof(DWORD), 100,
		NULL);

	if (HPipe == INVALID_HANDLE_VALUE)
		return -1;
	ConnectNamedPipe(HPipe, NULL);
	ReadFile(HPipe, &memBuf,
		sizeof(memBuf), &readBuf,
		NULL);
	printf("String from first process: %s\n", (char*)memBuf);
	WriteFile(HPipe, &memBuf, sizeof(memBuf), &wrBuf, NULL);
	DisconnectNamedPipe(HPipe);
	system("pause");
	return 0;
}