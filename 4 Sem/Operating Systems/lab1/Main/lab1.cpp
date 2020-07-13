#pragma warning(disable:4996)
#include <iostream>
#include <windows.h>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	PROCESS_INFORMATION procInfo;
	STARTUPINFO	startInfo;
	string binFileName;
	int count = 0;

	printf("Input the name of bin file: ");
	getline(cin, binFileName);
	printf("Input count of notes: ");
	cin >> count;

	startInfo = { sizeof(STARTUPINFO) };

	string fullNameAndArgs = "Creator.exe \"" + binFileName + "\" \"" + to_string(count) + "\"";
	wstring fullNameAndArgs_wchar(255, L' ');
	copy(fullNameAndArgs.begin(), fullNameAndArgs.end(), fullNameAndArgs_wchar.begin());

	CreateProcess(NULL, &fullNameAndArgs_wchar[	0], NULL,
		NULL, TRUE, CREATE_NEW_CONSOLE,
		NULL, NULL, &startInfo, &procInfo);
	WaitForSingleObject(procInfo.hProcess, INT_MAX);
	CloseHandle(procInfo.hProcess);

	fstream	binFile(binFileName, fstream::in | fstream::binary);
	printf("*******Data from bin file*******\n");
	while (binFile.peek() != EOF)
	{
		int num;
		char name[10];
		double hours;

		binFile.read((char*)&num, sizeof(int));
		binFile.read((char*)&name, sizeof(name));
		binFile.read((char*)&hours, sizeof(hours));

		printf("Number: %d \t Name: %s \t hours worked: %.1f\n", num, name, hours);
	}
	binFile.close();

	
	string repNameFile;
	double payPerHour;
	
	cin.ignore();
	printf("Input the name of report file: ");
	getline(cin, repNameFile);
	printf("Input money per hour: ");
	cin >> payPerHour;
	
	fullNameAndArgs = "Reporter.exe \"" + binFileName + "\" \"" + repNameFile + "\" \"" + to_string(payPerHour) +"\"" ;
	copy(fullNameAndArgs.begin(), fullNameAndArgs.end(), fullNameAndArgs_wchar.begin());

	CreateProcess(NULL, &fullNameAndArgs_wchar[0], NULL,
		NULL, TRUE, CREATE_NEW_CONSOLE,
		NULL, NULL, &startInfo, &procInfo);
	WaitForSingleObject(procInfo.hProcess, INT_MAX);
	CloseHandle(procInfo.hProcess);

	ifstream repFile(repNameFile);
	string title;
	getline(repFile,title);
	printf("*******%s*******\n",title.c_str());
	while (repFile)
	{
		string tmpStr;
		getline(repFile, tmpStr);
		
		printf("%s\n",tmpStr.c_str());
	}
	repFile.close();
	
	system("PAUSE");
}