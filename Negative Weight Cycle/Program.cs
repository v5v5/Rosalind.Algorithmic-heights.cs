using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negative_Weight_Cycle
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphWeithedAdjAlt0 data = new GraphWeithedAdjAlt0("Negative Weight Cycle.txt");
            //data.PrintToFile();
            //Console.WriteLine();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int[] r = Negative_Weight_Cycle(data);

            Utils.PrintArray(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        public static int[] Negative_Weight_Cycle(GraphWeithedAdjAlt0 data)
        {
            int[] r = new int[data.Graphs.Length];
       
            for(int i = 0; i < data.Graphs.Length; i++)
            {
                for(int j = 0; j < data.Graphs[i].v.Length; j++)
                {
                    int rr = BellmanFordAlgorithm(data.Graphs[i], j);
                    if (rr == 1)
                    {
                        r[i] = 1;
                        break;
                    }
                    r[i] = -1;
                }
            }

            return r;
        }

        private static int BellmanFordAlgorithm(GraphAdjAlt1 g, int s)
        {
            return ShortestPathsExits(g, s);
        }

        static int[] dist;
        static bool haveChanging;

        private static int ShortestPathsExits(GraphAdjAlt1 g, int s)
        {
            int n = g.v.Length;
            dist = new int[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = Int32.MaxValue;
            }
            dist[s] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                haveChanging = false;
                for (int v = 0; v < n; v++)
                {
                    if (g.v[v] == null)
                    {
                        continue;
                    }

                    foreach (WeightEdge1 e in g.v[v])
                    {
                        Update(v, e);
                        if (haveChanging == false)
                        {
                            break;
                        }
                    }
                }
                if (haveChanging == false)
                {
                    break;
                }
            }

            for (int v = 0; v < n; v++)
            {
                if (g.v[v] == null)
                {
                    continue;
                }
                foreach (WeightEdge1 e in g.v[v])
                {
                    Update(v, e);
                    if (haveChanging == false)
                    {
                        return -1;
                    }
                }
            }

            return 1;
        }

        private static void Update(int v, WeightEdge1 e)
        {
            //if ((dist[v] == Int32.MaxValue) && (dist[e.VertexTo] == Int32.MaxValue))
            //{
            //    return;
            //}
            if (dist[v] == Int32.MaxValue)
            {
                return;
            }

            //dist[e.VertexTo] = Math.Min(dist[e.VertexTo], dist[v] + e.Weight);

            if (dist[e.VertexTo] > dist[v] + e.Weight)
            {
                dist[e.VertexTo] = dist[v] + e.Weight;
                haveChanging = true;
            }
        }
    }
}
