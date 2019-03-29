using System;
using System.Collections;
using System.Linq;

namespace Depth_First_Search
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
                for (int j = 0; j <= n; j++)
                {
                    matrix[i][j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse);
                for (int j = 0; j < input.ElementAt(1); j++)
                {
                    matrix[input.ElementAt(0)][input.ElementAt(2 + j)] = 1;
                }
            }
            Dfs(1, n, matrix);
        }

        public static void Dfs(int node, int n, int[][] matrix)
        {
            int time = 0;
            var stack = new Stack();
            var discoverTimes = new int[n + 1];
            var findOutTimes = new int[n + 1];
            var colors = new Color[n + 1];

            stack.Push(node);
            colors[node] = Color.Gray;
            discoverTimes[node] = ++time;

            while (stack.Count != 0)
            {
                int refferensedNode = (int)stack.Peek();
                int nextNode = GetNextNode(refferensedNode, matrix);
                if (nextNode != -1)
                {
                    if (colors[nextNode] == Color.White)
                    {
                        colors[nextNode] = Color.Gray;
                        discoverTimes[nextNode] = ++time;
                        stack.Push(nextNode);
                    }
                }
                else
                {
                    stack.Pop();
                    colors[refferensedNode] = Color.Black;
                    findOutTimes[refferensedNode] = ++time;
                }
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{i} {discoverTimes[i]} {findOutTimes[i]}");
            }
            Console.ReadLine();
            

        }

        public static int GetNextNode(int node, int[][] matrix)
        {
            for (int i = 1; i < matrix[node].Length; i++)
            {
                if (matrix[node][i] == 1)
                {
                    matrix[node][i] = 0;
                    return i;
                }
            }
            return -1;
        } 

        enum Color
        {
            White = 0,
            Gray,
            Black
        }
    }
}
