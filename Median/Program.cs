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

            int m = Median0(data.a, data.param - 1);

            Console.WriteLine(m);
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int Median0(int[] a, int param)
        {
            int r = Selection(a, 0, a.Length - 1, param);
            //int r = Selection1(a, 0, a.Length - 1, median);

            return r;
        }

        private static int Selection1(int[] a, int lo, int hi, int kth)
        {
            int x = lo, y = hi;
            int j = hi, k = 0, i = hi;

            while (i > x + k)
            {
                if (a[i] > a[x])
                {
                    if (i != j)
                    {
                        Utils.exch(a, i, j);
                    }
                    j--; i--;
                }
                else if (a[i] == a[x])
                {
                    k++;
                    if (i != x + k)
                    {
                        Utils.exch(a, i, x + k);
                    }
                }
                else
                {
                    i--;
                }
            }

            // x..x+k : l
            // x+k+1..j : < l
            // j+1..y : > l
            int n = Math.Min(k, j - x - k - 1);

            for(int ii = 0; ii < n; ii++)
            {
                Utils.exch(a, x + ii, j - ii);
            }
            // x..j-k-1 : < l
            // j-k..j : l
            // j+1..y : > l
            if ((kth >= j - k) && (kth <= j))
            {
                return a[kth];
            }
            else if (kth < j - k)
            {
                return Selection1(a, x, j - k - 1, kth);
            }
            else
            {
                return Selection1(a, j + 1, y, kth);
            }
        }

        private static int Selection(int[] a, int lo, int hi, int k)
        {
            int v = a[k]; // a[lo + (hi - lo) / 2];

            int LengthV;

            Utils.exch(a, lo, k);

            int LengthL = _3WayPartition1(a, lo, hi, out LengthV);

            if (k < LengthL)
            {
                return Selection(a, lo, LengthL - 1, k);
            }
            else if (k > LengthL + LengthV - 1)
            {
                return Selection(a, LengthL + LengthV, hi, k);
            }
            return v;
        }

        public static int _3WayPartition1(int[] a, int lo, int hi, out int LengthV)
        {
            int q = _2WayPartition1(a, lo, hi);

            LengthV = 1;

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
                    LengthV++;
                }
            }

            return q + 1;
        }

        public static int _2WayPartition1(int[] a, int lo, int hi)
        {
            int index = -1, position = -1, aperture = a[lo];
            while (index < hi)
            {
                index++;
                if (a[index] <= aperture)
                {
                    Utils.exch(a, index, position + 1);
                    position++;
                }
            }
            Utils.exch(a, lo, position);
            return position;
        }

    }
}
