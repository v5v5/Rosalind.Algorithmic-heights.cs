using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMedian data = new DataMedian("Partial Sort.txt");
            //data.Print();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int[] r = Partial_Sort(data.a, data.param);

            Utils.PrintArrayToFile(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int[] Partial_Sort(int[] a, int param)
        {
            QuickSort(a, 0, a.Length - 1);

            int[] dest = new int[param];
            Array.Copy(a, dest, param);
            return dest;
        }

        private static void QuickSort(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi);
            QuickSort(a, lo, j - 1);
            QuickSort(a, j + 1, hi);
        }

        private static int Partition(int[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            while (true)
            {
                while (a[++i] < a[lo])
                    if (i == hi) break;
                while (a[lo] < a[--j])
                    if (j == lo) break;
                if (i >= j) break;
                Utils.exch(a, i, j);
            }
            Utils.exch(a, lo, j);
            return j;
        }
    }
}
