using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Tmp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();

            hash.Add(0, new List<int>());
            hash.Add(0, new List<int>());

            List<int> value;

            hash.TryGetValue(0, out value);

            Console.WriteLine(value);
            Console.WriteLine(value);

            Console.ReadKey();

        }
    }
}
