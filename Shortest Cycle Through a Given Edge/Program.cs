using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortest_Cycle_Through_a_Given_Edge
{
    class Program
    {
        static void Main(string[] args)
        {
            DataWeightedGraphs graphs = new DataWeightedGraphs("Shortest Cycle Through a Given Edge.txt");
            graphs.Print();
            //Console.WriteLine("Finish");
            //Console.ReadKey();

            int[] r = ShortestCycleThroughAGivenEdge(graphs);
            Utils.PrintArrayToFile(r);
            Console.WriteLine();
            Console.WriteLine("Finish");
            Console.ReadKey();
        }

        private static int[] ShortestCycleThroughAGivenEdge(DataWeightedGraphs graphs)
        {
            int[] r = new int[graphs._count];
            int[] dist;
            for(int i = 0; i < graphs._count; i++)
            {
                int start = graphs._GraphsWeithedAdj[i].start;
                int finish = graphs._GraphsWeithedAdj[i].finish;
                int weight = graphs._GraphsWeithedAdj[i].weight;

                dist = BFS_Dijkstra1(graphs._GraphsWeithedAdj[i], start);
                if (dist[finish] == -1)
                {
                    r[i] = dist[finish];
                    continue;
                }
                r[i] = dist[finish] + weight;
            }
            return r;
        }

        static SortedDictionary<int, int> pq = new SortedDictionary<int, int>();

        private static int[] BFS_Dijkstra1(GraphWeithedAdj graph, int s)
        {
            int[] distTo = new int[graph.Vertexes.Length];

            for (int v = 0; v < graph.Vertexes.Length; v++)
            {
                distTo[v] = Int32.MaxValue;
            }
            distTo[s] = 0;

            // puth in priority queue key(distance) & value(index of vertex)
            pq.Add(distTo[s], s);

            while (pq.Count != 0)
            {
                int v = pq[pq.Keys.First()];
                pq.Remove(pq.Keys.First());

                foreach (WeightEdge e in graph.Vertexes[v])
                {
                    int vFrom = v;
                    int wTo = e.VertexTo;
                    int distSum = distTo[v] + e.Weight;

                    if (distTo[wTo] <= distSum)
                    {
                        continue;
                    }

                    distTo[wTo] = distSum;

                    if (pq.ContainsKey(distTo[wTo]))
                    {
                        pq[distTo[wTo]] = wTo;
                    }
                    else
                    {
                        pq.Add(distTo[wTo], wTo);
                    }
                }
            }

            for (int i = 0; i < distTo.Length; i++)
            {
                distTo[i] = (distTo[i] == Int32.MaxValue ? -1 : distTo[i]);
            }

            return distTo;
        }


    }
}
