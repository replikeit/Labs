#pragma warning(disable : 4996)
#include "inquiries.h"
#include "functions.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void authentication(sqlite3* db, CREW_MEMBER* user)
{
	char* login = (char*)malloc(20);
	char* pass = (char*)malloc(20);
	while (1)
	{
		printf("Login: ");
		scanf("%s", login);
		printf("Password: ");
		scanf("%s", pass);

		if (check_login(db, login, pass, user) != TRUE)
		{
			printf("[WRONG LOGIN OR PASSWORD!]\n"
				"[Please repeat]\n");
		}
		else
		{
			break;
		}
	}
}

void preview_for_pilot(sqlite3* db, CREW_MEMBER user)
{
	printf("\n[Total hours after overhaul]\n");
	int hours_after_overhaul = get_hours_after_overhaul(db,user.helicopters_id);
	printf("Helicopter with identifier %d: %d\n", user.helicopters_id, hours_after_overhaul);
	
	printf("\n[Flights info]\n");
	int p1, p2;
	printf("Input period: ");
	scanf("%d-%d", &p1, &p2);
	int size;
	FLIGHTS_INFO* info_arr = get_flight_info_over_per(db, user.helicopters_id, p1, p2, &size);
	if (size != 0)
	{
		printf("Flights info by helicopter with identifier %d:\n", user.helicopters_id);
		for (int i = 0; i < size; i++)
		{
			printf("\tInfo about flight with identifier %d: Cargo weight - %d, People count - %d\n",
				info_arr[i].id, info_arr[i].cargo_weight, info_arr[i].people_count);
		}
	}
	else
	{
		printf("Nothing found for this period.\n");
	}

	printf("\n[Pilot flights info]\n");
	info_arr = get_flight_info(db, user.helicopters_id, &size);
	if (size != 0)
	{
		printf("Flights info by %s(%d - id):\n", user.second_name, user.id);
		for (int i = 0; i < size; i++)
		{
			char flight_type[20];
			(info_arr[i].flight_type == 1) ? strcpy(flight_type, "Common") : strcpy(flight_type, "Special");
			printf("\tInfo about flight with identifier %d: Helicopter id - %d, Fight type - %s, Date - %d, "
				"Cargo weight - %d, People count - %d, Duration - %d, Cost - %d\n",
				info_arr[i].id, info_arr[i].helicopters_id, flight_type, info_arr[i].date, info_arr[i].cargo_weight,
				info_arr[i].people_count, info_arr[i].duration, info_arr[i].cost);
		}
	}
	else
	{
		printf("Nothing found.\n");

	}
	
	printf("\n[Pilot wage]\n");
	printf("Payment for all flights by %s(%d - id): %d\n",user.second_name,user.id, get_wage_by_id(db, user.helicopters_id));

	printf("\n[Pilot wage for period and indicated flight]\n");
	printf("Input period: ");
	scanf("%d-%d", &p1, &p2);
	printf("Payment for the period %s(%d - id): %d\n", user.second_name, user.id, get_wage_by_over_per(db, user.helicopters_id, p1, p2));
	
}

