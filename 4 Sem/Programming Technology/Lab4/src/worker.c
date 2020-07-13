#include "worker.h"
#include "string.h"
#include "stdlib.h"
#include "stdio.h"
#include "sqlite3.h"


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
			fscanf(f, "%d", &worker_arr[*size].wage);

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

void insert(sqlite3* db, WORKER worker)
{
	char* sql = (char*)malloc(500);

	char* err_msg = 0;
	char* pattern =
		"insert into workers (first_name, last_name, patronymic, postal_code, country,region ,city,"
		"street, home_number,flat_number, nationality, birth, department_id, card_number, education, start_working_date, wage)"
		"values('%s', '%s', '%s', %d, '%s', '%s', '%s', '%s',"
				"%d, %d, '%s', %d, %d, %d, '%s', %d, %d);";
	
	int birthday = worker.birthday_date.year * 10000 + worker.birthday_date.month * 100 + worker.birthday_date.day;
	int start_working_date = worker.work_begin_date.year * 10000 + worker.work_begin_date.month * 100 + worker.work_begin_date.day;

	sprintf(sql,pattern, worker.first_name, worker.last_name, worker.patronymic, worker.home_address.post_index,
	worker.home_address.country, worker.home_address.region, worker.home_address.city,
	worker.home_address.street, worker.home_address.home_number, worker.home_address.flat_number,
	worker.nationality, birthday, worker.workshop_number, worker.table_number, worker.education, start_working_date, worker.wage);
	
	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
		sqlite3_close(db);
	}
}

void select_all(sqlite3* db)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT * FROM workers";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	while (sqlite3_step(res) == 100)
	{
		printf("%s", sqlite3_column_text(res, 0));
		for (unsigned int i = 1; ; i++)
		{
			if (sqlite3_column_text(res, i) == 0)
				break;
			printf("|%s", sqlite3_column_text(res, i));
		}
		printf("\n");
	}
	sqlite3_finalize(res);
}

void select_by_id(sqlite3* db, int selected_id)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT * FROM workers WHERE id = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0) 
	{
		sqlite3_bind_int(res, 1, selected_id);
	}
	else
	{

		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;
	}

	while (sqlite3_step(res) == 100)
	{
		printf("%s", sqlite3_column_text(res, 0));
		for (unsigned int i = 1; ; i++)
		{
			if (sqlite3_column_text(res, i) == 0)
				break;
			printf("|%s", sqlite3_column_text(res, i));
		}
		printf("\n");
	}
	
	sqlite3_finalize(res);
}

void select_by_last_name(sqlite3* db, const char* selected_name)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT * FROM workers WHERE last_name = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_text(res, 1, selected_name, strlen(selected_name), NULL);
	}
	else 
	{

		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;

	}

	while (sqlite3_step(res) == 100)
	{
		printf("%s", sqlite3_column_text(res, 0));
		for (unsigned int i = 1; ; i++)
		{
			if (sqlite3_column_text(res, i) == 0)
				break;
			printf("|%s", sqlite3_column_text(res, i));
		}
		printf("\n");
	}
	
	sqlite3_finalize(res);
}

void select_by_department_id(sqlite3* db, int selected_id)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT * FROM workers WHERE department_id = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0) 
	{
		sqlite3_bind_int(res, 1, selected_id);
	}
	else 
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;
	}

	while(sqlite3_step(res) == 100)
	{
		printf("%s", sqlite3_column_text(res, 0));
		for (unsigned int i = 1; ;i++)
		{
			if (sqlite3_column_text(res, i) == 0)
				break;
			printf("|%s", sqlite3_column_text(res,i));
		}
		printf("\n");
	}
	
	sqlite3_finalize(res);
}

void delete_all(sqlite3* db)
{
	char* err_msg = 0;
	char* sql = "DELETE FROM workers";

	int rc = sqlite3_exec(db, sql, 0, 0, err_msg);

}

void delete_by_id(sqlite3* db, int selected_id)
{
	char* sql = (char*)malloc(255);
	char* err_msg = 0;
	char* pattern = "DELETE FROM workers WHERE id = %d";

	sprintf(sql, pattern, selected_id);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
		sqlite3_close(db);
	}
}

