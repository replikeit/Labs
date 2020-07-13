#pragma warning(disable : 4996)

#include "note.h"
#include "stdlib.h"
#include "stdio.h"
#include "string.h"

NOTE create_note(char _name[], long _tele, DATE _date)
{
	NOTE result;
	strcpy(result.name, _name);
	result.tele = _tele;
	result.date = _date;
	return result;
}

void sort_note(NOTE* note_arr, unsigned int size)
{
	for (unsigned int i = 0; i < size; i++)
	{
		for (unsigned int j = i+1; j < size; j++)
		{
			if (strcmp(note_arr[i].name, note_arr[j].name) == 1)
			{
				NOTE tmp_note = note_arr[i];
				note_arr[i] = note_arr[j];
				note_arr[j] = tmp_note;
			}
		}
	}
}

void out_by_birthday(NOTE* person_note, unsigned int size, int month)
{
	int counter = 0;
	
	printf("Matches by birthday!\n");
	for (unsigned int i = 0; i < size; i++)
	{
		if(person_note[i].date.month == month)
		{
			counter++;
			printf("%s ", person_note[i].name);
		}
	}
	
	if (counter == 0)
	{
		printf("No matches!\n");
	}
	else
	{
		printf("\n%d matches found\n",counter);
	}
}
