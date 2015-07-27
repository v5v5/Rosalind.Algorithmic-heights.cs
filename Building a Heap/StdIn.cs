using System;
using System.IO;
using System.Reflection;

namespace Rosalind.Algorithmic_heights
{
    class StdIn
    {
        private string exePath;
        private int[] integers;
        private int index;

        public StdIn(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //var assemblyName = assembly.GetName().Name;

            exePath = Path.GetDirectoryName(assembly.Location);
            string resourceName = exePath + "\\..\\..\\..\\_Data\\" + fileName;

            string fileContent = File.ReadAllText(resourceName);
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            integers = new int[integerStrings.Length];
            for (int n = 0; n < integerStrings.Length; n++)
                integers[n] = int.Parse(integerStrings[n]);
        }

        public int GetInt()
        {
            int i = index;
            if (i >= integers.Length)
            {
                throw new System.IndexOutOfRangeException();
            }
            index++;
            return integers[i];
        }

        public static string getFileContent(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = Path.GetDirectoryName(assembly.Location) + "\\..\\..\\..\\_Data\\" + fileName;
            return File.ReadAllText(resourceName);
        }
    }
}