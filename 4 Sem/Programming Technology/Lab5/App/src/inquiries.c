#pragma warning(disable : 4996)
#include "inquiries.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "sqlite3.h"


BOOL check_login(sqlite3* db, char* login, char* pass, CREW_MEMBER* crew_member)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT * FROM CrewMembers WHERE Login = ? and Password = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_text(res, 1, login, strlen(login), NULL);
		sqlite3_bind_text(res, 2, pass, strlen(pass), NULL);

	}
	else
	{

		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return FALSE;

	}

	if (sqlite3_step(res) == 100)
	{
		(*crew_member).id = sqlite3_column_int(res,0);
		(*crew_member).crew_positions_id = sqlite3_column_int(res, 1);
		(*crew_member).helicopters_id = sqlite3_column_int(res, 2);
		strcpy((*crew_member).second_name, sqlite3_column_text(res, 3));
		(*crew_member).work_experience = sqlite3_column_int(res, 4);
		strcpy((*crew_member).address, sqlite3_column_text(res, 5));
		(*crew_member).birthday = sqlite3_column_int(res, 6);

		sqlite3_finalize(res);

		return TRUE;
	}
	else
	{
		sqlite3_finalize(res);
		
		return FALSE;
	}

}

int get_hours_after_overhaul(sqlite3* db, int selected_id)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT SUM(Duration) FROM Flights WHERE Helicopters_ID = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_int(res, 1, selected_id);


	}
	else
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return FALSE;

	}

	if (sqlite3_step(res) == 100)
	{
		int hours = sqlite3_column_int(res, 0);
		sqlite3_finalize(res);
		
		return hours;
	}
	else
	{
		
		sqlite3_finalize(res);

		return 0;
	}
	
	return 0;
}

FLIGHTS_INFO* get_flight_info_over_per(sqlite3* db, int selected_id, int p1, int p2, int* size)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	*size = 0;
	char* sql = "SELECT ID,CargoWeight,PeopleCount FROM Flights WHERE Helicopters_ID = ? and Date >= ? and Date <= ?";
	FLIGHTS_INFO* arr = (FLIGHTS_INFO*)malloc(50 * sizeof(FLIGHTS_INFO));
	
	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_int(res, 1, selected_id);
		sqlite3_bind_int(res, 2, p1);
		sqlite3_bind_int(res, 3, p2);
	}
	else
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;

	}

	
	while (sqlite3_step(res) == 100)
	{
		arr[*size].id = sqlite3_column_int(res, 0);
		arr[*size].cargo_weight = sqlite3_column_int(res, 1);
		arr[*size].people_count = sqlite3_column_int(res, 2);

		(*size)++;

	}

	return arr;
}

FLIGHTS_INFO* get_flight_info(sqlite3* db, int selected_id, int* size)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	*size = 0;
	char* sql = "SELECT * FROM Flights WHERE Helicopters_ID = ?";
	FLIGHTS_INFO* arr = (FLIGHTS_INFO*)malloc(50 * sizeof(FLIGHTS_INFO));

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
		arr[*size].id = sqlite3_column_int(res, 0);
		arr[*size].helicopters_id = sqlite3_column_int(res, 1);
		arr[*size].flight_type = sqlite3_column_int(res, 2);
		arr[*size].date= sqlite3_column_int(res, 3);
		arr[*size].cargo_weight = sqlite3_column_int(res, 4);
		arr[*size].people_count = sqlite3_column_int(res, 5);
		arr[*size].duration = sqlite3_column_int(res, 6);
		arr[*size].cost = sqlite3_column_int(res, 6);

		(*size)++;

	}

	return arr;
}

int get_wage_by_id(sqlite3* db, int selected_id)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT FlightTypes_ID,Cost FROM Flights WHERE Helicopters_ID = ?";

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

	int wage = 0;
	while (sqlite3_step(res) == 100)
	{
		if (sqlite3_column_int(res, 0) == 1)
		{
			wage += sqlite3_column_int(res, 1) / 20;
		}
		else
		{
			wage += sqlite3_column_int(res, 1) / 10;
		}
	}

	return wage;
}

int get_wage_by_over_per(sqlite3* db, int selected_id, int p1, int p2)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT FlightTypes_ID,Cost FROM Flights WHERE Helicopters_ID = ? and Date >= ? and Date <= ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_int(res, 1, selected_id);
		sqlite3_bind_int(res, 2, p1);
		sqlite3_bind_int(res, 3, p2);
	}
	else
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;

	}


	int wage = 0;
	while (sqlite3_step(res) == 100)
	{
		if (sqlite3_column_int(res, 0) == 1)
		{
			wage += sqlite3_column_int(res, 1) / 20;
		}
		else
		{
			wage += sqlite3_column_int(res, 1) / 10;
		}
	}

	return wage;
}

int* get_helicopters_ids(sqlite3* db, int* size)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	*size = 0;
	char* sql = "SELECT ID FROM Helicopters";
	int* arr = (int*)malloc(50*sizeof(int));
	
	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc != 0)
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return NULL;	
	}


	while (sqlite3_step(res) == 100)
	{
		arr[*size] = sqlite3_column_int(res, 0);
		
		(*size)++;
	}

	return arr;
}

