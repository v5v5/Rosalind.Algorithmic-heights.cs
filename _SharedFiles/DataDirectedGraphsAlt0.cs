using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _SharedFiles
{
    class DataDirectedGraphsAlt0
    {
        public int Count;
        public GraphAdjAlt0[] Graphs;

        public DataDirectedGraphsAlt0(string fileName)
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
                    Graphs = new GraphAdjAlt0[Count];

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

                            Graphs[iGraph] = new GraphAdjAlt0();
                            Graphs[iGraph].v = new List<int>[countVerticles];
                            for (int i = 0; i < Graphs[iGraph].v.Length; i++)
                            {
                                Graphs[iGraph].v[i] = new List<int>();
                            }
                            continue;
                        }

                        string[] edge = line.Split(' ');
                        int v0 = int.Parse(edge[0]) - 1;
                        int v1 = int.Parse(edge[1]) - 1;

                        Graphs[iGraph].v[v0].Add(v1);

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
                writer.WriteLine(Count);

                for (int i = 0; i < Graphs.Length; i++)
                {
                    writer.WriteLine(Graphs[i].v.Length);

                    for (int v = 0; v < Graphs[i].v.Length; v++)
                    {
                        foreach (int u in Graphs[i].v[v])
                        {
                            writer.WriteLine("{0} {1}", v, u);
                        }
                    }
                }

            }

        }

        public void Print()
        {
            Console.WriteLine(Count);

            for (int i = 0; i < Graphs.Length; i++)
            {
                Console.WriteLine(Graphs[i].v.Length);

                for (int v = 0; v < Graphs[i].v.Length; v++)
                {
                    foreach (int u in Graphs[i].v[v])
                    {
                        Console.WriteLine("{0} {1}", v, u);
                    }
                }
            }
        }
    }

    class GraphAdjAlt0
    {
        public List<int>[] v;
    }
}
