using System;
using System.Collections.Generic;
using System.IO;

namespace _SharedFiles
{
    class DataDirectedGraphs
    {
        public int _count;
        public GraphArrayOfList[] _GraphsArrayOfList;

        public DataDirectedGraphs(string fileName)
        {
            string filePath = Utils.GetFullFilePath(fileName);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    int iLine = 0;
                    int iGraph = -1;
                    int iEdge = 0;
                    bool curLineIsGraphArgs = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        switch (iLine)
                        {
                            case 0:
                                _count = int.Parse(line);
                                _GraphsArrayOfList = new GraphArrayOfList[_count];
                                break;
                            default:
                                if (line == "")
                                {
                                    iGraph++;
                                    curLineIsGraphArgs = true;
                                    break;
                                }

                                if (curLineIsGraphArgs)
                                {
                                    curLineIsGraphArgs = false;
                                    string[] args = line.Split(' ');
                                    int countVerticles = int.Parse(args[0]);
                                    int countEdges = int.Parse(args[1]);

                                    _GraphsArrayOfList[iGraph] = new GraphArrayOfList();
                                    _GraphsArrayOfList[iGraph].Vertexes = new List<int>[countVerticles];
                                    for (int i = 0; i < _GraphsArrayOfList[iGraph].Vertexes.Length; i++)
                                    {
                                        _GraphsArrayOfList[iGraph].Vertexes[i] = new List<int>();
                                    }

                                    iEdge = 0;
                                }
                                else
                                {
                                    string[] edge = line.Split(' ');
                                    int v0 = int.Parse(edge[0]);
                                    int v1 = int.Parse(edge[1]);

                                    _GraphsArrayOfList[iGraph].Vertexes[v0 - 1].Add(v1 - 1);

                                    iEdge++;
                                }

                                break;
                        }
                        iLine++;
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

            for(int iGraph = 0; iGraph < _GraphsArrayOfList.Length; iGraph++)
            {
                for (int iVertixes = 0; iVertixes < _GraphsArrayOfList[iGraph].Vertexes.Length; iVertixes++)
                {
                    Console.Write(iVertixes + ": ");

                    foreach (int edge in _GraphsArrayOfList[iGraph].Vertexes[iVertixes])
                    {
                        Console.Write(edge);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public class GraphArrayOfList
        {
            public List<int>[] Vertexes;
        }

    }
}
