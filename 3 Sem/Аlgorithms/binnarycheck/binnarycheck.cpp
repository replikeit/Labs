#include <iostream>
#include <fstream>
#include <intrin.h>

using namespace std;

int main()
{
	char x = 0;
	fstream input("data.bin", ios_base::in | ios_base::binary);
	int m, n;
	//ofstream output("data2.bin", ios_base::out | ios_base::binary);
	
	
	input.read(reinterpret_cast<char*>(&m), sizeof(int));
	cout << _byteswap_ulong(m)<<endl;
	input.read(reinterpret_cast<char*>(&n), sizeof(int));
	cout << _byteswap_ulong(n)<<endl;
	//output.write(reinterpret_cast<char*>(&m), sizeof(int));
	//output.write(reinterpret_cast<char*>(&n), sizeof(int));
	for(int i = 0; i < 10000;i++)
	{
		input.read((&x), sizeof(char));
		//output.write((&x), sizeof(char));
			cout << (x)<<endl;
	}


	input.close();
	//output.close();
}