void preview_for_admin(sqlite3* db, CREW_MEMBER user)
{
	int helicopter_count;
	int* hel_ids = get_helicopters_ids(db, &helicopter_count);
	printf("\n[Total hours after overhaul]\n");
	for (int i = 0; i < helicopter_count; i++)
	{
		printf("Helicopter with identifier %d: %d\n", hel_ids[i], get_hours_after_overhaul(db, hel_ids[i]));
	}

	printf("\n[Flights info]\n");
	int p1, p2;
	printf("Input period: ");
	scanf("%d-%d", &p1, &p2);
	for (int i = 0; i < helicopter_count; i++)
	{
		int size;
		FLIGHTS_INFO* info_arr = get_flight_info_over_per(db, hel_ids[i], p1, p2, &size);
		if (size != 0)
		{
			printf("Flights info by helicopter with identifier %d:\n", hel_ids[i]);
			for (int i = 0; i < size; i++)
			{
				printf("\tInfo about flight with identifier %d: Cargo weight - %d, People count - %d\n",
					info_arr[i].id, info_arr[i].cargo_weight, info_arr[i].people_count);
			}
		}
		else
		{
			printf("Nothing found for this period for %d helicopter.\n", hel_ids[i]);
		}
	}

	printf("\n[General info about special fights]\n");
	for (int i = 0; i < helicopter_count; i++)
	{
		GENERAL_HELICOPTER_INFO gen = get_general_helicopter_info(db, hel_ids[i], 2);
		printf("General info about special by %d helicopter: count - %d, wage - %d, weight - %d\n",
			hel_ids[i], gen.count, gen.wage, gen.weight);
	}

	printf("\n[General info about common fights]\n");
	for (int i = 0; i < helicopter_count; i++)
	{
		GENERAL_HELICOPTER_INFO gen = get_general_helicopter_info(db, hel_ids[i], 1);
		printf("General info about common by %d helicopter: count - %d, wage - %d, weight - %d\n",
			hel_ids[i], gen.count, gen.wage, gen.weight);
	}

	printf("\n[Helicopter completed the maximum number of flights]\n");
	int max_fights = 0;
	int max_fights_helicopter = 0;
	for (int i = 0; i < helicopter_count; i++)
	{
		if (get_helicopter_fights_count(db, hel_ids[i]) > max_fights)
		{
			max_fights_helicopter = hel_ids[i];
		}
	}
	printf("Maximum number of flights have %d helicopter\n", max_fights_helicopter);
	printf("Crew info:\n");
	int size;
	int wage = 0;
	CREW_MEMBER* crew_arr = get_crew_by_helicopter_id(db, max_fights_helicopter, &size);
	for (int i = 0; i < size; i++)
	{
		printf("\tId - %d Name - %s\n", crew_arr[i].id, crew_arr[i].second_name);
		wage += get_wage_by_id(db, crew_arr[i].helicopters_id);
	}
	printf("\tTotal wage: %d\n", wage);

	printf("\n[Crew earned the maximum amount of money]\n");
	int max_wage = 0;
	int max_wage_hel_id = 0;
	for (int i = 0; i < helicopter_count; i++)
	{
		int wage = get_wage_by_id(db, hel_ids[i]);
		if (wage > max_wage)
		{
			max_wage_hel_id = hel_ids[i];
			max_wage = wage;
		}
	}
	FLIGHTS_INFO* info_arr = get_flight_info(db, max_wage_hel_id, &size);
	if (size != 0)
	{
		printf("The crew of the %d-st helicopter earned the most, its salary - %d\n"
			"Flights info:\n", max_wage_hel_id, max_wage);
		for (int i = 0; i < size; i++)
		{
			char flight_type[20];
			(info_arr[i].flight_type == 1) ? strcpy(flight_type, "Common") : strcpy(flight_type, "Special");
			printf("\tInfo about flight with identifier %d: Helicopter id - %d, Fight type - %s, Date - %d, "
				"Cargo weight - %d, People count - %d, Duration - %d, Cost - %d\n",
				info_arr[i].id, info_arr[i].helicopters_id, flight_type, info_arr[i].date, info_arr[i].cargo_weight,
				info_arr[i].people_count, info_arr[i].duration, info_arr[i].cost);
		}
	}

	printf("\n[Flight crew information]\n");
	printf("Input crew helicopter id: ");
	int id;
	scanf("%d", &id);
	crew_arr = get_crew_by_helicopter_id(db, max_fights_helicopter, &size);
	if(size != 0)
	{
		printf("Crew members: %s(id - %d)", crew_arr[0].second_name, crew_arr[0].id);
		for (int i = 1; i < size; i++)
		{
			printf(" ,%s(id - %d)", crew_arr[i].second_name, crew_arr[i].id);
		}
		printf(".\n");
		info_arr = get_flight_info(db, id, &size);
		if (size != 0)
		{
			printf("Flights info:\n");
			for (int i = 0; i < size; i++)
			{
				char flight_type[20];
				(info_arr[i].flight_type == 1) ? strcpy(flight_type, "Common") : strcpy(flight_type, "Special");
				printf("\tInfo about flight with identifier %d: Helicopter id - %d, Fight type - %s, Date - %d, "
					"Cargo weight - %d, People count - %d, Duration - %d, Cost - %d\n",
					info_arr[i].id, info_arr[i].helicopters_id, flight_type, info_arr[i].date, info_arr[i].cargo_weight,
					info_arr[i].people_count, info_arr[i].duration, info_arr[i].cost);
			}
		}
	}
	else
	{
		printf("Crew not found.\n");
	}
	
}

