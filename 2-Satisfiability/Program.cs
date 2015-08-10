using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Satisfiability
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSatisfiability data = new DataSatisfiability("2-Satisfiability.txt");
            //data.Print();
            //Console.WriteLine("\r\nFinish!");
            //Console.ReadKey();

            int[][] r = _2_Satisfiability(data);

            Utils.PrintArraysToFile(r);
            Console.WriteLine("\r\nFinish!");
            Console.ReadKey();
        }

        static int[][] _2_Satisfiability(DataSatisfiability data)
        {
            int[][] r = new int[data.Count][];
            int[][] rr = new int[data.Count][];

            for (int i = 0; i < data.Count; i++)
            {
                count = 0;
                r[i] = _2_Satisfiability1(data.Graphs[i]);

                for(int j = 1; j < r.Length; j += 2)
                {
                    if (r[i][j] == r[i][j - 1])
                    {
                        rr[i] = new int[1] { 0 };
                        break;
                    }
                }

                if (rr[i] != null)
                {
                    continue;
                }

                rr[i] = new int[r[i].Length / 2 + 1];
                rr[i][0] = 1;

                for(int j = 0; j < rr[i].Length - 1; j++)
                {
                    if (r[i][2 * j] % 2 == 0)
                    {
                        rr[i][j + 1] = - (j + 1); 
                    }
                    else
                    {
                        rr[i][j + 1] = j + 1;
                    }
                }

            }

            return rr; //rr
        }

        static Queue<int> postOrder;
        static private bool[] markedReverse;

        private static int[] _2_Satisfiability1(GraphAdjAltS g)
        {
            int n = g.v.Length;

            List<int>[] r = Utils.CreateReverseGraph(g.v);

            postOrder = new Queue<int>();
            markedReverse = new bool[n];

            for (int v = 0; v < n; v++)
            {
                if (markedReverse[v])
                {
                    continue;
                }
                DfsOnReverse(r, v);
            }


            marked = new bool[n];
            id = new int[n];

            Stack<int> queueReversePost = new Stack<int>();
            foreach (int v in postOrder)
            {
                queueReversePost.Push(v);
            }

            foreach (int v in queueReversePost)
            {
                if (marked[v])
                {
                    continue;
                }
                Dfs(g.v, v);
                count++;
            }
            return id;
        }

        static private bool[] marked;
        static private int[] id;
        static private int count;

        static private void DfsOnReverse(List<int>[] g, int v)
        {
            markedReverse[v] = true;
            foreach (int w in g[v])
            {
                if (markedReverse[w])
                {
                    continue;
                }
                DfsOnReverse(g, w);
            }

            postOrder.Enqueue(v);
        }

        static private void Dfs(List<int>[] g, int v)
        {
            marked[v] = true;
            id[v] = count;
            if (g[v] == null)
            {
                return;
            }
            foreach (int w in g[v])
            {
                if (marked[w])
                {
                    continue;
                }
                Dfs(g, w);
            }
        }
    }
}
