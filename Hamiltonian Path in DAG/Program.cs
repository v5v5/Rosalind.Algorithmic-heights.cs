using _SharedFiles;
using System;

namespace Hamiltonian_Path_in_DAG
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDirectedGraphs data = new DataDirectedGraphs("Hamiltonian Path in DAG.txt");
            //data.Print();
            //Console.WriteLine();
            //Console.WriteLine("Finish!");
            //Console.ReadKey();

            int[][] r = HamiltonianPathInDAG(data);

            Utils.PrintArrays(r);
            Console.WriteLine();
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        private static int[][] HamiltonianPathInDAG(DataDirectedGraphs data)
        {
            int n = data._GraphsArrayOfList.Length;
            int[][] r = new int[n][];
            for(int i = 0; i < n; i++)
            {
                r[i] = HamiltonianPath(data._GraphsArrayOfList[i]);
            }
            return r;
        }

        private static int[] HamiltonianPath(DataDirectedGraphs.GraphArrayOfList g)
        {
            return new int[] { -1 };
        }
    }
}
