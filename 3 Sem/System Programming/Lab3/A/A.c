#pragma warning(disable : 4996)
#include <windows.h>
#include <stdio.h>	
#include <TlHelp32.h>

DWORD getProc(const WCHAR* procName)
{
	PROCESSENTRY32 ProcEnt;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (INVALID_HANDLE_VALUE == hSnapshot) {
		return -1;
	}
	ProcEnt.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &ProcEnt);
	do
	{
		if (wcscmp(procName, ProcEnt.szExeFile) == 0)
		{
			CloseHandle(hSnapshot);
			return ProcEnt.th32ProcessID;
		}
	} while (Process32Next(hSnapshot, &ProcEnt));
	CloseHandle(hSnapshot);
}

int main(void)
{
	LPCWSTR pipeName = L"\\\\.\\pipe\\Pipe";
	char str[260];

	DWORD IdBProc = getProc(L"B.exe");
	if (IdBProc == -1)
		return -1;


	HANDLE HNDLBProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, IdBProc);
	if (HNDLBProc == INVALID_HANDLE_VALUE)
		return -1;


	printf("Input string:");
	scanf("%s", &str);
	printf("\n");

	//Выделение памяти во втором процессе
	LPVOID VirtualPtrAddres = VirtualAllocEx(HNDLBProc, NULL, 260,
		MEM_RESERVE | MEM_COMMIT, PAGE_EXECUTE_READWRITE);


	WriteProcessMemory(HNDLBProc, VirtualPtrAddres, str, 260, 0);


	HANDLE HNDLBPipe = CreateFile(pipeName, GENERIC_READ | GENERIC_WRITE,
		0, NULL, OPEN_EXISTING,
		0, NULL);
	if (HNDLBPipe == INVALID_HANDLE_VALUE)
		return -1;

	DWORD cWrite, cRead, x;

	WriteFile(HNDLBPipe, &VirtualPtrAddres, sizeof(x), &cWrite, NULL);
	ReadFile(HNDLBPipe, &VirtualPtrAddres, sizeof(VirtualPtrAddres), &cRead, NULL);

	VirtualFreeEx(HNDLBProc, VirtualPtrAddres, 0, MEM_RELEASE);
	CloseHandle(HNDLBPipe);
	CloseHandle(HNDLBProc);
	
	system("pause");
}