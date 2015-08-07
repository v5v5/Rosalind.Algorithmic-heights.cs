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

        public static string GetFileContent(string fileName)
        {
           return File.ReadAllText(GetFullFilePath(fileName));
        }

        public static string GetFullFilePath(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + fileName;
        }

        public static void PrintArrayX(string[] a)
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

        public static void PrintArrayToFileX(string[] a)
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
                    if (null == a[i])
                    {
                        continue;
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
