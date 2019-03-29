using System;
using System.Linq;

namespace Partial_Sum_Counting
{
    class Program
    {
        const int MOD = 1000000009;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            int A = int.Parse(Console.ReadLine());
            var dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[A + 1];
                dp[i][0] = 1;
                for (int j = 1; j <= A; j++)
                {
                    dp[i][j] = 0;
                }
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= A; j++)
                {
                    var num = input.ElementAt(i - 1);
                    dp[i][j] += dp[i - 1][j];
                    dp[i][j] %= MOD;
                    if (j >= num)
                    {
                        dp[i][j] += dp[i - 1][j - num];
                        dp[i][j] %= MOD;
                    }
                }
            }
            Console.WriteLine(dp[n][A]);
            Console.ReadLine();

        }
    }
}
