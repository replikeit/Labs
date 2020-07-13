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
		double b = 1;
		getIntegral(a, b, n);
	}

private:
	static double func(double x)
	{

		return (x * x) - 2 * x;
	}


	static void getIntegral(double a, double b, int n)
	{
		double step = (b - a) / n;
		double sum = 0;
		#pragma omp parallel sections
		{
			#pragma omp section
			{
				
				#pragma omp parallel for num_threads(ThreadsCount) reduction(+:sum)
				for (int i = 0; i <= n; i++)
				{
					double y = step*func(i*step);
					sum += y;
				}
			}	

		}
		double exact = (pow(b, 3) / 3 - pow(b, 2)) -( pow(a, 3) / 3 - pow(a, 2));
		cout.precision(8);
		std::cout << "Integral: " << sum << endl;
		std::cout << "Exacting integral: " << exact << endl;
	}
};

int main(int argc, char* argv[])
{
	if (argc == 2)
	{
		Program::Main(10);	
	}
	else
	{
		cout << "Error: Need args" << endl;
		return -1;
	}
}