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
            int v = lo + (hi - lo) / 2;

            int LengthV;

            Utils.exch(a, 0, v);

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
            LengthV = QOld - QNew;
            return q + 1;
        }

        public static int _2WayPartition1(int[] a, int lo, int hi, int k)
        {
            int index = -1, position = -1, aperture = a[lo];
            while (index < a.Length - 1)
            {
                index++;
                if (a[index] <= aperture)
                {
                    Utils.exch(a, index, position + 1);
                    position++;
                }
            }
            Utils.exch(a, 0, position);
            return position;
        }

    }
}
