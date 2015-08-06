using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _SharedFiles
{
    class DataMedian
    {
        public int count;
        public int[] a;
        public int median;

        public DataMedian(string fileName)
        {
            string fileContent = Utils.GetFileContent(fileName);
            string[] integerStrings = fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            count = int.Parse(integerStrings[0]);
            a = new int[integerStrings.Length - 2];
            for (int i = 0; i < a.Length; i++)
                a[i] = int.Parse(integerStrings[i + 1]);

            median = int.Parse(integerStrings[integerStrings.Length - 1]);
        }

        public void Print()
        {
            Console.WriteLine(count);
            for(int i = 0; i< a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(median);
        }
    }
}
