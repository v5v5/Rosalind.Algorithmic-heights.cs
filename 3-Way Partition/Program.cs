using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Way_Partition
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArray data = new DataArray("3-Way Partition.txt");
            //data.Print();
            //Console.WriteLine();

            //_3WayPartition(data._vector, 0, data._vector.Length - 1);
            _3WayPartition1(data._vector, 0, data._vector.Length - 1);
            data.Print();
            //data.PrintVectorToFile();
            //Console.WriteLine();

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static void _3WayPartition(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            int v = a[lo];
            int i = lo;
            while (i <= gt)
            {
                int cmp = (a[i] - v);
                if (cmp < 0) Utils.exch(a, lt++, i++);
                else if (cmp > 0) Utils.exch(a, i, gt--);
                else i++;
            }
        }

        public static int _3WayPartition1(int[] a, int lo, int hi)
        {
            int q = _2WayPartition1(a, lo, hi);
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
            return q;
        }

        public static int _2WayPartition1(int[] a, int lo, int hi)
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
