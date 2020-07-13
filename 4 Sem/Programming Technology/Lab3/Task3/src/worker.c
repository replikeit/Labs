#pragma warning(disable : 4996)

#include "worker.h"
#include "stdlib.h"
#include "stdio.h"



void out_by_working_started(WORKER* worker_arr,FILE* f, unsigned int size, int year)
{
	int counter = 0;
	
	fprintf(f, "***Matches by year working started***\n\n");
	for (unsigned int i = 0; i < size; i++)
	{
		if(worker_arr[i].work_begin_date.year == year)
		{
			counter++;
			fprintf(f,"%s\n", worker_to_string(worker_arr[i]));
		}
	}
	
	if (counter == 0)
	{
		fprintf(f, "No matches!\n");
	}
	else
	{
		fprintf(f, "\n%d matches found\n",counter);
	}
}


WORKER* read(FILE* f, unsigned int* size)
{
	*size = 0;
	WORKER* worker_arr = (WORKER*)calloc(20,sizeof(WORKER));

	if (f != NULL)
	{
		while (!feof(f))
		{
			fscanf(f, "%s", &worker_arr[*size].first_name);
			fscanf(f, "%s", &worker_arr[*size].last_name);
			fscanf(f, "%s", &worker_arr[*size].patronymic);
			fscanf(f, "%d", &worker_arr[*size].home_address.post_index);
			fscanf(f, "%s", &worker_arr[*size].home_address.country);
			fscanf(f, "%s", &worker_arr[*size].home_address.region);
			fscanf(f, "%s", &worker_arr[*size].home_address.area);
			fscanf(f, "%s", &worker_arr[*size].home_address.city);
			fscanf(f, "%s", &worker_arr[*size].home_address.street);
			fscanf(f, "%d", &worker_arr[*size].home_address.home_number);
			fscanf(f, "%d", &worker_arr[*size].home_address.flat_number);
			fscanf(f, "%s", &worker_arr[*size].nationality);
			fscanf(f, "%d", &worker_arr[*size].birthday_date.day);
			fscanf(f, "%d", &worker_arr[*size].birthday_date.month);
			fscanf(f, "%d", &worker_arr[*size].birthday_date.year);
			fscanf(f, "%d", &worker_arr[*size].workshop_number);
			fscanf(f, "%d", &worker_arr[*size].table_number);
			fscanf(f, "%s", &worker_arr[*size].education);
			fscanf(f, "%d", &worker_arr[*size].work_begin_date.day);
			fscanf(f, "%d", &worker_arr[*size].work_begin_date.month);
			fscanf(f, "%d", &worker_arr[*size].work_begin_date.year);
			(*size)++;
		}
		
		return worker_arr;
	}
}

char* worker_to_string(WORKER worker)
{
	char* buff = (char*)malloc(sizeof(char) * 1000);
	
	sprintf(buff, 
		"\t***Person info***\n"
		"Name: %s\tLast name: %s\tpatronymic: %s\n"
		"Birthday: %d/%d/%d\n"
		"\t***Address info***\n"
		"Country: %s\tCity: %s\tRegion: %s\t Area:%s\n"
		"Street: %s %d-%d\n"
		"Postal code: %d\n"
		"Nationality: %s\n"
		"\t***Job information***\n"
		"Workshop number: %d\tCard number: %d\tEducation: %s\n"
		"Start working date: %d/%d/%d\n",
		worker.first_name, worker.last_name, worker.patronymic,
		worker.birthday_date.day, worker.birthday_date.month, worker.birthday_date.year,
		worker.home_address.country, worker.home_address.city, worker.home_address.region ,worker.home_address.area,
		worker.home_address.street, worker.home_address.home_number, worker.home_address.flat_number,
		worker.home_address.post_index,
		worker.nationality,
		worker.workshop_number,worker.table_number ,worker.education,
		worker.work_begin_date.day,worker.work_begin_date.month, worker.work_begin_date.year
	);

	return buff;
}
