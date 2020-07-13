
#pragma comment(lib,"Plugins\\MyDll2.lib")	
#include <windows.h>
#include <libloaderapi.h>
#include <iostream>
#include "MyDll2.h"

typedef BOOLEAN(__stdcall* typeFunc1)(LPSTR buffer, DWORD dwBufferSize, DWORD* pdwBytesWritten);
typedef void(__stdcall * typeFunc2)();

void getDllInfo(HMODULE hLib)
{
	
	LPSTR buff = new char[200];
	DWORD size = 200;
	DWORD pdBytesWritten = 0;

	typeFunc1 getDllName;
	typeFunc1 getAuthor;
	typeFunc1 getDescription;

	(FARPROC&)getDllName = GetProcAddress(hLib, "_GetDllName@12");
	(FARPROC&)getAuthor = GetProcAddress(hLib, "_GetAuthor@12");
	(FARPROC&)getDescription = GetProcAddress(hLib, "_GetDescription@12");
	
	getDllName(buff, size, &pdBytesWritten);
	printf("Library name:%s \n", buff);
	getAuthor(buff, size, &pdBytesWritten);
	printf("Author:%s \n", buff);
	getDescription(buff, size, &pdBytesWritten);
	printf("Description:%s \n", buff);
	
}


int main()
{
	HMODULE hLib;
	typeFunc2 Execute1;

	hLib = LoadLibrary(L"Plugins\\MyDll.dll");
	if (hLib != nullptr)
	{
		getDllInfo(hLib);
		
		(FARPROC&)Execute1 = GetProcAddress(hLib, "_Execute@0");
		Execute1();
	}

	hLib = LoadLibrary(L"Plugins\\MyDll2.dll");
	if (hLib != nullptr)
	{
		getDllInfo(hLib);
		
		Execute();
	}
	
	FreeLibrary(hLib);
}
