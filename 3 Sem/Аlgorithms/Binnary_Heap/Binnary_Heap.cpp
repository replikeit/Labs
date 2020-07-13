#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <queue>
using namespace std;

int n;

bool check = true;
int main()
{


	ifstream f("in.txt");
	ofstream fk("out.txt");
	f >> n;
	vector<long long> shahVec(n);
	string info, del = " ";
	long long c;
	for (int i = 0; i < n; i++)
	{
		f >> c;
		shahVec[i] = c;
	}
	if (n == 1)
	{
		(check) ? fk << "Yes" : fk << "No";
		return 0;
	}
	if (n == 2)
	{
		(shahVec[0] < shahVec[1]) ? fk << "Yes" : fk << "No";
		return 0;
	}
	for (int i = 0; i <= (n - 2) / 2; i++)
	{
		if (shahVec[i] > shahVec[2 * i + 1] || (2 * i + 2 != n) && shahVec[i] > shahVec[2 * i + 2])
		{
			check = false;
			break;
		}

	}
	(check) ? fk << "Yes" : fk << "No";


}