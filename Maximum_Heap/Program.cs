using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Maximum_Heap
{
    class Program
    {
        private const int NIL = -1;

        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            int n = int.Parse(Console.ReadLine());
            var inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            // 空ノードもつくる
            var nodes = new List<int>{ NIL };
            inputList.ForEach(item => nodes.Add(item));
            BuildMaxHeap(nodes);
            
            nodes.RemoveAt(0);
            Console.WriteLine($" {string.Join(" ", nodes)}");
            Console.Out.Flush();
            Console.ReadLine();

        }

        private static void BuildMaxHeap(List<int> nodes)
        {
            for (int index = (nodes.Count - 1) / 2; index >= 1; index--)
            {
                MaxHeapify(nodes, index);
            }
        }
        private static void MaxHeapify(List<int> nodes, int index)
        {
            int l = index * 2;
            int r = index * 2 + 1;
            int largest;
            if (l <= nodes.Count - 1 && nodes[l] > nodes[index])
            {
                largest = l;
            }
            else
            {
                largest = index;
            }
            if (r <= nodes.Count - 1 && nodes[r] > nodes[largest])
            {
                largest = r;
            }


            if (largest != index)
            {
                int temp = nodes[index];
                nodes[index] = nodes[largest];
                nodes[largest] = temp;
                MaxHeapify(nodes, largest);
            }

        }
    }
}
