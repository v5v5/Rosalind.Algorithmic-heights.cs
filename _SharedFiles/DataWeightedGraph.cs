using System;
using System.Collections.Generic;
using System.IO;

namespace _SharedFiles
{
    class DataWeightedGraph
    {
        public int countVertexes;
        public int countEdges;
        public List<WeightEdge>[] Vertexes;

        public DataWeightedGraph(string fileName)
        {
            string filePath = Utils.GetFullFilePath(fileName);

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    line = reader.ReadLine();

                    string[] s = line.Split(' ');
                    countVertexes = int.Parse(s[0]);
                    countEdges = int.Parse(s[1]);

                    Vertexes = new List<WeightEdge>[countVertexes];

                    while ((line = reader.ReadLine()) != null)
                    {
                        s = line.Split(' ');

                        int vertexFrom = int.Parse(s[0]) - 1;
                        int vertexTo = int.Parse(s[1]) - 1;
                        int weight = int.Parse(s[2]);

                        if (null == Vertexes[vertexFrom])
                        {
                            Vertexes[vertexFrom] = new List<WeightEdge>();
                        }
                        if (null == Vertexes[vertexTo])
                        {
                            Vertexes[vertexTo] = new List<WeightEdge>();
                        }

                        Vertexes[vertexFrom].Add(new WeightEdge() { VertexTo = vertexTo, Weight = weight });
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
            Console.Write(countVertexes);
            Console.Write(" ");
            Console.WriteLine(countEdges);

            for(int i = 0; i < Vertexes.Length; i++)
            {
                Console.Write("{0}: ", i + 1);

                if (null == Vertexes[i])
                {
                    Console.WriteLine();
                    continue;
                }

                foreach(WeightEdge e in Vertexes[i])
                {
                    Console.Write("{0},{1} ", e.VertexTo + 1, e.Weight);
                }
                Console.WriteLine();
            }
        }
    }

    public class WeightEdge
    {
        public int VertexTo;
        public int Weight;
    }
}
