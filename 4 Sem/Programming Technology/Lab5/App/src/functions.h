#pragma once
#include "sqlite3.h"

enum _BOOL
{
	FALSE = 0,
	TRUE = 1
} typedef BOOL;

struct _GENERAL_HELICOPTER_INFO
{
	int count;
	int weight;
	int wage;
}typedef GENERAL_HELICOPTER_INFO;

struct _HELICOPTER_INFO
{
	int id;
	int helicopter_brand;
	int creation_date;
	int carrying_capacity;
	int last_overhaul_date;
	int flight_resource;
} typedef HELICOPTER_INFO;

struct _FLIGHTS_INFO
{
	int id;
	int cargo_weight;
	int people_count;
	int date;
	int helicopters_id;
	int flight_type;
	int duration;
	int cost;
} typedef FLIGHTS_INFO;

struct _CREW_MEMBER
{
	int id;
	int crew_positions_id;
	int helicopters_id;
	char second_name[20];
	int work_experience;
	char address[20];
	int birthday;
	char login[20];
	char pass[20];
} typedef CREW_MEMBER;

void authentication(sqlite3* db, CREW_MEMBER* user);
void preview_for_pilot(sqlite3*db, CREW_MEMBER user);
void preview_for_admin(sqlite3* db, CREW_MEMBER user);
void insert(sqlite3* db);
void update(sqlite3* db);
void delete(sqlite3* db);