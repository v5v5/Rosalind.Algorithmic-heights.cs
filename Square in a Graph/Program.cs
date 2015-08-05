using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_in_a_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphsArrayOfList data = new GraphsArrayOfList("Square in a Graph.txt");
            //data.Print();
            //Console.WriteLine();

            int[] r = SquareInAGraph(data);

            Utils.PrintArrayToFile(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();

        }

        private static int[] SquareInAGraph(GraphsArrayOfList data)
        {
            int n = data._GraphsArrayOfList.Length;
            int[] r = new int[n];

            for (int i = 0; i < n; i++)
            {
                r[i] = DFS(data._GraphsArrayOfList[i]);
            }

            return r;
        }

        static bool[] visited;
        static int[] visitedPath;
        static int[] pre;
        static int[] post;
        static int clock = 0;

        private static int DFS(GraphArrayOfList g)
        {
            int n = g.Vertexes.Length;
            visited = new bool[n];
            visitedPath = new int[n];
            pre = new int[n];
            post = new int[n];

            for (int i = 0; i < n; i++)
            {
                int r = Explorer(g, i, i);
                if (r == 1)
                {
                    return 1;
                }
            }

            return -1;
        }

        private static int Explorer(GraphArrayOfList g, int start, int v)
        {
            if ((start == v) && (visitedPath[v] == 4))
            {
                return 1;
            }
            if ((start == v) && (visitedPath[v] > 0))
            {
                visitedPath[start] = 0;
                return -1;
            }
            if ((start != v) && (visitedPath[v] >= 4))
            {
                return -1;
            }

            visited[v] = true;
            Previsit(v);

            foreach(int u in g.Vertexes[v])
            {
                //if (visited[u])
                if (visitedPath[u] != 0)
                {
                    continue;
                }
                visitedPath[u] = visitedPath[v] + 1;

                int r = Explorer(g, start, u);
                if (r == 1)
                {
                    return 1;
                }
                visitedPath[u] = 0;
            }
            Postvisit(v);

            return -1;
        }

        private static void Postvisit(int v)
        {
            post[v] = clock++;
        }

        private static void Previsit(int v)
        {
            pre[v] = clock++;
        }
    }
}
