using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _SharedFiles
{
    class GraphWeithedAdjAlt0
    {
        public int Count;
        public GraphAdjAlt1[] Graphs;

        public GraphWeithedAdjAlt0(string fileName)
        {
            string filePath = Utils.GetFullFilePath(fileName);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int iGraph = -1;

                    int countVerticles;
                    int countEdges = 0;

                    line = reader.ReadLine();
                    Count = int.Parse(line);
                    Graphs = new GraphAdjAlt1[Count];

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            continue;
                        }

                        if (countEdges == 0)
                        {
                            iGraph++;
                            string[] args = line.Split(' ');
                            countVerticles = int.Parse(args[0]);
                            countEdges = int.Parse(args[1]);

                            Graphs[iGraph] = new GraphAdjAlt1();
                            Graphs[iGraph].v = new List<WeightEdge1>[countVerticles];
                            for (int i = 0; i < Graphs[iGraph].v.Length; i++)
                            {
                                Graphs[iGraph].v[i] = new List<WeightEdge1>();
                            }
                            continue;
                        }

                        string[] edge = line.Split(' ');
                        int v0 = int.Parse(edge[0]) - 1;
                        int v1 = int.Parse(edge[1]) - 1;
                        int w = int.Parse(edge[2]);

                        Graphs[iGraph].v[v0].Add(new WeightEdge1() { VertexTo = v1, Weight = w});

                        countEdges--;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        internal void PrintToFile()
        {
            string path_exe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (StreamWriter writer = new StreamWriter(path_exe + @"\out.txt"))
            {
                writer.WriteLine("{0}\r\n", Count);

                for (int i = 0; i < Graphs.Length; i++)
                {
                    writer.WriteLine("{0}\r\n", Graphs[i].v.Length);

                    for (int v = 0; v < Graphs[i].v.Length; v++)
                    {
                        foreach (WeightEdge1 e in Graphs[i].v[v])
                        {
                            writer.WriteLine("{0} {1} {2}", v, e.VertexTo, e.Weight);
                        }
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("{0}\r\n", Count);

            for (int i = 0; i < Graphs.Length; i++)
            {
                Console.WriteLine("{0}", Graphs[i].v.Length);

                for (int v = 0; v < Graphs[i].v.Length; v++)
                {
                    foreach (WeightEdge1 e in Graphs[i].v[v])
                    {
                        Console.WriteLine("{0} {1} {2}", v, e.VertexTo, e.Weight);
                    }
                }
                Console.WriteLine();
            }
        }

    }

    class GraphAdjAlt1
    {
        public List<WeightEdge1>[] v;
    }

    public class WeightEdge1
    {
        public int VertexTo;
        public int Weight;
    }


}
