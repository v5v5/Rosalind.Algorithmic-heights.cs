using System;
using _SharedFiles;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArray data = new DataArray("Merge Sort.txt");
            //data.Print();

            MergeSort(data);
            //data.PrintVector();
            data.PrintVectorToFile();

            Console.ReadKey();
        }

        private static void MergeSort(DataArray data)
        {
            int[] aux = new int[data._vector.Length];
            Sort(data._vector, aux, 0, data._vector.Length - 1);
        }

        private static void Sort(int[] a, int[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            //if (!(a[mid + 1]< a[mid])) return;
            Merge(a, aux, lo, mid, hi);
        }

        private static void Merge(int[] a, int[] aux, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];

            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (aux[j] < aux[i]) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }
    }
}
