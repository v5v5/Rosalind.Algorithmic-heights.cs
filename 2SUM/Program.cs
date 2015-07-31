using _SharedFiles;
using System;

namespace _2SUM
{
    class Program
    {
        static void Main(string[] args)
        {

            DataArrays data = new DataArrays("2SUM.txt");
            Utils.Print(data._count);
            Utils.Print(data._lenght);
            Utils.PrintArray(data._arrays);

            //MergeSort(data);
            //data.PrintVector();
            //data.PrintVectorToFile();

            Console.ReadKey();

        }
    }
}
