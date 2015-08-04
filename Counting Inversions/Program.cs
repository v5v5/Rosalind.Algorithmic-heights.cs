using _SharedFiles;
using System;

namespace Counting_Inversions
{
    class Program
    {
        static void Main(string[] args)
        {
            DataArray data = new DataArray("Counting Inversions.txt");

            //data.PrintVector();
            //Console.ReadKey();

            long count = InvCount(data._vector);

            Console.WriteLine(count);
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        static long InvCount(int[] arr)
        {
            if (arr.Length < 2)
                return 0;

            int m = (arr.Length + 1) / 2;

            int[] left = new int[m];
            Array.Copy(arr, 0, left, 0, m);

            int[] right = new int[arr.Length - m];
            Array.Copy(arr, m, right, 0, arr.Length - m);

            return InvCount(left) + InvCount(right) + Merge(arr, left, right);
        }

        static private long Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, count = 0;
            while (i < left.Length || j < right.Length)
            {
                if (i == left.Length)
                {
                    arr[i + j] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    arr[i + j] = left[i];
                    i++;
                }
                else
                {
                    arr[i + j] = right[j];
                    count += left.Length - i;
                    j++;
                }
            }
            return count;
        }
    }
}
