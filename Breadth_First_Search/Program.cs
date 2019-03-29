using System;
using System.Collections;
using System.Linq;
using static System.Linq.Enumerable;

namespace Breadth_First_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                matrix[i] = new int[n + 1];
                matrix[i] = Repeat(0, n + 1).ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse);
                for (int j = 0; j < input.ElementAt(1); j++)
                {
                    matrix[input.ElementAt(0)][input.ElementAt(2 + j)] = 1;
                }
            }
            Bfs(n, 1, matrix);
        }

        public static void Bfs(int n, int rootNode, int[][] matrix)
        {
            var colors = Repeat(Color.White, n + 1).ToArray();
            var distances = Repeat(int.MaxValue, n + 1).ToArray();
            var que = new Queue();

            colors[rootNode] = Color.Gray;
            distances[rootNode] = 0;
            que.Enqueue(rootNode);

            while (que.Count != 0)
            {
                int referensedNode = (int)que.Dequeue();
                for (int i = 1; i < matrix.Length; i++)
                {
                    if (matrix[referensedNode][i] == 1 && colors[i] == Color.White)
                    {
                        colors[i] = Color.Gray;
                        distances[i] = distances[referensedNode] + 1;
                        que.Enqueue(i);
                    }
                }
                colors[referensedNode] = Color.Black;
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i} {distances[i]}");
            }
            Console.ReadLine();
        }

        enum Color
        {
            White = 0,
            Gray,
            Black
        }
    }
}
