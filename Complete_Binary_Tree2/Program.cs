using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complete_Binary_Tree2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            var keys = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = 1;
            foreach (var key in keys)
            {
                int parent = Parent(count);
                int left = Left(count);
                int right = Right(count);
                sb.Append($"node {count}: key = {key}, ");

                if (1 <= parent && parent <= n) { sb.Append($"parent key = {keys[parent - 1]}, ");}
                if (1 <= left && left <= n) { sb.Append($"left key = {keys[left - 1]}, "); }
                if (1 <= right && right <= n) { sb.Append($"right key = {keys[right - 1]},"); }
                sb.AppendLine();
                count++;
            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }

        private static int Parent(int i)=> i / 2;
        private static int Left(int i)  => i * 2;
        private static int Right(int i) => i * 2 + 1;
    }
}
