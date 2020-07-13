#include "stdio.h"
#include "time.h"
#include "stdlib.h"
#include "math.h"

enum _BOOL
{
	FALSE = 0,
	TRUE = 1
} typedef BOOL;

BOOL check_sqrt(int n)
{
	double temp;
	double dumb;
	temp = modf(sqrt(n), &dumb);
	
	if (temp != 0.0) return FALSE;
	
	return TRUE;
}

int main(int argc, char* argv[])
{
	srand(time(NULL));
	
	unsigned int n = atoi(argv[1]);
	int* arr = calloc(n, sizeof(int));
	
	printf("Random array\n");
	for (unsigned int i = 0; i < n; i++)
	{
		arr[i] =1 + rand() % 100;
		printf("%d ", arr[i]);
	}
	
	printf("\nCeck Sqrt\n");
	for (unsigned int i = 0; i < n; i++)
	{
		BOOL check = check_sqrt(arr[i]);
		if (check == TRUE) printf("%d\tis full square\n", arr[i]);
		else printf("%d\tis not full square\n", arr[i]);
	}
	
	free(arr);
	
	return 0;
}

