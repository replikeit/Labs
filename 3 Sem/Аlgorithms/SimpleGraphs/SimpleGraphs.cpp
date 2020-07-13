#pragma warning(disable: 4996)
#include <vector>
#include <fstream>
#include <map>
#include<set>
#include<stack>
#include <iostream>
using namespace std;

int counter;
vector<bool> visitVec;


void dfs(vector<vector<int>>& graphMatrix,int vertex, vector<bool>& checkVec, vector<int>& orderVec,int& index)
{
	if (checkVec[vertex - 1])
	{
		checkVec[vertex - 1] = false;
		orderVec[vertex - 1] = ++index;
		for (int i = 0; i < graphMatrix[vertex - 1].size(); i++)
		{
			if (graphMatrix[vertex - 1][i] == 1)
			{
				dfs(graphMatrix, i + 1, checkVec, orderVec, index);
			}
		}
	}
	
}

int main()
{
	map<int, int> mapSum;
	set<int> CounterThree;
	

	
	FILE* f2;
	f2 = fopen("input.txt", "r");
	ofstream fk("output.txt");
	int n;
	fscanf(f2, "%d", &n);
	vector<bool> checkVec(n,true);
	vector<int> orderVertex(n);
	vector<vector<int>> graphMatrix(n);
	for(int i = 0; i < n;i++)
	{
		graphMatrix[i] = vector<int>(n);
		for (int j = 0; j < n; j++)
		{
			fscanf(f2,"%d", &graphMatrix[i][j]);
		}
	}

	stack<int> q;
	counter = 0;
	for(int i = 0;i < n;i++)
	{
		dfs(graphMatrix, i + 1, checkVec, orderVertex, counter);
	}
	
	for (int i = 0; i < n; i++)
	{
		fk << orderVertex[i] << " ";
	}

	
}