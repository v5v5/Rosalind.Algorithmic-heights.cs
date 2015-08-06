using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median
{
    class Program
    {
        static void Main(string[] args)
        {
            DataMedian data = new DataMedian("Median.txt");
            //data.Print();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int m = Median0(data.a, data.median);

            Console.WriteLine(m);
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int Median0(int[] a, int median)
        {
            int r = Selection(a, 0, a.Length - 1, median);

            return r;
        }

        private static int Selection(int[] a, int lo, int hi, int median)
        {
            int v = a.Length / 2;

            int LengthV;

            int q = _3WayPartition1(a, 0, a.Length - 1, v, out LengthV);

            int LengthL = q;

            if (v <= LengthL)
            {
                return Selection(a, 0, q - 1, median);
            }
            else if (v > LengthL + LengthV)
            {
                return Selection(a, LengthL + LengthV, a.Length - 1, median);
            }
            return v;
        }

        public static int _3WayPartition1(int[] a, int lo, int hi, int k, out int LengthV)
        {
            int QOld, QNew;

            int q = _2WayPartition1(a, lo, hi, k);
            QOld = q;

            int pivot = a[q];
            q--;
            int i = 0;
            while (i < q)
            {
                if (a[i] == pivot && a[i] != a[q])
                {
                    Utils.exch(a, i, q);
                    i++;
                }
                else if (a[i] != pivot)
                {
                    i++;
                }
                else
                {
                    q--;
                }
            }

            QNew = q;
            LengthV = QNew - QOld + 1;
            return q;
        }

        public static int _2WayPartition1(int[] a, int lo, int hi, int k)
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
