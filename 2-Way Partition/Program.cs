using _SharedFiles;
using System;

namespace _2_Way_Partition
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataArray data = new DataArray("2-Way Partition.txt");
            //data.Print();

            int j = data._vector.Length - 1;

            //while (j != 0)
            {
                j = _2WayPartition(data._vector, 0, j);
            }

            //data.PrintVector();
            data.PrintVectorToFile();

            Console.ReadKey();
        }

        private static int _2WayPartition(int[] a, int lo, int hi)
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
