using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _SharedFiles
{
    class Utils
    {
        public static void exch(int[] a, int i, int j)
        {
            int tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        internal static void PrintGraphs(GraphsArrayOfList graphs)
        {
            Console.WriteLine(graphs._count);
            Console.WriteLine();

            for(int i = 0; i < graphs._GraphsArrayOfList.Length; i++)
            {

                for (int j = 0; j < graphs._GraphsArrayOfList[i].Vertexes.Length; j++)
                {
                    Console.Write(j + 1);
                    Console.Write(": ");

                    List<int> l = graphs._GraphsArrayOfList[i].Vertexes[j];

                    foreach(int v in l)
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

        public static void PrintGraphs(DataGraphs graphs)
        {
            Console.WriteLine(graphs._count);
            Console.WriteLine();

            for(int i = 0; i < graphs._count; i++)
            {
                Console.Write(graphs._graphs[i].CountVerticles);
                Console.Write(" ");
                Console.WriteLine(graphs._graphs[i].CountEdges);

                for (int j = 0; j < graphs._graphs[i].CountEdges; j++)
                {
                    Console.Write(graphs._graphs[i].edges[j].v0);
                    Console.Write(" ");
                    Console.WriteLine(graphs._graphs[i].edges[j].v1);
                }

                Console.WriteLine();
            }
        }

        public static string GetFileContent(string fileName)
        {
           return File.ReadAllText(GetFullFilePath(fileName));
        }

        public static string GetFullFilePath(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + fileName;
        }

        public static void Print(int a)
        {
            Console.WriteLine(a);
        }

        public static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(" ");
                }
                Console.Write(a[i]);
            }
        }

        public static void PrintArrays(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (i != 0)
                {
                    Console.WriteLine();
                }
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (j != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(a[i][j]);
                }
            }
        }

        public static void PrintArrayToFile(int[] a)
        {
            string path_exe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (StreamWriter writer = new StreamWriter(path_exe + @"\out.txt"))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i != 0)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(a[i].ToString());
                }
            }
        }

        public static void PrintArraysToFile(int[][] a)
        {
            string path_exe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (StreamWriter writer = new StreamWriter(path_exe + @"\out.txt"))
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i != 0)
                    {
                        writer.WriteLine();
                    }
                    for (int j = 0; j < a[i].Length; j++)
                    {
                        if (j != 0)
                        {
                            writer.Write(" ");
                        }
                        writer.Write(a[i][j]);
                    }
                }
            }
        }

    }
}
