__kernel void DefaultMulty(__global int* m1, __global int* m2, __global int* m3, int n, int m, int l)
{
	int i = get_global_id(0);
	int j = get_global_id(1);

	int sum = 0;
	int m1Base = i * m;
	int m2Base = j * m;
	for (int k = 0; k < m; ++k)
	{
		int r = m1[m1Base + k] *  m2[m2Base + k];
		sum += r;
	}
	m3[i * l + j] = sum;
}


__kernel void Vector8(__global int* m1, __global int* m2, __global int* m3, int n, int m, int l)
{
	int i = get_global_id(0);
	int j = get_global_id(1);

	int8 sum = (int8)(0, 0, 0, 0, 0, 0, 0, 0);
	int m1Base = i * m;
	int m2Base = j * m;
	int bound = m / 8;

	for (int k = 0; k < bound; ++k)
	{
		int8 v1 = (int8)(m1[m1Base], m1[m1Base + 1], m1[m1Base + 2], m1[m1Base + 3], m1[m1Base + 4], m1[m1Base + 5], m1[m1Base + 6], m1[m1Base + 7]);
		int8 v2 = (int8)(m2[m2Base], m2[m2Base + 1], m2[m2Base + 2], m2[m2Base + 3], m2[m2Base + 4], m2[m2Base + 5], m2[m2Base + 6], m2[m2Base + 7]);
		sum += v1 * v2;

		m1Base += 8;
		m2Base += 8;
	}

	if (bound * 8 < m)
	{
		int8 v1 = (int8)(m1[m1Base],
			bound * 8 + 1 < m ? m1[m1Base + 1] : 0,
			bound * 8 + 2 < m ? m1[m1Base + 2] : 0,
			bound * 8 + 3 < m ? m1[m1Base + 3] : 0,
			bound * 8 + 4 < m ? m1[m1Base + 4] : 0,
			bound * 8 + 5 < m ? m1[m1Base + 5] : 0,
			bound * 8 + 6 < m ? m1[m1Base + 6] : 0,
			bound * 8 + 7 < m ? m1[m1Base + 7] : 0);

		int8 v2 = (int8)(m2[m2Base],
			bound * 8 + 1 < m ? m2[m2Base + 1] : 0,
			bound * 8 + 2 < m ? m2[m2Base + 2] : 0,
			bound * 8 + 3 < m ? m2[m2Base + 3] : 0,
			bound * 8 + 4 < m ? m2[m2Base + 4] : 0,
			bound * 8 + 5 < m ? m2[m2Base + 5] : 0,
			bound * 8 + 6 < m ? m2[m2Base + 6] : 0,
			bound * 8 + 7 < m ? m2[m2Base + 7] : 0);

		sum += v1 * v2;
	}

	m3[i * l + j] = sum.s0 + sum.s1 + sum.s2 + sum.s3 + sum.s4 + sum.s5 + sum.s6 + sum.s7;
}

__kernel void Vector2(__global int* m1, __global int* m2, __global int* m3, int n, int m, int l)
{
	int i = get_global_id(0);
	int j = get_global_id(1);

	int2 sum = (int2)(0, 0);
	int m1Base = i * m;
	int m2Base = j * m;
	int bound = m / 2;

	for (int k = 0; k < bound; ++k)
	{
		int2 v1 = (int2)(m1[m1Base], m1[m1Base + 1]);
		int2 v2 = (int2)(m2[m2Base], m2[m2Base + 1]);
		sum += v1 * v2;

		m1Base += 2;
		m2Base += 2;
	}

	if (bound * 2 < m)
	{
		int2 v1 = (int2)(m1[m1Base],
			bound * 2 + 1 < m ? m1[m1Base + 1] : 0);

		int2 v2 = (int2)(m2[m2Base],
			bound * 2 + 1 < m ? m2[m2Base + 1] : 0);

		sum += v1 * v2;
	}

	m3[i * l + j] = sum.s0 + sum.s1;
}


__kernel void Vector4(__global int* m1, __global int* m2, __global int* m3, int n, int m, int l)
{
	int i = get_global_id(0);
	int j = get_global_id(1);

	int4 sum = (int4)(0, 0, 0, 0);
	int m1Base = i * m;
	int m2Base = j * m;
	int bound = m / 4;

	for (int k = 0; k < bound; ++k)
	{
		int4 v1 = (int4)(m1[m1Base], m1[m1Base + 1], m1[m1Base + 2], m1[m1Base + 3]);
		int4 v2 = (int4)(m2[m2Base], m2[m2Base + 1], m2[m2Base + 2], m2[m2Base + 3]);
		sum += v1 * v2;

		m1Base += 4;
		m2Base += 4;
	}

	if (bound * 4 < m)
	{
		int4 v1 = (int4)(m1[m1Base],
			bound * 4 + 1 < m ? m1[m1Base + 1] : 0,
			bound * 4 + 2 < m ? m1[m1Base + 2] : 0,
			bound * 4 + 3 < m ? m1[m1Base + 3] : 0);

		int4 v2 = (int4)(m2[m2Base],
			bound * 4 + 1 < m ? m2[m2Base + 1] : 0,
			bound * 4 + 2 < m ? m2[m2Base + 2] : 0,
			bound * 4 + 3 < m ? m2[m2Base + 3] : 0);

		sum += v1 * v2;
	}

	m3[i * l + j] = sum.s0 + sum.s1 + sum.s2 + sum.s3;
}