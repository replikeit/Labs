#pragma warning(disable : 4996)

#include <iostream>
#include <windows.h>
#include <fstream>


using namespace std;

struct Employee
{
    int num;         // идентификационный номер сотрудника
    char name[10];   // имя сотрудника
    double hours;    // количество отработанных часов
};

Employee CreateEmp(int empNumber, char empName[10], double empHours)
{
    int tmpName;
    char name[10];
    //sprintf();
    //wsprintf()
    //wnsprintf()
    Employee tmpEmp{};
    tmpEmp.num = empNumber;
    strcpy_s(tmpEmp.name, 10, empName);
    tmpEmp.hours = empHours;
    return tmpEmp;
}

int main(int argc, char* argv[])
{
    if (argc == 3)
    {
        char* fileName = argv[1];
        int countOfEmp = atoi(argv[2]);   
        Employee* empArray = new Employee[countOfEmp];
        for (int i = 0; i < countOfEmp; i++)
        {
            int num;
            char name[10];
            double hours;
            printf("%s %d %s", "Input info about",i + 1,"employee: ");
            scanf("%d %s %f", &num, name, &hours);
            empArray[i] = CreateEmp(num, name, hours);
        }
    	
        fstream file(fileName, fstream::out | ios::binary);

        for (size_t i = 0; i < countOfEmp; i++)
        {
            file.write((char*)&empArray[i].num, sizeof(empArray[i].num));
            file.write((char*)&empArray[i].name, sizeof(empArray[i].name));
            file.write((char*)&empArray[i].hours, sizeof(empArray[i].hours));
        }

        file.close();
        delete[] empArray;
    }
    else
    {
        cout << "Need more Args!\n";
        system("pause");
    }
}
