#pragma warning(disable : 4996)
#include <stdio.h>
#include <Windows.h>
#include <tlhelp32.h>


#define GENERATE_BUTTON 4
#define GENERATE_CHECK_THREAD_BUTTON 5
#define GENERATE_CHECK_MODULE_BUTTON 6
LRESULT CALLBACK WindowsProcedure(HWND, UINT, WPARAM, LPARAM);

void addControls(HWND hWnd);
void changeCheckBox(HWND, BOOL*);
void setInfo();

#define ID_LIST 502
BOOL checkT = FALSE;
BOOL checkM = FALSE;
HWND hList;
HWND checkBoxT;
HWND checkBoxM;
int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR args, int ncmdshow)
{
	WNDCLASSW wc = { 0 };

	wc.hbrBackground = (HBRUSH)COLOR_WINDOW;
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hInstance = hInst;
	wc.lpszClassName = L"Window";
	wc.lpfnWndProc = WindowsProcedure;

	if (!RegisterClassW(&wc))
		return -1;

	CreateWindowW(L"Window", L"Procces info", WS_OVERLAPPEDWINDOW | WS_VISIBLE, 100, 20, 1200, 700, NULL, NULL, NULL, NULL);

	MSG msg = { 0 };

	while (GetMessage(&msg, NULL, NULL, NULL))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return 0;
}

LRESULT CALLBACK WindowsProcedure(HWND hWnd, UINT msg, WPARAM wp, LPARAM lp)
{
	switch (msg)
	{
	case WM_COMMAND:

		switch (wp)
		{
		case GENERATE_BUTTON:
			setInfo();
			break;
		case GENERATE_CHECK_THREAD_BUTTON:
			changeCheckBox(checkBoxT, &checkT);
			break;
		case GENERATE_CHECK_MODULE_BUTTON:
			changeCheckBox(checkBoxM, &checkM);
			break;
		}

		break;


	case WM_CREATE:
		addControls(hWnd);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_CTLCOLOREDIT:
	{
		HBRUSH hbrBk = GetSysColorBrush(DEFAULT_GUI_FONT);
		LOGBRUSH bk_brush_info;
		GetObject(hbrBk, sizeof(bk_brush_info), &bk_brush_info);

		SetTextColor((HDC)wp, RGB(0, 255, 0));
		SetBkColor((HDC)wp, bk_brush_info.lbColor);

		return (int)hbrBk;
	}
	default:
		DefWindowProcW(hWnd, msg, wp, lp);

	}
}

void addControls(HWND hWnd)
{
	CreateWindowW(L"Static", L"Info here",
		WS_VISIBLE | WS_CHILD,
		20, 180, 100, 30,
		hWnd, NULL, NULL, NULL);

	hList = CreateWindowEx(WS_EX_CLIENTEDGE, L"listbox", NULL,
		WS_CHILD | WS_VISIBLE | LBS_STANDARD & (~LBS_SORT),
		10, 200, 1165, 400, hWnd, (HMENU)ID_LIST, NULL, NULL);

	CreateWindowW(L"Button", L"Get Info Now",
		WS_VISIBLE | WS_CHILD | WS_BORDER,
		1050, 120, 100, 50, hWnd, (HMENU)GENERATE_BUTTON, NULL, NULL);

	checkBoxT = CreateWindow(L"Button", L"Info about Threads",
		WS_VISIBLE | WS_CHILD | BS_CHECKBOX,
		20, 20, 185, 35,
		hWnd, (HMENU)GENERATE_CHECK_THREAD_BUTTON, NULL, NULL);

	checkBoxM = CreateWindow(L"Button", L"Info about Modules",
		WS_VISIBLE | WS_CHILD | BS_CHECKBOX,
		20, 80, 185, 35,
		hWnd, (HMENU)GENERATE_CHECK_MODULE_BUTTON, NULL, NULL);
}

