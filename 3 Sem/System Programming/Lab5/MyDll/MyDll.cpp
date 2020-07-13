#include "pch.h"
#include "MyDll.h"
#include <iostream>
#include <tlhelp32.h>

#define AUTHOR "Egor Prihodko"
#define DESCRIPTION "Procces info dll file"
#define NAMEDLL "MyDll"


BOOLEAN __stdcall GetDllName(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten)
{
	*pdwBytesWritten = strlen(NAMEDLL);

	if (dwBufferSize < *pdwBytesWritten)
		return FALSE;

	strcpy_s(buffer, dwBufferSize, NAMEDLL);
	return TRUE;
}

BOOLEAN __stdcall GetAuthor(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten)
{
	*pdwBytesWritten = strlen(AUTHOR);

	if (dwBufferSize < *pdwBytesWritten)
        return FALSE;

	strcpy_s(buffer, dwBufferSize,AUTHOR);
    return TRUE;
}

BOOLEAN __stdcall GetDescription(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten)
{
	*pdwBytesWritten = strlen(DESCRIPTION);
	
	if (dwBufferSize < *pdwBytesWritten)
		return FALSE;
	
	strcpy_s(buffer, dwBufferSize, DESCRIPTION);
	return TRUE;
}

void __stdcall Execute()
{
	PROCESSENTRY32 ProcEnt;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (INVALID_HANDLE_VALUE == hSnapshot) {
		return;
	}

	ProcEnt.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &ProcEnt);

	do
	{
		
		printf("======================================= \n Name: %ws \n PID: %d \n Parent PID: %d \n Priority: %d \n",
			ProcEnt.szExeFile,
			ProcEnt.th32ProcessID,
			ProcEnt.th32ParentProcessID,
			ProcEnt.pcPriClassBase
		);
		printf("===Threads info=== \n Count of threads: %d \n----------- \n", ProcEnt.cntThreads);
	} while (Process32Next(hSnapshot, &ProcEnt));
	CloseHandle(hSnapshot);
}
