#include "stdlib.h"
#include "worker.h"
#include "stdio.h"


int main(int argc, char* argv[])
{

	int autocommit;
	sqlite3* db;
	char* err_msg = 0;
	unsigned int size;
	
	FILE* f = fopen("input.txt", "r");
	WORKER* worker_arr = read(f, &size);
	int rc = sqlite3_open("lab4.db", &db);

	if (rc != 0)
	{
		fprintf(stderr, "Cannot open database: %s\n", sqlite3_errmsg(db));
		sqlite3_close(db);
		return 1;
	}
	
	printf("***Select mode***\n"
		"1 - Transition\t2 - autocommit\n");
	scanf("%d", &autocommit);

	if (autocommit == 1)
	{
		sqlite3_exec(db, "BEGIN TRANSITION", 0, 0, &err_msg);
	}

	while (1)
	{
		int act;
		printf("***Select action***\n"
			"1 - Select\t2 - Insert\t3 - Delete\t4 - Image out\t5 - Image in\t6 - Exit\n");
		scanf("%d", &act);

		if (act == 1 || act == 3)
		{
			
			int param;
			printf("***Select action***\n"
				"1-All\t2-Id\t3-Last name\t4-Department id\n");
			scanf("%d", &param);
			
			switch (param)
			{
			case 1:
				(act == 1) ? select_all(db) : delete_all (db);
				break;
			case 2:
				printf("Input id: ");
				
				int id = 0;
				scanf("%d", &id);
				
				(act == 1) ? select_by_id(db, id) : delete_by_id(db, id);
				break;
			case 3:
				printf("Input last name: ");
				
				char* last_name = (char*)malloc(255);
				scanf("%s", last_name);
				
				(act == 1) ? select_by_last_name(db, last_name) : delete_by_last_name(db, last_name);
				break;
			case 4:
				printf("Input department id: ");
				
				int dep_id = 0;
				scanf("%d", &dep_id);
				
				(act == 1) ? select_by_department_id(db, dep_id) : delete_by_department_id(db, dep_id);
				break;
			default:
				break;
			}
		}
		else if (act == 2)
		{
			for (unsigned int i = 0; i < size; i++)
				insert(db, worker_arr[i]);
		}
		else if (act == 4)
		{
			int id = 0;
			printf("Input id: ");
			scanf("%d", &id);
			out_image(db, id);
		}
		else if(act == 5)
		{
			in_image(db);
		}
		else if(act == 6)
			break;

		if (autocommit == 1)
		{
			int do_commit;
			printf("\nDo you want COMMIT?\n"
					"1 - COMMIT\t2 - no COMMIT\n");
			scanf("%d", &do_commit);
			
			if (do_commit == 1)
			{
				sqlite3_exec(db, "COMMIT", 0, 0, &err_msg);
				
				printf("***Select mode***\n"
					"1 - Transition\t2 - autocommit\n");
				scanf("%d", &autocommit);

				if (autocommit == 1)
				{
					sqlite3_exec(db, "BEGIN TRANSITION", 0, 0, &err_msg);
				}
			}
			
		}
	}
	
	sqlite3_close(db);
	
    return 0;
}

