using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArray array = new DataArray("Heap Sort.txt");
            //array.Print();
            //Console.WriteLine();

            HeapSort(array);

            array.PrintVectorToFile();
            //Console.WriteLine();

            Console.WriteLine("Finish!");

            Console.ReadKey();
        }

        private static void HeapSort(DataArray data)
        {
            Heapify(data);
            SortDown(data);
        }

        private static void Heapify(DataArray data)
        {
            for(int i = data._vector.Length / 2 - 1; i >= 0; i--)
            {
                Sink(data._vector, i, data._vector.Length);
                // → invariant: a[1, n] in heap order
            }
        }

        private static void SortDown(DataArray data)
        {
            int[] a = data._vector;
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                Swap(a, 0, n - i - 1);
                Sink(a, 0, n - i - 1);
                // → invariant: a[n - i + 1, n] in final position
            }
        }

        private static void Sink(int[] a, int i, int n)
        {
            // {lc,rc,mc} = {left,right,max} child index
            int lc = 2 * i + 1;
            if (lc > n - 1) return; //no children
            int rc = lc + 1;
            int mc = (rc > n - 1) ? lc : (a[lc] > a[rc]) ? lc : rc;
            if (a[i] >= a[mc]) return; // heap ordered
            Swap(a, i, mc);
            Sink(a, mc, n);
        }

        private static void Swap(int[] a, int i, int j)
        {
            int tmp = a[j];
            a[j] = a[i];
            a[i] = tmp;
        }
    }
}
