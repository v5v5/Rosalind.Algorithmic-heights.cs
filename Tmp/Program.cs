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
            //hash.Add(1, 1);
            //hash.Add(0, 4);
            //hash.Add(7, 8);
            //hash.Add(2, 8);
            //hash.Add(5, 8);
            hash[1] = 1;
            hash[0] = 4;
            hash[7] = 8;
            hash[2] = 8;
            hash[5] = 8;
            hash[5] = 10;
            Print();

            Console.WriteLine("value with min key: {0}", hash[hash.Keys.First()]);
            Console.WriteLine();

            try {
                int v = hash[3];
                Console.WriteLine("value with key 3: {0}", v);
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't get value by key 3");
                Console.WriteLine();
            }

            hash.Remove(hash.Keys.First());

            Print();

            hash.Add(0, 5);
            Print();

            //hash.
            //Print();

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
