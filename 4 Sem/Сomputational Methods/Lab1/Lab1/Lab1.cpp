#include <assert.h>
#include <float.h>
#include <stdio.h>
#include <math.h>


int main()
{
    unsigned long long i = pow(2,53);
    double f = i;
    printf("%llu %lf\n", i, f);
    f = ++i;
    printf("%llu %lf\n", i, f);
    f = ++i;
    printf("%llu %lf\n", i, f);
}