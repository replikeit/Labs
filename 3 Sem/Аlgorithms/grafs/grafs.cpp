#pragma warning(disable: 4996)
#include <vector>
#include <fstream>
#include <map>
#include<queue>
#include <stack>
using namespace std;



bool Find(vector<int>& vec, int w)
{

	for (int i = 0; i < vec.size(); i++)
	{
		if (vec[i] == w)
			return true;
	}
	return false;
}

int globalCounter = 0;

void dfs(int vertex, vector<vector<int>>& graphCount,vector<int>& parentVec, vector<int>& vertexColorVec, int start, int finish)
{
	stack<int> dfs_stack;
	dfs_stack.push(vertex);
	while (!dfs_stack.empty())
	{
		int ver = dfs_stack.top();
		if (ver == finish)	
		{
			globalCounter++;
			int tmpVer = parentVec[ver - 1];
			while (tmpVer != start)
			{
				vertexColorVec[tmpVer - 1] = 1;
				tmpVer = parentVec[tmpVer - 1];
			}
			return;
		}
		else if (vertexColorVec[ver - 1] == 1)
		{	
			int pVer = parentVec[ver - 1];
			dfs_stack.pop();
			while (pVer != start)
			{
				if (vertexColorVec[pVer - 1] == 1)
				{
					vertexColorVec[pVer - 1] = 0;
					dfs_stack.push(pVer);
				}
				else
				{
					break;
				}
				pVer = parentVec[pVer - 1];
			}
					
		}
		else if (vertexColorVec[ver - 1] == 0)
		{
			vertexColorVec[ver - 1] = 2;
			dfs_stack.pop();
			for (int i = 0; i < graphCount[ver - 1].size(); i++)
			{
				int tmpVer = graphCount[ver - 1][i];
				dfs_stack.push(tmpVer);
				if (vertexColorVec[tmpVer - 1] == 0)
					parentVec[tmpVer - 1] = ver;
			}
		}
		else
		{
			dfs_stack.pop();
		}
	}
}

int main()
{
	
	map<int, int> mapSum;
	vector<int> mVec;
	FILE* f2;
	
	f2 = fopen("input.txt", "r");
	ofstream fk("output.out");
	int n, m;
	
	fscanf(f2, "%d %d", &n, &m);
	vector<int> parentVec(n, 0);
	vector<int> vertexColorVec(n,0);
	
	int index = 0;
	vector<vector<int>> graphCont(n);
	
	while (index < n)
	{
		
		int temp;
		
		fscanf(f2, "%d", &temp);
		
		if (temp == 0)
			index++;
		else
			graphCont[index].push_back(temp);
	}
	
	int u, w;

	fscanf(f2, "%d %d", &u, &w);
	if (u == w)
	{
		fk << 0;
		return 0;
	}
	
	queue<int> graphQue;
	vertexColorVec[u - 1] = 2;
	
	for (int i = 0; i < graphCont[u - 1].size(); i++)
	{
		graphQue.push(graphCont[u - 1][i]);

	}

	while(!graphQue.empty())
	{
		int x = graphQue.front();
		if (vertexColorVec[x - 1] == 0)
			parentVec[x - 1] = u;
		dfs(x,graphCont,parentVec,vertexColorVec,u,w);
		graphQue.pop();
	}
	
	fk << globalCounter;
	fk.close();
}