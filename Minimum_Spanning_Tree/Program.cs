using System;
using System.Linq;

namespace Minimum_Spanning_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            var color = Enumerable.Repeat(Color.White, n).ToArray();
        }

        public enum Color
        {
            White = 0,
            Gray,
            Black
        }
    }
}