void changeCheckBox(HWND checkBox, BOOL* checkFlag)
{
	if (*checkFlag == FALSE)
	{
		SendMessage(checkBox, BM_SETCHECK, BST_CHECKED, 0);
		*checkFlag = TRUE;
	}
	else
	{
		SendMessage(checkBox, BM_SETCHECK, BST_UNCHECKED, 0);
		*checkFlag = FALSE;
	}
}









void getThreadInfo(DWORD procId)
{
	THREADENTRY32 threadEnt;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
	if (INVALID_HANDLE_VALUE == hSnapshot)
	{
		return;
	}
	WCHAR* tmpStr = (WCHAR*)calloc(30, sizeof(WCHAR*));
	WCHAR buf[10];
	threadEnt.dwSize = sizeof(THREADENTRY32);
	Thread32First(hSnapshot, &threadEnt);
	do
	{
		if (procId == threadEnt.th32OwnerProcessID)
		{
			SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)L"--------- ");
			wcscpy(tmpStr, L"Thread ID: ");
			_swprintf(buf, L"%d", threadEnt.th32ThreadID);
			wcscat(tmpStr, buf);
			SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
			wcscpy(tmpStr, L"Priority: ");
			_swprintf(buf, L"%d", threadEnt.tpBasePri);
			wcscat(tmpStr, buf);
			SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		}
	} while (Thread32Next(hSnapshot, &threadEnt));
	CloseHandle(hSnapshot);
	free(tmpStr);
}

void getModuleInfo(DWORD procId)
{
	MODULEENTRY32 moduleEnt;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE, procId);
	if (INVALID_HANDLE_VALUE == hSnapshot)
	{
		return;
	}
	moduleEnt.dwSize = sizeof(MODULEENTRY32);
	WCHAR buf[20];
	WCHAR* tmpStr = (WCHAR*)calloc(266, sizeof(WCHAR*));
	Module32First(hSnapshot, &moduleEnt);
	SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)L"===Modules info===");
	do
	{
		wcscpy(tmpStr, L"Size of Module: ");
		_swprintf(buf, L"%d", moduleEnt.dwSize);
		wcscat(tmpStr, buf);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		wcscpy(tmpStr, L"Module Path: ");
		wcscat(tmpStr, moduleEnt.szExePath);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
	} while (Module32Next(hSnapshot, &moduleEnt));
	CloseHandle(hSnapshot);
}


void setInfo()
{
	SendMessage(hList, LB_RESETCONTENT, 0, 0);
	PROCESSENTRY32 ProcEnt;
	HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	if (INVALID_HANDLE_VALUE == hSnapshot) {
		return;
	}
	WCHAR buf[10];
	WCHAR* tmpStr = (WCHAR*)calloc(266, sizeof(WCHAR*));
	ProcEnt.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &ProcEnt);
	do
	{
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)L"=======================================");
		wcscpy(tmpStr, L"Name: ");
		wcscat(tmpStr, ProcEnt.szExeFile);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		wcscpy(tmpStr, L"PID: ");
		_swprintf(buf, L"%d", ProcEnt.th32ProcessID);
		wcscat(tmpStr, buf);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		wcscpy(tmpStr, L"Parent PID: ");
		_swprintf(buf, L"%d", ProcEnt.th32ParentProcessID);
		wcscat(tmpStr, buf);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		wcscpy(tmpStr, L"Priority: ");
		_swprintf(buf, L"%d", ProcEnt.pcPriClassBase);
		wcscat(tmpStr, buf);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
		if (checkT == TRUE)
		{
			SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)L"===Threads info===");
			wcscpy(tmpStr, L"Count of threads: ");
			_swprintf(buf, L"%d", ProcEnt.cntThreads);
			wcscat(tmpStr, buf);
			SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)tmpStr);
			getThreadInfo(ProcEnt.th32ProcessID);
		}
		if (checkM == TRUE)
		{
			getModuleInfo(ProcEnt.th32ProcessID);
		}
	} while (Process32Next(hSnapshot, &ProcEnt));
	CloseHandle(hSnapshot);
	free(tmpStr);
}