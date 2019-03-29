using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximu_Heap2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            input.Insert(0, -1);
            BuildMaxHeap(input);
            input.RemoveAt(0);
            Console.WriteLine(string.Join(' ', input));
            Console.ReadLine();
        }

        public static void MaxHeapify(List<int> heap, int i)
        {
            int largest;
            int l = Left(i);
            int r = Right(i);

            if (l <= heap.Count - 1 && heap[l] > heap[i])
            {
                largest = l;
            }
            else
            {
                largest = i;
            }
            if (r <= heap.Count - 1 && heap[r] > heap[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                var temp = heap[i];
                heap[i] = heap[largest];
                heap[largest] = temp;
                MaxHeapify(heap, largest);
            }
        }
        public static void BuildMaxHeap(List<int> heap)
        {
            for (int i = (heap.Count - 1) / 2; i >= 1; i--)
            {
                MaxHeapify(heap, i);
            }
        }

        private static int Parent(int i) => i / 2;
        private static int Left(int i) => i * 2;
        private static int Right(int i) => i * 2 + 1;
    }
}
