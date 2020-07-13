#pragma warning(disable : 4996)

#include <iostream>
#include <windows.h>
#include <fstream>


using namespace std;



int main(int argc, char* argv[])
{
    if (argc == 4)
    {
        char* fileBinName = argv[1];
        char* fileOutName = argv[2];
        double countPerHour = atof(argv[3]);
    	
        fstream fileBin(fileBinName, fstream::in | ios::binary);
   
        FILE* file;
        string title(fileBinName);
        title = "Report from " + title + "\n";
        file = fopen(fileOutName, "w");
        fprintf(file, title.c_str());

        while(fileBin.peek() != EOF)
        {
            int num;
            char name[10];
            double hours;
        	
            fileBin.read((char*)&num,sizeof(int));
            fileBin.read((char*)&name, sizeof(name));
            fileBin.read((char*)&hours, sizeof(hours));
            fprintf(file, "Number: %d \t Name: %s \t hours worked: %.1f \t salary: %.2f\n", num, name, hours, hours * countPerHour);
        }
    	
        fileBin.close();
        fclose(file);
    }
    else
    {
        cout << "Need more Args!";
    }
}