HELICOPTER_INFO get_helicopter_info()
{
	HELICOPTER_INFO result;
	printf("Input id: ");
	scanf("%d", &result.id);
	printf("Helicopter brand id: ");
	scanf("%d", &result.helicopter_brand);
	printf("Input creating date: ");
	scanf("%d", &result.creation_date);
	printf("Input carrying capacity: ");
	scanf("%d", &result.carrying_capacity);
	printf("Input last overhaul date: ");
	scanf("%d", &result.last_overhaul_date);
	printf("Input fight_resource: ");
	scanf("%d", &result.flight_resource);
	return result;
}

CREW_MEMBER get_crew_member_info()
{
	CREW_MEMBER result;
	printf("Input id: ");
	scanf("%d", &result.id);
	printf("Crew positions id: ");
	scanf("%d", &result.crew_positions_id);
	printf("Input helicopters id: ");
	scanf("%d", &result.helicopters_id);
	printf("Input second name: ");
	scanf("%s", &result.second_name);
	printf("Input work experience: ");
	scanf("%d", &result.work_experience);
	printf("Input address: ");
	scanf("%s", &result.address);
	printf("Input birthday: ");
	scanf("%d", &result.birthday);
	printf("Input login: ");
	scanf("%s", &result.login);
	printf("Input password: ");
	scanf("%s", &result.pass);
	return  result;
}

FLIGHTS_INFO get_flights_info()
{
	FLIGHTS_INFO result;
	printf("Input id: ");
	scanf("%d", &result.id);
	printf("Crew helicopters id: ");
	scanf("%d", &result.helicopters_id);
	printf("Input flight id: ");
	scanf("%d", &result.flight_type);
	printf("Input date: ");
	scanf("%s", &result.date);
	printf("Input cargo weight: ");
	scanf("%d", &result.cargo_weight);
	printf("Input people count: ");
	scanf("%s", &result.people_count);	
	printf("Input duration: ");
	scanf("%s", &result.duration);
	printf("Input cost: ");
	scanf("%s", &result.cost);
	return  result;
}

BOOL check_resource_time(sqlite3* db, int id, int duration)
{
	int resource = get_resource_time(db, id);
	if (resource < duration)
	{
		return FALSE;
	}
	return TRUE;
}

void insert(sqlite3* db)
{
	printf("[Select table]\n");
	printf("1 - Helicopters, 2 - Crew Members 3 - Flights 4 - Back\n");
	int table;
	scanf("%d", &table);
	switch (table)
	{
	case 1:
		printf("[Input data]\n");
		HELICOPTER_INFO hel_info = get_helicopter_info();
		insert_helicopter(db, hel_info);
		break;
	case 2:
		printf("[Input data]\n");
		CREW_MEMBER crew_info = get_crew_member_info();
		insert_crew_member(db, crew_info);
		break;
	case 3:
		printf("[Input data]\n");
		FLIGHTS_INFO flights_info = get_flights_info();
		if (check_resource_time(db, flights_info.id, flights_info.duration) == FALSE)
		{
			printf("Error: Temporary resource exceeded");
		}
		else
		{
			insert_flights(db, flights_info);
		}
		break;
	case 4:
		return;
	default:
		printf("Wrong Number!\n"
					"Try Again.");
		insert(db);
		break;
	}
}

