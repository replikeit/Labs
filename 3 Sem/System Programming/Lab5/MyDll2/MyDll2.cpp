#include "pch.h"
#include "MyDll2.h"
#include <iostream>
#include <tlhelp32.h>

#define AUTHOR "Egor Prihodko"
#define DESCRIPTION "PC info dll"
#define NAMEDLL "MyDll2"



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

	strcpy_s(buffer, dwBufferSize, AUTHOR);
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
	SYSTEM_INFO siSysInfo;
	
	GetSystemInfo(&siSysInfo);

	printf("Hardware information: \n");
	printf("  OEM ID: %u\n", siSysInfo.dwOemId);
	printf("  Number of processors: %u\n",
		siSysInfo.dwNumberOfProcessors);
	printf("  Page size: %u\n", siSysInfo.dwPageSize);
	printf("  Processor type: %u\n", siSysInfo.dwProcessorType);
	printf("  Minimum application address: %lx\n",
		siSysInfo.lpMinimumApplicationAddress);
	printf("  Maximum application address: %lx\n",
		siSysInfo.lpMaximumApplicationAddress);
	printf("  Active processor mask: %u\n",
		siSysInfo.dwActiveProcessorMask);
}

