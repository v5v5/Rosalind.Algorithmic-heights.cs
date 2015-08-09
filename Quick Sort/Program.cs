using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArray data = new DataArray("Quick Sort.txt");
            //data.Print();
            //Console.WriteLine("\r\nFinish!");
            //Console.ReadKey();

            QuickSort(data._vector, 0, data._vector.Length - 1);

            data.PrintVectorToFile();
            Console.WriteLine("\r\nFinish!");
            Console.ReadKey();
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
