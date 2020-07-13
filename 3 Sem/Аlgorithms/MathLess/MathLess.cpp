#include <vector>
#include <fstream>
#include <set>
#include <algorithm>
using namespace std;



int main()
{
	set<int> st;
	ifstream f("input.txt");
	ofstream fk("output.txt");
	int n;
	f >> n;
	vector<int> vec(n * n);
	vector<int> vec_sec(n);
	vector<int> vec2;
	for (int i = 0; i < n * n; i++)
	{
		f >> vec[i];
	}
	sort(vec.begin(), vec.end());
	vec_sec[0] = (vec[0] / 2);
	vec_sec[1] = (vec[1] - vec_sec[0]);

	int i = 3;
	int chet2 = 2;
	int i2 = 2;
	int chet = 1;
	int c = 1;

	while (vec_sec.size() != chet2)
	{
		while (true)
		{


			if (vec[i + 1] >= 2 * vec_sec[chet])
			{
				i++;
				chet += 0;
				c = 0;
			}

			vec_sec[i2] = (vec[i] - vec_sec[chet - 1]);

			chet2++;
			i2++;
			c++;
			i += 2;

			if (vec_sec.size() == chet2)
			{
				break;
			}
		}
	}

	for (int i = 0; i < n; i++)
	{
		fk << vec_sec[i] << endl;
	}
}