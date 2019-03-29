using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace Matix_Chan_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = new List<IEnumerable<int>>();
            for (int i = 0; i < n; i++)
            {
                input.Add(Console.ReadLine().Split(' ').Select(int.Parse));
            }

            var m = new int[n + 1, n + 1];
            var p = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
                p[i] = input[i].ElementAt(0);
            }
            p[p.Length - 1] = input.Last().ElementAt(1);

            for (int l = 2; l <= n; l++)
            {
                for (int i = 1; i <= n - l + 1; i++)
                {
                    int j = i + l - 1;
                    m[i, j] = int.MaxValue;
                    for (int k = i; k < j; k++)
                    {
                        m[i, j] = Min(m[i, j], m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j]);
                    }
                }
            }
            Console.WriteLine(m[1, n]);
            Console.ReadLine();
        }
    }
}
