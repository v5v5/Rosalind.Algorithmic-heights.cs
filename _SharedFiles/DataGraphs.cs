using System;
using System.Collections.Generic;
using System.IO;

namespace _SharedFiles
{
    public class DataGraphs
    {
        public int _count;
        public Graph[] _graphs;

        public DataGraphs(string fileName)
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
                                _graphs = new Graph[_count];
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

                                    _graphs[iGraph] = new Graph();
                                    _graphs[iGraph].CountVerticles = countVerticles;
                                    _graphs[iGraph].CountEdges = countEdges;
                                    _graphs[iGraph].edges = new Edge[countEdges];

                                    iEdge = 0;
                                }
                                else
                                {
                                    string[] edge = line.Split(' ');
                                    _graphs[iGraph].edges[iEdge] = new Edge();
                                    _graphs[iGraph].edges[iEdge].v0 = int.Parse(edge[0]);
                                    _graphs[iGraph].edges[iEdge].v1 = int.Parse(edge[1]);
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
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void Print()
        {
            Console.WriteLine(_count);
            Console.WriteLine();

            for (int i = 0; i < _count; i++)
            {
                Console.Write(_graphs[i].CountVerticles);
                Console.Write(" ");
                Console.WriteLine(_graphs[i].CountEdges);

                for (int j = 0; j < _graphs[i].CountEdges; j++)
                {
                    Console.Write(_graphs[i].edges[j].v0);
                    Console.Write(" ");
                    Console.WriteLine(_graphs[i].edges[j].v1);
                }

                Console.WriteLine();
            }
        }
    }

    public class Graph
    {
        public int CountVerticles;
        public int CountEdges;
        public Edge[] edges;
    }

    public class Edge
    {
        public int v0;
        public int v1;
    }

    public class GraphsArrayOfList
    {
        public int _count;
        public GraphArrayOfList[] _GraphsArrayOfList;

        public GraphsArrayOfList(string fileName)
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
                                    for(int i = 0; i < _GraphsArrayOfList[iGraph].Vertexes.Length; i++)
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
                                    _GraphsArrayOfList[iGraph].Vertexes[v1 - 1].Add(v0 - 1);

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
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void Print()
        {
            Console.WriteLine(_count);
            Console.WriteLine();

            for (int i = 0; i < _GraphsArrayOfList.Length; i++)
            {

                for (int j = 0; j < _GraphsArrayOfList[i].Vertexes.Length; j++)
                {
                    Console.Write(j + 1);
                    Console.Write(": ");

                    List<int> l = _GraphsArrayOfList[i].Vertexes[j];

                    foreach (int v in l)
                    {
                        Console.Write(v + 1);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
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
