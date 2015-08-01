using _SharedFiles;
using System;
using System.Collections.Generic;

namespace _2SUM
{
    class Program
    {
        static void Main(string[] args)
        {

            DataArrays data = new DataArrays("2SUM.txt");
            //Utils.Print(data._count);
            //Utils.Print(data._lenght);
            Utils.PrintArrays(data._arrays);

            for (int i = 0; i < data._arrays.Length; i++)
            {
                int[] results = SearchPair(data._arrays[i]);
                Console.WriteLine();
                Utils.PrintArray(results);
            }

            Console.ReadKey();

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
                    return new int[2] { hash[other][0] + 1, hash[other][1] + 1 };
                }
                else if (other != a[i])
                {
                    return new int[2] { i + 1, hash[other][0] + 1 };
                }
            }
            return new int[1] { -1 };
        }

    }
}
