using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SharedFiles
{
    class DataWeightedGraphs
    {
        public int _count;
        public GraphWeithedAdj[] _GraphsWeithedAdj;

        public DataWeightedGraphs(string fileName)
        {
            string filePath = Utils.GetFullFilePath(fileName);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int iEdge = 0;
                    int iGraph = -1;

                    int countVerticles;
                    int countEdges = 0;

                    line = reader.ReadLine();
                    _count = int.Parse(line);
                    _GraphsWeithedAdj = new GraphWeithedAdj[_count];

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            continue;
                        }

                        if (countEdges == 0)
                        {
                            iGraph++;
                            iEdge = 0;
                            string[] args = line.Split(' ');
                            countVerticles = int.Parse(args[0]);
                            countEdges = int.Parse(args[1]);

                            _GraphsWeithedAdj[iGraph] = new GraphWeithedAdj();
                            _GraphsWeithedAdj[iGraph].Vertexes = new List<WeightEdge>[countVerticles];
                            for (int i = 0; i < _GraphsWeithedAdj[iGraph].Vertexes.Length; i++)
                            {
                                _GraphsWeithedAdj[iGraph].Vertexes[i] = new List<WeightEdge>();
                            }
                            continue;
                        }

                        string[] edge = line.Split(' ');
                        int v0 = int.Parse(edge[0]);
                        int v1 = int.Parse(edge[1]);
                        int w = int.Parse(edge[2]);
                        if (iEdge == 0)
                        {
                            _GraphsWeithedAdj[iGraph].start = v1 - 1;
                            _GraphsWeithedAdj[iGraph].finish = v0 - 1;
                            _GraphsWeithedAdj[iGraph].weight = w;
                        }

                        _GraphsWeithedAdj[iGraph].Vertexes[v0 - 1].Add(
                            new WeightEdge() { VertexTo = v1 - 1, Weight = w });

                        countEdges--;
                        iEdge++;
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
            Console.WriteLine(_count);
            Console.WriteLine();

            for (int iGraph = 0; iGraph < _GraphsWeithedAdj.Length; iGraph++)
            {
                Console.WriteLine("start: {0}, finish: {1}", _GraphsWeithedAdj[iGraph].start, _GraphsWeithedAdj[iGraph].finish);

                for (int iVertixes = 0; iVertixes < _GraphsWeithedAdj[iGraph].Vertexes.Length; iVertixes++)
                {
                    Console.Write(iVertixes + ": ");

                    foreach (WeightEdge edge in _GraphsWeithedAdj[iGraph].Vertexes[iVertixes])
                    {
                        Console.Write("{0},{1}", edge.VertexTo, edge.Weight);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }


    }

    public class GraphWeithedAdj
    {
        public int start;
        public int finish;
        public int weight;
        public List<WeightEdge>[] Vertexes;
    }

    public class WeightEdge
    {
        public int VertexTo;
        public int Weight;
    }
}
