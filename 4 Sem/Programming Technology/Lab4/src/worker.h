#pragma once
#include "stdio.h"
#include "sqlite3.h"


struct _date
{
	char day;
	char month;
	short year;
} typedef DATE;

struct address
{
	int post_index;
	char country[20];
	char region[20];
	char area[20];
	char city[20];
	char street[20];
	int home_number;
	int flat_number;
} typedef ADDRESS;

struct _worker{
	char first_name[20];
	char last_name[20];
	char patronymic[20];
	ADDRESS home_address;
	char nationality[20];
	DATE birthday_date;
	int workshop_number;
	int table_number;
	char education[20];
	DATE work_begin_date;
	int wage;
} typedef WORKER;


WORKER* read(FILE* f, unsigned int* size);
void out_by_working_started(WORKER* worker_arr, FILE* f, unsigned int size, int year);
char* worker_to_string(WORKER worker);

void insert(sqlite3* db, WORKER  worker);

void select_all(sqlite3* db);
void select_by_id(sqlite3* db, int selected_id);
void select_by_last_name(sqlite3* db, const char* selected_name);
void select_by_department_id(sqlite3* db, int selected_id);

void delete_all(sqlite3* db);
void delete_by_id(sqlite3* db, int selected_id);
void delete_by_last_name(sqlite3* db, const char* selected_name);
void delete_by_department_id(sqlite3* db, int selected_id);

void out_image(sqlite3* db, int selected_id);
void in_image(sqlite3* db);