GENERAL_HELICOPTER_INFO get_general_helicopter_info(sqlite3* db, int selected_id,int type)
{
	GENERAL_HELICOPTER_INFO result;
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT count(*),sum(CargoWeight),sum(Cost) FROM Flights WHERE FlightTypes_ID = ? and Helicopters_ID = ?";

	int rc = sqlite3_prepare_v2(db, sql, -1, &res, 0);
	if (rc == 0)
	{
		sqlite3_bind_int(res, 1, type);
		sqlite3_bind_int(res, 2, selected_id);

	}
	else
	{

		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));
		return;

	}

	if (sqlite3_step(res) == 100)
	{
		result.count = sqlite3_column_int(res, 0);
		result.weight= sqlite3_column_int(res, 1);
		result.wage = sqlite3_column_int(res, 2);
	}
	
	sqlite3_finalize(res);
	return result;
	
}

int get_helicopter_fights_count(sqlite3* db, int selected_id)
{
	int result = 0;
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT count(*) FROM Flights WHERE Helicopters_ID = ?";
	
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

	if (sqlite3_step(res) == 100)
	{
		result = sqlite3_column_int(res, 0);
	}

	sqlite3_finalize(res);
	return result;
}

int get_helicopter_wage(sqlite3* db, int selected_id)
{
	int result = 0;
	char* err_msg = 0;
	sqlite3_stmt* res;
	char* sql = "SELECT sum(Cost) FROM Flights WHERE Helicopters_ID = ?";

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

	if (sqlite3_step(res) == 100)
	{
		result = sqlite3_column_int(res, 0);
	}

	sqlite3_finalize(res);
	return result;
}

CREW_MEMBER* get_crew_by_helicopter_id(sqlite3* db, int selected_id, int* size)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	*size = 0;
	char* sql = "SELECT * FROM CrewMembers WHERE Helicopters_ID = ?";
	CREW_MEMBER* arr = (CREW_MEMBER*)malloc(50 * sizeof(CREW_MEMBER));
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
		arr[*size].id = sqlite3_column_int(res, 0);
		arr[*size].crew_positions_id = sqlite3_column_int(res, 1);
		arr[*size].helicopters_id = sqlite3_column_int(res, 2);
		strcpy((arr[*size]).second_name, sqlite3_column_text(res, 3));
		(arr[*size]).work_experience = sqlite3_column_int(res, 4);
		strcpy((arr[*size]).address, sqlite3_column_text(res, 5));
		(arr[*size]).birthday = sqlite3_column_int(res, 6);
		(*size)++;
	}
	
	return arr;
}

void insert_helicopter(sqlite3* db, HELICOPTER_INFO helicopter)
{
	char* sql = (char*)malloc(500);

	char* err_msg = 0;
	char* pattern =
		"insert into Helicopters (ID, HelicopterBrands_ID, CreationDate, CarryingCapacity, LastOverhaulDate, FlightResource)"
		"values(%d, %d, %d, %d, %d, %d)";

	sprintf(sql, pattern, helicopter.id, helicopter.helicopter_brand, helicopter.creation_date, helicopter.carrying_capacity,
		helicopter.last_overhaul_date, helicopter.flight_resource);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
	}
}

void insert_crew_member(sqlite3* db, CREW_MEMBER member)
{
	char* sql = (char*)malloc(500);

	char* err_msg = 0;
	char* pattern =
		"insert into Helicopters (ID, CrewPositions_ID, Helicopters_ID, SecondName, WorkExperience, Address, BirthYear, Login, Password)"
		"values(%d, %d, %d, '%s', %d, '%s', %d, '%s','%s')";

	sprintf(sql, pattern, member.id, member.crew_positions_id, member.helicopters_id, member.second_name,
			member.work_experience, member.work_experience, member.address, member.birthday, member.login, member.pass);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
	}
}

void insert_flights(sqlite3* db, FLIGHTS_INFO flight)
{
	char* sql = (char*)malloc(500);

	char* err_msg = 0;
	char* pattern =
		"insert into Helicopters (ID, Helicopters_ID, FlightTypes_ID, Date, CargoWeight, PeopleCount, Duration, Cost)"
		"values(%d, %d, %d, %d, %d, %d, %d, %d, %d)";

	sprintf(sql, pattern, flight.id, flight.helicopters_id, flight.flight_type, flight.date,flight.cargo_weight,
		flight.people_count, flight.duration, flight.cost);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);

	if (rc != SQLITE_OK) {

		fprintf(stderr, "SQL error: %s\n", err_msg);

		sqlite3_free(err_msg);
	}
}

int get_resource_time(sqlite3* db, int selected_id)
{
	char* err_msg = 0;
	sqlite3_stmt* res;
	int result = 0;
	char* sql = "SELECT FLightResource FROM Helicopters WHERE ID = ?";
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
		result = sqlite3_column_int(res, 0);
	}

	return result;
}

void update_column_int(sqlite3* db, char* table, char* column, int selected_id, int value)
{
	char* err_msg = 0;

	char* sql = (char*)malloc(50);

	char* pattern = "UPDATE %s SET %s = %d WHERE ID = %d";

	sprintf(sql, pattern, table, column, value, selected_id);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != 0)
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));

	}

}


void update_column_text(sqlite3* db, char* table, char* column, int selected_id, char* value)
{
	char* err_msg = 0;

	char* sql = (char*)malloc(50);

	char* pattern = "UPDATE %s SET %s = %s WHERE ID = %d";

	sprintf(sql, pattern,table ,column , value, selected_id);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != 0)
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));

	}

}

void delete_row(sqlite3* db, char* table,int selected_id)
{
	char* err_msg = 0;

	char* sql = (char*)malloc(50);

	char* pattern = "DELETE FROM %s WHERE ID = %d";

	sprintf(sql, pattern, table, selected_id);

	int rc = sqlite3_exec(db, sql, 0, 0, &err_msg);
	if (rc != 0)
	{
		fprintf(stderr, "Failed to execute statement: %s\n", sqlite3_errmsg(db));

	}
	
}






