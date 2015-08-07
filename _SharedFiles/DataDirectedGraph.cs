using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SharedFiles
{
    class DataDirectedGraph
    {
        public int CountVertexes;
        public int CountEdges;
        public GraphAdj Graph;

        public DataDirectedGraph(string fileName)
        {
            string filePath = Utils.GetFullFilePath(fileName);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    line = reader.ReadLine();

                    string[] param = line.Split(' ');

                    CountVertexes = int.Parse(param[0]);
                    CountEdges = int.Parse(param[1]);

                    Graph = new GraphAdj();
                    Graph.Vertexes = new List<int>[CountVertexes];

                    while ((line = reader.ReadLine()) != null)
                    {
                        param = line.Split(' ');

                        int v0 = Int32.Parse(param[0]) - 1;
                        int v1 = Int32.Parse(param[1]) - 1;

                        if (null == Graph.Vertexes[v0])
                        {
                            Graph.Vertexes[v0] = new List<int>();
                        }
                        if (null == Graph.Vertexes[v1])
                        {
                            Graph.Vertexes[v1] = new List<int>();
                        }
                        Graph.Vertexes[v0].Add(v1);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        internal void Print()
        {
            Console.Write("{0} {1}", CountVertexes, CountEdges);
            Console.WriteLine();

            for (int i = 0; i < Graph.Vertexes.Length; i++)
            {
                Console.Write("{0}: ", i);

                if (null == Graph.Vertexes[i])
                {
                    Console.WriteLine();
                    continue;
                }

                foreach(int e in Graph.Vertexes[i])
                {
                    Console.Write("{0} ", e);
                }
                Console.WriteLine();
            }
        }

        public class GraphAdj
        {
            public List<int>[] Vertexes;
        }
    }
}
