using System;
using System.Collections.Generic;
using System.IO;

namespace _SharedFiles
{
    partial class DataSatisfiability
    {
        public int Count;
        public GraphAdjAltS[] Graphs;

        public DataSatisfiability(string fileName)
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
                    Graphs = new GraphAdjAltS[Count];

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
                            countVerticles = int.Parse(args[0]) * 2;
                            countEdges = int.Parse(args[1]) * 2;

                            Graphs[iGraph] = new GraphAdjAltS();
                            Graphs[iGraph].v = new List<int>[countVerticles];
                            for (int i = 0; i < Graphs[iGraph].v.Length; i++)
                            {
                                Graphs[iGraph].v[i] = new List<int>();
                            }
                            continue;
                        }

                        string[] edge = line.Split(' ');
                        int v0 = int.Parse(edge[0]);
                        int v1 = int.Parse(edge[1]);

                        int e0out, e0in, e1out, e1in;
                        if (v0 > 0)
                        {//+
                            e1in = v0 * 2 - 2;
                            e0out = e1in + 1;
                        }
                        else
                        {
                            e1in = -v0 * 2 - 1;
                            e0out = e1in - 1;
                        }
                        if (v1 > 0)
                        {
                            e0in = v1 * 2 - 2; ;
                            e1out = e0in + 1;
                        }
                        else
                        {
                            e0in = -v1 * 2 - 1;
                            e1out = e0in - 1;
                        }

                        if (!Graphs[iGraph].v[e0out].Contains(e0in))
                        {
                            Graphs[iGraph].v[e0out].Add(e0in);
                        }
                        if (!Graphs[iGraph].v[e1out].Contains(e1in))
                        {
                            Graphs[iGraph].v[e1out].Add(e1in);
                        }

                        countEdges--;
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

        public void Print()
        {
            Console.WriteLine("{0}\r\n", Count);

            for (int i = 0; i < Graphs.Length; i++)
            {
                Console.WriteLine("{0}", Graphs[i].v.Length);

                for (int v = 0; v < Graphs[i].v.Length; v++)
                {
                    Console.Write("{0}: ", v);
                    foreach (int u in Graphs[i].v[v])
                    {
                        Console.Write("{0} ", u);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }

    public class GraphAdjAltS
    {
        public List<int>[] v;
    }

}
