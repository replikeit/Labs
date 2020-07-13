#pragma warning(disable : 4996)
#include <stdio.h>
#include <stdlib.h>
#include "sqlite3.h"
#include "inquiries.h"
#include "functions.h"



int main()
{
	CREW_MEMBER user;
	sqlite3* db;
	
	int rc = sqlite3_open("AirDelivery.db", &db);
	
	if (rc != 0)
	{
		fprintf(stderr, "Cannot open database: %s\n", sqlite3_errmsg(db));
		sqlite3_close(db);
		return 1;
	}
	
	printf("[Please do authentication]\n");
	authentication(db, &user);
	if(user.crew_positions_id == 2)
	{
		preview_for_pilot(db, user);
		return 0;
	}
	else
	{
		preview_for_admin(db, user);
		while (1)
		{
			int mode = 0;
			printf("\n[Select mode]\n");
			printf("1 - Insert\t2 - Update\t3 - Delete\t4 - Exit\n");
			scanf("%d", &mode);
			switch (mode)
			{
			case 1:
				insert(db);
				break;
			case 2:
				update(db);
				break;
			case 3:
				delete(db);
				break;
			case 4:
				return 0;
			default:
				printf("Wrong Number!\n"
					"Try Again.");
				break;
			}
		}
	}
}