void update(sqlite3* db)
{
	printf("[Select table]\n");
	printf("1 - Helicopters, 2 - Crew Members 3 - Flights 4 - Back\n");
	int table;
	scanf("%d", &table);
	int col, id;
	switch (table)
	{
	case 1:
		printf("[Input column]\n");
		printf("1 - ID,2 - Helicopter Brand ID, 3 - Creation Date, 4 - Carrying Capacity,\n"
				"5 - Last Overhaul Date, 6 - Flight Resource\n");
		scanf("%d", &col);
		if (col < 1 && col > 6)
		{
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		printf("Input id: ");
		scanf("%d", &id);
		int helicopter_value;
		printf("Input value for update: ");
		scanf("%d", &helicopter_value);
		
		switch (col)
		{
		case 1:
			update_column_int(db, "Helicopters", "ID", id, helicopter_value);
			break;
		case 2:
			update_column_int(db, "Helicopters", "HelicopterBrands_ID", id, helicopter_value);
			break;
		case 3:
			update_column_int(db, "Helicopters", "CreationDate", id, helicopter_value);
			break;
		case 4:
			update_column_int(db, "Helicopters", "CarryingCapacity", id, helicopter_value);
			break;
		case 5:
			update_column_int(db, "Helicopters", "LastOverhaulDate", id, helicopter_value);
			break;
		case 6:
			update_column_int(db, "Helicopters", "FlightResource", id, helicopter_value);
			break;
			
		default:
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		
		break;
	case 2:
		printf("[Input column]\n");
		printf("1 - ID,2 - Crew Position ID, 3 - Helicopter ID, 4 - Work Experience,\n"
			"5 - Birth Day, 6 - Second Name, 7 - Address, 8 - Login, 9 - Password\n");
		scanf("%d", &col);
		int crew_member_value_int;
		char* crew_member_value_str = (char*)malloc(30);
		if (col < 1 && col > 8)
		{
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		else if (col >= 1 && col <= 5)
		{
			printf("Input value for update: ");
			scanf("%d", &crew_member_value_int);
		}
		else
		{
			printf("Input value for update: ");
			scanf("%s", crew_member_value_str);
		}
		printf("Input id: ");
		scanf("%d", &id);
		
		switch (col)
		{
		case 1:
			update_column_int(db, "CrewMembers", "ID", id, crew_member_value_int);
			break;
		case 2:
			update_column_int(db, "CrewMembers", "CrewPositions_ID", id, crew_member_value_int);
			break;
		case 3:
			update_column_int(db, "CrewMembers", "Helicopters_ID", id, crew_member_value_int);
			break;
		case 4:
			update_column_int(db, "CrewMembers", "WorkExperience", id, crew_member_value_int);
			break;
		case 5:
			update_column_int(db, "CrewMembers", "BirthYear", id, crew_member_value_int);
			break;
		case 6:
			update_column_text(db, "CrewMembers", "SecondName", id, crew_member_value_str);
			break;
		case 7:
			update_column_int(db, "CrewMembers", "Login", id, crew_member_value_str);
			break;
		case 8:
			update_column_int(db, "CrewMembers", "Password", id, crew_member_value_str);
			break;
		default:
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		break;
	case 3:
		printf("[Input column]\n");
		printf("1 - ID,2 - Helicopter ID, 3 - Flight Type ID, 4 - Date,\n"
			"5 - Cargo Weight, 6 - People Count, 7 - Duration, 8 - Cost\n");
		scanf("%d", &col);
		if (col < 1 && col > 8)
		{
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		printf("Input id: ");
		scanf("%d", &id);
		int flights_value;
		printf("Input value for update: ");
		scanf("%d", &flights_value);

		switch (col)
		{
		case 1:
			update_column_int(db, "Flights", "ID", id, flights_value);
			break;
		case 2:
			update_column_int(db, "Flights", " Helicopters_ID", id, flights_value);
			break;
		case 3:
			update_column_int(db, "Flights", "FlightTypes_ID", id, flights_value);
			break;
		case 4:
			update_column_int(db, "Flights", "Date", id, flights_value);
			break;
		case 5:
			update_column_int(db, "Flights", "CargoWeight", id, flights_value);
			break;
		case 6:
			update_column_int(db, "Flights", "PeopleCount", id, flights_value);
			break;
		case 7:
			if (check_resource_time(db, id, flights_value) == FALSE)
			{
				printf("Error: Temporary resource exceeded");
			}
			else
			{
				update_column_int(db, "Flights", "Duration", id, flights_value);
			}
			break;
		case 8:
			update_column_int(db, "Flights", "Cost", id, flights_value);
			break;
		default:
			printf("Wrong Number!\n"
				"Try Again.");
			update(db);
			return;
		}
		break;
	case 4:
		return;
	default:
		printf("Wrong Number!\n"
			"Try Again.");
		update(db);
		return;
	}
}

void delete(sqlite3* db)
{
	printf("[Select table]\n");
	printf("1 - Helicopters, 2 - Crew Members 3 - Flights 4 - Back\n");
	int table;
	scanf("%d", &table);
	int id;
	switch (table)
	{
	case 1:
		printf("Input id: ");
		scanf("%d", &id);
		delete_row(db, "Helicopters", id);
		break;
	case 2:
		printf("Input id: ");
		scanf("%d", &id);
		delete_row(db, "CrewMembers", id);
		break;
	case 3:
		printf("Input id: ");
		scanf("%d", &id);
		delete_row(db, "Flights", id);
		break;
	case 4:
		return;
	default:
		printf("Wrong Number!\n"
			"Try Again.");
		delete(db);
		break;
	}
}