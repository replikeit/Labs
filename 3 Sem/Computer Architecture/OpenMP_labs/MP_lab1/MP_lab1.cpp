#include <omp.h>
#include <iostream>
#include <sstream>
#include <ctime>
#include <cmath>


#define PI 3.14159265


using namespace std;
const int ThreadsCount = 8;

class Program
{
public:
	static void Main(int n)
	{

		omp_set_nested(true);
		double a = 0;
		double b = 2;	
		findmax(a, b, n);
	}

private:
	static double func(double x)
	{

		if (0 <= x && x <= PI / 2)
			return cos(x);
		else if (PI / 2 < x && x <= 2)
			return (PI/2 - x);
	}


	static void findmax(double a, double b, int n)
	{
		double step = (b-a) / n;
		double step2 = (b - a) / (4 * n);
		double max2 = INT_MIN;
		double max = INT_MIN;
		#pragma omp parallel sections
		{
			#pragma omp section
			{
				double y1 = func(0) / step;
				#pragma omp parallel for num_threads(ThreadsCount) shared(y1)
				for (int i = 0; i <= n; i++)
				{
					double y2 = func(i * step + step) / step;
					double y = abs(y2 - y1);
					y1 = y2;
					if (max < y)
					{
						#pragma omp critical
						{
							if (max < y)
								max = y;
						}
					}
				}
			}
			#pragma omp section
			{
				#pragma omp parallel for num_threads(ThreadsCount)
				for (int i = 0; i <= n*4; i++)
				{
					double y = abs((func(i * step2 + step2) - func(i * step2)) / step2);
					if (max2 < y)
					{
						#pragma omp critical
						{
							if (max2 < y)
								max2 = y;
						}
					}
				}
			}
			
		}
		cout.precision(8);
		std::cout  <<"Task for N: "<<max << endl;
		std::cout  << "Task for N*4: "<<max2 << endl;
	}
};

int main(int argc, char* argv[])
{
	if (argc == 2)
	{
		Program::Main(atoi(argv[1]));
	}
	else
	{
		cout << "Error: Need args"<<endl;
	}
	Program::Main(10000);
}	