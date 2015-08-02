using _SharedFiles;
using System;

namespace Testing_Bipartiteness
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphsArrayOfList Graphs = new GraphsArrayOfList("Testing Bipartiteness.txt");
            Graphs.Print();
            Console.WriteLine();

            int[] results = TestingBipartiteness(Graphs);
            Utils.PrintArray(results);
            Console.ReadKey();
        }

        private static int[] TestingBipartiteness(GraphsArrayOfList graphs)
        {
            int[] result = new int[graphs._count];

            for(int i = 0; i < graphs._count; i++)
            {
                result[i] = IsGraphBipartiteness(graphs._GraphsArrayOfList[i]);
            }
            return result;
        }


        static int[] color;

        private static int IsGraphBipartiteness(GraphArrayOfList graph)
        {
            color = new int[graph.Vertexes.Length];

            for (int i = 0; i < graph.Vertexes.Length; i++)
            {
                if (color[i] != 0)
                {
                    continue;
                }
                color[i] = 1;
                if (!DFS(graph, i))
                {
                    return -1;
                }
            }
            return 1;
        }

        private static bool DFS(GraphArrayOfList graph,  int v)
        {
            foreach(int n in graph.Vertexes[v])
            {
                if (color[n] == 0)
                {
                    color[n] = 3 - color[v];
                    if (!DFS(graph, n))
                    {
                        return false;
                    }
                }
                else
                {
                    if (color[n] + color[v] != 3)
                    {
                        return false;
                    }
                }                
            }
            return true;
        }

    }
}