void delete_by_last_name(sqlite3* db, const char* selected_name)
{
	char* sql = (char*)malloc(255);
	char* err_msg = 0;
	char* pattern = "DELETE FROM workers WHERE last_name = %s";

	sprintf(sql, pattern, selected_name);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
		sqlite3_close(db);
	}
}

void delete_by_department_id(sqlite3* db, int selected_id)
{
	char* sql = (char*)malloc(255);
	char* err_msg = 0;
	char* pattern = "DELETE FROM workers WHERE department_id = %d";

	sprintf(sql, pattern, selected_id);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
		sqlite3_close(db);
	}
}

void out_image(sqlite3* db, int selected_id)
{
	char* buf = (char*)malloc(255);
	sprintf(buf,"image_%d-st_id_worker.jpg", selected_id);
	FILE* fp = fopen(buf, "wb");

	if (fp == NULL) {

		fprintf(stderr, "Cannot open image file\n");

		return;

	}

	char* err_msg = 0;
	char* sql = (char*)malloc(255);
	char* pattern = "SELECT img FROM images WHERE id = %d";
	sprintf(sql, pattern, selected_id);

	sqlite3_stmt* res;
	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "Failed to prepare statement\n");
		fprintf(stderr, "Cannot open database: %s\n", sqlite3_errmsg(db));

		sqlite3_bind_int(res, 1, selected_id);
		sqlite3_close(db);
		return;

	}

	rc = sqlite3_step(res);

	int bytes = 0;

	if (rc == SQLITE_ROW) {

		bytes = sqlite3_column_bytes(res, 0);
		return;

	}

	fwrite(sqlite3_column_blob(res, 0), bytes, 1, fp);

	if (ferror(fp)) {

		fprintf(stderr, "fwrite() failed\n");
		return;

	}

	int r = fclose(fp);

	if (r == EOF) {
		fprintf(stderr, "Cannot close file handler\n");
		return;

	}

	rc = sqlite3_finalize(res);

	sqlite3_close(db);

}

void in_image(sqlite3* db)
{
	FILE* fp = fopen("in.jpg", "rb");

	if (fp == NULL) {

		fprintf(stderr, "Cannot open image file\n");
		return;

	}

	fseek(fp, 0, SEEK_END);

	if (ferror(fp)) {

		fprintf(stderr, "fseek() failed\n");
		int r = fclose(fp);

		return;
	}

	int flen = ftell(fp);

	if (flen == -1) {

		perror("error occurred");
		int r = fclose(fp);

		if (r == EOF) {
			fprintf(stderr, "Cannot close file handler\n");
		}

		return;
	}

	fseek(fp, 0, SEEK_SET);

	if (ferror(fp)) {

		fprintf(stderr, "fseek() failed\n");
		int r = fclose(fp);

		if (r == EOF) {
			fprintf(stderr, "Cannot close file handler\n");
		}

	}

	char data = (char*)malloc(flen + 1);

	int size = fread(data, 1, flen, fp);

	if (ferror(fp)) {

		fprintf(stderr, "fread() failed\n");
		int r = fclose(fp);

		if (r == EOF) {
			fprintf(stderr, "Cannot close file handler\n");
		}

		return;
	}

	int r = fclose(fp);

	if (r == EOF) {
		fprintf(stderr, "Cannot close file handler\n");
	}


	char* err_msg = 0;

	sqlite3_stmt* pStmt;
	
	char* sql = "INSERT INTO images(img) VALUES(?)";

	int rc = sqlite3_prepare(db, sql, -1, &pStmt, 0);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "Cannot prepare statement: %s\n", sqlite3_errmsg(db));

		return;
	}

	sqlite3_bind_blob(pStmt, 1, data, size, SQLITE_STATIC);

	rc = sqlite3_step(pStmt);

	if (rc != SQLITE_DONE) {

		printf("execution failed: %s", sqlite3_errmsg(db));
		return;
	}

	sqlite3_finalize(pStmt);

	sqlite3_close(db);
}



