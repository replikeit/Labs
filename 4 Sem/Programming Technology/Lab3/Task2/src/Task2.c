#pragma warning(disable : 4996)

#include "note.h"
#include "stdio.h"
#include "time.h"
#include "stdlib.h"

int main(int argc, char* argv[])
{
	
	unsigned int size = 9;
	NOTE* block = (NOTE*)calloc(size, sizeof(NOTE));

	for (size_t i = 0; i < size; i++)
	{
		printf("Input %d person: ", i+1);
		int m, d, y;
		long long phone;
		char name[20];
		scanf("%s %lld %d/%d/%d", &name, &phone, &d, &m, &y);
		
		DATE tmp_date = { d, m, y};
		block[i] = create_note(name, phone, tmp_date);
	}

	sort_note(block, size);
	out_by_birthday(block, size, 5);
	
	free(block);
	
	return 0;

}
	
