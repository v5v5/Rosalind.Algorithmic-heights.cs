using _SharedFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Satisfiability
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSatisfiability data = new DataSatisfiability("2-Satisfiability.txt");
            data.Print();
            Console.WriteLine("\r\nFinish!");
            Console.ReadKey();
        }
    }
}
