using _SharedFiles;
using System;
using System.Collections.Generic;

namespace _3SUM
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataArrays data = new DataArrays("3SUM.txt");

            //Utils.Print(data._count);
            //Utils.Print(data._lenght);
            //Utils.PrintArrays(data._arrays);

            int[][] results = _3Sum(data);

            //Utils.PrintArrays(results);
            //Console.ReadKey();

            Utils.PrintArraysToFile(results);
            //Utils.PrintArrays(results);
            Console.WriteLine("Finished.");
            Console.ReadKey();
        }

        private static int[][] _3Sum1(DataArrays data)
        {
            return null;
        }

        private static int[][] _3Sum(DataArrays data)
        {
            int[][] result = new int[data._count][];

            for (int i = 0; i < data._count; i++)
            {
                //result[i] = _3SumZero2(data._arrays[i]);
                result[i] = _3SumZero3(data._arrays[i]);
            }

            return result;
        }

        private static int[] _3SumZero2(int[] a)
        {
            int[] aSorted = new int[a.Length];
            Array.Copy(a, aSorted, a.Length);
            Array.Sort(aSorted);

            for (int i = 0; i < aSorted.Length - 3; i++)
            {
                int va = aSorted[i];
                int start = i + 1;
                int end = aSorted.Length - 1;

                while (start < end)
                {
                    int vb = aSorted[start];
                    int vc = aSorted[end];
                    if (va + vb + vc == 0)
                    {
                        int[] r = { Array.IndexOf(a, va) + 1, Array.IndexOf(a, vb) + 1, Array.IndexOf(a, vc) + 1 };
                        Array.Sort(r);
                        return r;
                        // Continue search for all triplet combinations summing to zero.
                        //start = start + 1;
                        //end = end - 1;
                    }
                    else if (va + vb + vc > 0)
                    {
                        end = end - 1;
                    }
                    else
                    {
                        start = start + 1;
                    }
                }
            }
            return new int[1] { -1 };
        }

        private static int[] _3SumZero3(int[] a)
        {
            Dictionary<int, List<int>> Hash = new Dictionary<int, List<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!Hash.ContainsKey(a[i]))
                {
                    Hash.Add(a[i], new List<int>());
                }
                Hash[a[i]].Add(i);
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    int other = -(a[i] + a[j]);

                    if (!Hash.ContainsKey(other))
                    {
                        continue;
                    }

                    int[] r = { i + 1, j + 1, Hash[other][0] + 1 };
                    Array.Sort(r);
                    return r;
                }
            }
            return new int[1] { -1 };
        }

    }
}
