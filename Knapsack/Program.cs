using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            var input = new List<IEnumerable<int>>();
            for (int i = 0; i < N; i++)
            {
                input.Add(Console.ReadLine().Split(' ').Select(int.Parse));
            }
            int W = int.Parse(Console.ReadLine());
            var dp = new int[N + 1, W + 1];
            for (int i = 0; i <= W; i++) { dp[0, i] = 0; }
            
            
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    int weight = input[i - 1].ElementAt(0);
                    int value = input[i - 1].ElementAt(1);
                    if (j >= weight)
                    {
                        dp[i, j] = Max(dp[i - 1, j - weight] + value, dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            Console.WriteLine(dp[N, W]);
            Console.ReadLine();
        }
    }
}
