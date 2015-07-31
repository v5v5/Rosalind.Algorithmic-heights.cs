using System;
using System.IO;

namespace Rosalind.Algorithmic_heights
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data("Building a Heap.txt");
            //data.Print();

            //BuildingAHeap(data);
            BuildingAHeap1(data);
            //data.PrintVector();
            data.PrintVectorToFile();
        }

        private static void BuildingAHeap1(Data data)
        {
            for (int i = data._vector.Length / 2; i >= 0; i--)
            {
                heapify(data, i);
            }
        }

        private static void heapify(Data data, int i)
        {
            int rightnode = 2 * i + 2;
            int leftnode = 2 * i + 1;
            int largest = i;

            if (leftnode < data._vector.Length && data._vector[leftnode] > data._vector[largest])
                largest = leftnode;
            if (rightnode < data._vector.Length && data._vector[rightnode] > data._vector[largest])
                largest = rightnode;
            if (largest != i)
            {
                int tmp = data._vector[largest];
                data._vector[largest] = data._vector[i];
                data._vector[i] = tmp;

                heapify(data, largest);
            }
        }

        private static void BuildingAHeap(Data data)
        {
            //for (int i = 0; i < data._vector.Length / 2; i++)
            for (int i = data._vector.Length - 1; i > 0; i--)
            {
                for (int j = i; j > 0; j--)
                {
                    swim2(data, j);
                }
                //sink(data, i);
            }
        }

        private static bool swim2(Data data, int i)
        {
            int c = i;
            int p = (c - 1) / 2;

            //while (c > 0 && (data._vector[p] < data._vector[c]))
            if (data._vector[p] < data._vector[c])
            {
                int tmp = data._vector[c];
                data._vector[c] = data._vector[p];
                data._vector[p] = tmp;

                return true;

                //c = p;
                //p = (c - 1) / 2;
            }
            return false;
        }

        private static void swim1(Data data, int i)
        {
            int c = i;
            int p = (c - 1) / 2;

            while (c > 0 && (data._vector[p] < data._vector[c]))
            {
                int tmp = data._vector[c];
                data._vector[c] = data._vector[p];
                data._vector[p] = tmp;

                c = p;
                p = (c - 1) / 2;
            }
        }

        private static void swim(Data data, int i)
        {
            if (data._vector[(i - 1) / 2] < data._vector[i])
            {
                int tmp = data._vector[i];
                data._vector[i] = data._vector[(i - 1) / 2];
                data._vector[(i - 1) / 2] = tmp;
            }
        }

        private static void sink(Data data, int k)
        {
            while (2 * k < data._vector.Length - 1)
            {
                int j = 2 * k + 1;

                if (j < data._vector.Length && data._vector[j] < data._vector[j + 1]) j++;
                if (!(data._vector[k] < data._vector[j])) break;

                int tmp = data._vector[k];
                data._vector[k] = data._vector[j];
                data._vector[j] = tmp;

                k = j;
            }
        }
    }
}
