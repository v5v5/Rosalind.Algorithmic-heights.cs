using _SharedFiles;
using System;
using System.Collections.Generic;

namespace Hamiltonian_Path_in_DAG
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDirectedGraphsAlt0 data = new DataDirectedGraphsAlt0("Hamiltonian Path in DAG.txt");
            //data.PrintToFile();
            //Console.WriteLine();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int[][] r = HamiltonianPathInDAG(data);

            Utils.PrintArraysToFile(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int[][] HamiltonianPathInDAG(DataDirectedGraphsAlt0 data)
        {
            int n = data.Graphs.Length;
            int[][] r = new int[n][];
            for(int i = 0; i < n; i++)
            {
                r[i] = HamiltonianPath(data.Graphs[i]);
            }
            return r;
        }

        private static int[] HamiltonianPath(GraphAdjAlt0 g)
        {
            int[] r = TopologicalSorting(g);

            // next vertix (with index i + 1) must finding in
            // list of previous vertix (with index i), becouse must be edge
            // beetween them 
            for(int i = 0; i < r.Length - 1; i++)
            {
                if (g.v[r[i] - 1].IndexOf(r[i + 1] - 1) == -1)
                {
                    return new int[] { -1 };
                }
            }

            int[] rr = new int[r.Length + 1];
            Array.Copy(r, 0, rr, 1, r.Length);
            rr[0] = 1;
            return rr;
        }

        static int[] marked;
        static Stack<int> reversePost;

        private static int[] TopologicalSorting(GraphAdjAlt0 g)
        {
            int n = g.v.Length;
            marked = new int[n];
            reversePost = new Stack<int>();

            for (int v = 0; v < n; v++)
            {
                if (marked[v] != 0)
                {
                    continue;
                }
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

        private static void DFS(GraphAdjAlt0 g, int v)
        {
            marked[v] = 1;

            if (null != g.v[v])
            {
                foreach (int i in g.v[v])
                {
                    if (marked[i] != 0)
                    {
                        continue;
                    }
                    DFS(g, i);
                }
            }

            reversePost.Push(v);
        }

    }
}
