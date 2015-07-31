using System;
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
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + fileName;
            return File.ReadAllText(resourceName);
        }

        public static void Print(int a)
        {
            Console.WriteLine(a);
        }

        public static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                Console.Write(" ");
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

    }
}
