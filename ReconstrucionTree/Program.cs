using System;
using System.Collections.Generic;
using System.Linq;

namespace ReconstrucionTree
{
    class Program
    {
        private static int Count;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var preOrder = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var inOrder = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Reconstruction(0, inOrder.Count, preOrder, inOrder);
            Console.ReadLine();
        }

        public static void Reconstruction(int l, int r, List<int> preOrder, List<int> inOrder)
        {
            if (l >= r)
            {
                return;
            }

            int c = preOrder[Count++];
            int m = inOrder.IndexOf(c);

            Reconstruction(l, m, preOrder, inOrder);
            Reconstruction(m + 1, r, preOrder, inOrder);

            Console.WriteLine(c);
        }
    }
}
