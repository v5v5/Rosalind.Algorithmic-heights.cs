using _SharedFiles;
using System;

namespace Testing_Acyclicity
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDirectedGraphs Graph = new DataDirectedGraphs("Testing Acyclicity.txt");
            //Graph.Print();
            
            int[] result = TestingAcyclicity(Graph);
            Utils.PrintArray(result);
            Console.ReadKey();
        }

        private static int[] TestingAcyclicity(DataDirectedGraphs graph)
        {
            int[] res = new int[graph._GraphsArrayOfList.Length];

            for(int i = 0; i < graph._GraphsArrayOfList.Length; i++)
            {
                color = new int[graph._GraphsArrayOfList[i].Vertexes.Length];
                isCyclic = false;
                Dfs(graph._GraphsArrayOfList[i], 0);
                res[i] = (isCyclic ? -1: 1);
            }

            return res;
        }

        static int[] color;
        static bool isCyclic = false;

        private static void Dfs(DataDirectedGraphs.GraphArrayOfList graph, int v)
        {
            if (color[v] == 2)
            {
                return;
            }
            if (isCyclic)
            {
                return;
            }
            if (color[v] == 1)
            {
                isCyclic = true;
                return;
            }

            color[v] = 1;

            foreach(int u in graph.Vertexes[v])
            {
                Dfs(graph, u);
                if (isCyclic)
                {
                    return;
                }
            }

            color[v] = 2;
        }
    }
}
