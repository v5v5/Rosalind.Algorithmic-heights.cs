using System;
using System.IO;
using System.Reflection;

namespace Rosalind.Algorithmic_heights
{
    internal class Data
    {
        public int _count;
        public int[] _vector;

        public Data(string fileName)
        {
            string fileContent = StdIn.getFileContent(fileName);
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            _count = int.Parse(integerStrings[0]);
            _vector = new int[integerStrings.Length - 1];
            for (int i = 0; i < _vector.Length; i++)
                _vector[i] = int.Parse(integerStrings[i + 1]);
        }

        internal void PrintVector()
        {
            for (int i = 0; i < _vector.Length; i++)
            {
                Console.Write(_vector[i]);
                Console.Write(" ");
            }
            Console.ReadKey();
        }

        internal void PrintVectorToFile()
        {
            string path_exe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //using (StreamWriter writer = new StreamWriter(File.Open("d:\\tmp.txt", FileMode.Create)))
            using (StreamWriter writer = new StreamWriter(path_exe + @"\out.txt"))
            {
                for (int i = 0; i < _vector.Length; i++)
                {
                    if (i != 0)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(_vector[i].ToString());
                }
            }
        }

        public void Print()
        {
            //Console.WriteLine("count: {0}", count);
            Console.WriteLine(_count);
            for (int i = 0; i < _vector.Length; i++)
            {
                //Console.Write("v[{0}]", i);
                //Console.Write(":{0}", vector[i]);
                Console.Write(_vector[i]);
                Console.Write(" ");
            }
            Console.WriteLine("");
            //            Console.ReadKey();
        }
    }
}