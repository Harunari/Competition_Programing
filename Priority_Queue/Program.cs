using System;
using System.Collections.Generic;

namespace Priority_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new List<int> { -1 };
            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                if (input[0][0] == 'i')
                {
                    Insert(int.Parse(input[1]), heap);
                }
                else if (input[0][1] == 'x')
                {
                    Console.WriteLine(HeapExtractMax(heap));
                }
                else
                {
                    break;
                }
            }
            Console.ReadLine();

        }

        public static void Insert(int key, List<int> heap)
        {
            heap.Add(int.MinValue);
            HeapIncreaseKey(heap, heap.Count - 1, key);
        }

        public static void HeapIncreaseKey(List<int> heap, int index, int key)
        {
            if (key < heap[index])
            {
                throw new Exception("エラー：新しいキーは現在のキーより小さい");
            }
            heap[index] = key;
            while (index > 1 && heap[Parent(index)] < heap[index])
            {
                var temp = heap[index];
                heap[index] = heap[Parent(index)];
                heap[Parent(index)] = temp;
                index = Parent(index);
            }
        }
        public static int HeapExtractMax(List<int> heap)
        {
            if (heap.Count - 1  <= 0)
            {
                throw new Exception("エラー：ヒープアンダーフロー");
            }
            int max = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MaxHeapify(heap, 1);
            return max;
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

        private static int Parent(int i) => i / 2;
        private static int Left(int i) => i * 2;
        private static int Right(int i) => i * 2 + 1;
    }
}
