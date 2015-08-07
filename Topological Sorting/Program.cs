using _SharedFiles;
using System;
using System.Collections.Generic;

namespace Topological_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDirectedGraph graph = new DataDirectedGraph("Topological Sorting.txt");
            //graph.Print();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int[] r = TopologicalSorting(graph);

            Utils.PrintArrayToFile(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int[] TopologicalSorting(DataDirectedGraph g)
        {
            int n = g.Graph.Vertexes.Length;
            marked = new int[n];
            reversePost = new Stack<int>();

            for (int v = 0; v < n; v++)
            {
                DFS(g, v);
            }

            int[] r = new int[reversePost.Count];

            int i = 0;
            while (reversePost.Count != 0)
            {
                r[i] = reversePost.Pop() + 1;
                i++;
            }

            return r;
        }

        static int[] marked;
        static Stack<int> reversePost;

        private static void DFS(DataDirectedGraph g, int v)
        {
            if (marked[v] != 0)
            {
                return;
            }

            marked[v] = 1;

            if (null != g.Graph.Vertexes[v])
            {
                foreach (int i in g.Graph.Vertexes[v])
                {
                    DFS(g, i);
                }
            }

            reversePost.Push(v);
        }
    }
}
