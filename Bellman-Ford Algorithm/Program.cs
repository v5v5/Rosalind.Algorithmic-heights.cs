using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellman_Ford_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DataWeightedGraph graph = new DataWeightedGraph("Bellman-Ford Algorithm.txt");
            //graph.Print();
            Console.WriteLine();

            string[] r = BellmanFordAlgorithm(graph);

            Utils.PrintArrayToFileX(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static string[] BellmanFordAlgorithm(DataWeightedGraph g)
        {
            return ShortestPaths(g, 0);
        }

        static int[] dist;
        static string[] distX;

        private static string[] ShortestPaths(DataWeightedGraph g, int s)
        {
            int n = g.Vertexes.Length;
            dist = new int[n];
            distX = new string[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = Int32.MaxValue;
                distX[i] = "x";
            }
            dist[s] = 0;
            distX[s] = dist[s].ToString();

            for (int i = 0; i < n - 1; i++)
            {
                for (int v = 0; v < n; v++)
                {
                    if (g.Vertexes[v] == null)
                    {
                        continue;
                    }

                    foreach(WeightEdge e in g.Vertexes[v])
                    {
                        Update(v, e);
                    }
                }
            }

            return distX;
        }

        private static void Update(int v, WeightEdge e)
        {
            if ((dist[v] == Int32.MaxValue) && (dist[e.VertexTo] == Int32.MaxValue))
            {
                return;
            }
            if (dist[v] == Int32.MaxValue)
            {
                return;
            }

            dist[e.VertexTo] = Math.Min(dist[e.VertexTo], dist[v] + e.Weight);
            distX[e.VertexTo] = dist[e.VertexTo].ToString();
        }
    }
}
