#pragma once
#include "sqlite3.h"
#include "functions.h"

BOOL check_login(sqlite3* db, char* login, char* pass, CREW_MEMBER* crew_member);
int get_hours_after_overhaul(sqlite3* db, int selected_id);
FLIGHTS_INFO* get_flight_info_over_per(sqlite3* db, int selected_id, int p1, int p2,int* size);
FLIGHTS_INFO* get_flight_info(sqlite3* db, int selected_id, int* size);
int get_wage_by_id(sqlite3* db, int selected_id);
int get_wage_by_over_per(sqlite3* db, int selected_id, int p1, int p2);
int* get_helicopters_ids(sqlite3* db, int* size);
GENERAL_HELICOPTER_INFO get_general_helicopter_info(sqlite3* db,int selected_id , int type);
int get_helicopter_fights_count(sqlite3* db, int selected_id);
int get_helicopter_wage(sqlite3* db, int selected_id);
CREW_MEMBER* get_crew_by_helicopter_id(sqlite3* db,int selected_id ,int* size);
void insert_helicopter(sqlite3* db, HELICOPTER_INFO helicopter);
void insert_crew_member(sqlite3* db, CREW_MEMBER member);
void insert_flights(sqlite3* db, FLIGHTS_INFO flight);
int get_resource_time(sqlite3* db, int id);
void update_column_int(sqlite3* db, char* table, char* column, int selected_id, int value);
void update_column_text(sqlite3* db, char* table, char* column, int selected_id, char* value);
void delete_row(sqlite3* db, char* table, int selected_id);
