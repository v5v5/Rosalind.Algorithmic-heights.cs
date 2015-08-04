using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            DataWeightedGraph graph = new DataWeightedGraph("Dijkstra's Algorithm.txt");
            //graph.Print();
            //Console.WriteLine();

            int[] r = DijkstraS_Algorithm(graph);

            Utils.PrintArray(r);
            //Utils.PrintArrayToFile(r);

            Console.WriteLine("\r\nFinish!");
            Console.ReadKey();
        }

        private static int[] DijkstraS_Algorithm(DataWeightedGraph graph)
        {
            //int[] dist = BFS_Dijkstra(graph, 0);
            int[] dist = BFS_Dijkstra1(graph, 0);

            return dist;
        }

        static SortedDictionary<int, int> pq = new SortedDictionary<int, int>();

        private static int[] BFS_Dijkstra1(DataWeightedGraph graph, int s)
        {
            int[] distTo = new int[graph.Vertexes.Length];

            for(int v = 0; v < graph.Vertexes.Length; v++)
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

                foreach(WeightEdge e in graph.Vertexes[v])
                {
                    int vFrom = v;
                    int wTo = e.VertexTo;
                    int distSum = distTo[v] + e.Weight;

                    if (distTo[wTo] <= distSum)
                    {
                        continue;
                    }

                    distTo[wTo] = distSum;

                    if (pq.ContainsValue(wTo))
                    {
                        pq[distTo[wTo]] = wTo;
                    }
                    else
                    {
                        pq.Add(distTo[wTo], wTo);
                    }
                }
            }

            for(int i = 0; i < distTo.Length; i++)
            {
                distTo[i] = (distTo[i] == Int32.MaxValue ? -1 : distTo[i]);
            }

            return distTo;
        }

        private static int getMinFromDist(int[] dist, bool[] mark)
        {
            int iMin = -1;
            int vMin = -1;

            for(int i = 0; i < mark.Length; i++)
            {
                if (mark[i])
                {
                    continue;
                }
                vMin = dist[i];
                iMin = i;
                break;
            }

            if (iMin == -1)
            {
                return -1;
            }

            for(int i = iMin + 1; i < dist.Length; i++)
            {
                if (mark[i])
                {
                    continue;
                }

                if (dist[i] < vMin)
                {
                    vMin = dist[i];
                    iMin = i;
                }
            }
            return iMin;
        }

        private static int[] BFS_Dijkstra(DataWeightedGraph graph, int s)
        {
            int[] dist = new int[graph.countVertexes];
            bool[] mark = new bool[graph.countVertexes];

            for(int i = 0; i < graph.countVertexes; i++)
            {
                dist[i] = Int32.MaxValue;
                mark[i] = false;
            }
            dist[s] = 0;

            while(true)
            {
                // получим вершину с минимальным весом из всех непосещенных(mark=false)
                int i = getMinFromDist(dist, mark);
                if (i == -1)
                {
                    break;
                }

                // для каждого соседа для вершины i
                // по порядку расстояния до них или нет(???)
                if (null == graph.Vertexes[i])
                {
                    graph.Vertexes[i] = new List<WeightEdge>();
                }
                foreach (WeightEdge edge in graph.Vertexes[i])
                {
                    if (mark[edge.VertexTo])
                    {
                        continue;
                    }

                    int distSum = dist[i] + edge.Weight;
                    if (distSum > dist[edge.VertexTo])
                    {
                        continue;
                    }
                    dist[edge.VertexTo] = distSum;
                }

                mark[i] = true;
            }

            for(int i = 0; i < dist.Length; i++ )
            {
                if (dist[i] != Int32.MaxValue)
                {
                    continue;
                }
                dist[i] = -1;
            }

            return dist;
        }

        private static int[] BFS(DataWeightedGraph graph, int s)
        {
            Queue<int> q = new Queue<int>();
            int[] dist = new int[graph.countVertexes];

            for(int i = 0; i < dist.Length; i++)
            {
                dist[i] = -1;
            }

            dist[0] = 0;
            q.Enqueue(s);

            while (!(q.Count == 0))
            {
                int u = q.Dequeue();

                foreach(WeightEdge e in graph.Vertexes[u])
                {
                    if (dist[e.VertexTo] != -1)
                    {
                        continue;
                    }

                    q.Enqueue(e.VertexTo);
                    dist[e.VertexTo] = dist[u] + 1;
                }
            }
            return dist;
        }
    }
}
