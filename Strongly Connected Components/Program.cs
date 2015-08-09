using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strongly_Connected_Components
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDirectedGraph data = new DataDirectedGraph("Strongly Connected Components.txt");
            //data.Print();
            //Console.WriteLine("\r\nFinish!");
            //Console.ReadKey();

            int r = StronglyConnectedComponents(data);

            Console.WriteLine(r);
            Console.WriteLine("\r\nFinish!");
            Console.ReadKey();
        }

        static Queue<int> postOrder;
        static private bool[] markedReverse;

        static int StronglyConnectedComponents(DataDirectedGraph g)
        {
            int n = g.Graph.Vertexes.Length;

            DataDirectedGraph r = g.CreateReverse();

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
                Dfs(g, v);
                count++;
            }
            return count;
        }

        static private bool[] marked;
        static private int[] id;
        static private int count;

        static private void DfsOnReverse(DataDirectedGraph g, int v)
        {
            markedReverse[v] = true;
            foreach (int w in g.Graph.Vertexes[v])
            {
                if (markedReverse[w])
                {
                    continue;
                }
                DfsOnReverse(g, w);
            }

            postOrder.Enqueue(v);
        }

        static private void Dfs(DataDirectedGraph g, int v)
        {
            marked[v] = true;
            id[v] = count;
            if (g.Graph.Vertexes[v] == null)
            {
                return;
            }
            foreach (int w in g.Graph.Vertexes[v])
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
