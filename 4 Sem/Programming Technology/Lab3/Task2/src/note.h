#pragma once

struct _date
{
	char day;
	char month;
	short year;
} typedef DATE;

struct _note
{
	char name[20];
	long long tele;
	DATE date;
} typedef NOTE;

NOTE create_note(char _name[], long _tele, DATE _date);
void sort_note(NOTE* note_arr, unsigned int size);
void out_by_birthday(NOTE* person_note, unsigned int size, int mont);



