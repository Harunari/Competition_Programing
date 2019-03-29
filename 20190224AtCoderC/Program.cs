using System;
using System.Collections.Generic;
using System.Linq;

namespace _20190224AtCoderC
{
    class Program
    {
        public readonly static int _INF = (int)Math.Pow(10, 9);
        public static int N, A, B, C;
        public static List<int> L;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            N = input.ElementAt(0);
            A = input.ElementAt(1);
            B = input.ElementAt(2);
            C = input.ElementAt(3);

            L = new List<int>();
            for (int i = 0; i < N; i++)
            {
                L.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(Dfs(0, 0, 0, 0));
            Console.ReadLine();
        }

        public static int Dfs(int n, int a, int b, int c)
        {
            if (N == n)
            {
                if (Math.Min(Math.Min(a, b), c) > 0)
                {
                    return Math.Abs(A - a) + Math.Abs(B - b) + Math.Abs(C - c) - 30;
                }
                else { return _INF; }
            }

            var result0 = Dfs(n + 1, a, b, c);
            var result1 = Dfs(n + 1, a + L[n], b, c) + 10;
            var result2 = Dfs(n + 1, a, b + L[n], c) + 10;
            var result3 = Dfs(n + 1, a, b, c + L[n]) + 10;
            return Math.Min(Math.Min(Math.Min(result0, result1), result2), result3);
        }
    }
}
