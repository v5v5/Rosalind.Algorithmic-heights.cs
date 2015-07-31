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

            int[][] results = _3Sum1(data);

            //Utils.PrintArrays(results);
            //Console.ReadKey();

            Utils.PrintArraysToFile(results);
        }

        private static int[][] _3Sum1(DataArrays data)
        {
            return null;
        }

        private static int[] SearchPair(int[] a)
        {
            Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();

            for (int i = 0; i < a.Length; i++)
            {
                if (!hash.ContainsKey(a[i]))
                {
                    hash.Add(a[i], new List<int>());
                }
                hash[a[i]].Add(i);
            }

            for (int i = 0; i < a.Length; i++)
            {
                int other = -a[i];

                if (!hash.ContainsKey(other))
                {
                    continue;
                }

                // check values equals zero
                if (other == a[i] && hash[other].Count > 1)
                {
                    return new int[2] { hash[other][0], hash[other][1] };
                }
                else if (other != a[i])
                {
                    return new int[2] { i, hash[other][0] };
                }
            }
            return new int[1] { -1 };
        }

        private static int[][] _3Sum(DataArrays data)
        {
            int[][] result = new int[data._count][];

            for(int i = 0; i < data._count; i++)
            {
                result[i] = _3SumZero(data._arrays[i]);
            }

            return result;
        }

        private static int[] _3SumZero(int[] a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                for(int j = i + 1; j < a.Length; j++)
                {
                    for (int k = j + 1; k < a.Length; k++)
                    {
                        if (a[i] + a[j] + a[k] == 0)
                        {
                            return new int[3] { i + 1, j + 1, k + 1 };
                        }
                    }
                }
            }
            return new int[1] { -1 };
        }
    }
}
