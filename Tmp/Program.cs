using System;
using System.Collections.Generic;
using System.Linq;

namespace _Tmp
{
    class Program
    {
        static SortedDictionary<int, int> hash = new SortedDictionary<int, int>();

        static void Main(string[] args)
        {
            hash.Add(1, 1);
            hash.Add(0, 4);
            hash.Add(7, 8);
            hash.Add(2, 8);
            hash.Add(5, 8);
            Print();

            hash.Remove(hash.Keys.First());

            Print();

            Console.ReadKey();
        }

        static void Print()
        {
            foreach(int key in hash.Keys)
            {
                Console.Write(key);
                Console.Write(": ");
                int v;
                hash.TryGetValue(key, out v);
                Console.Write(v);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
