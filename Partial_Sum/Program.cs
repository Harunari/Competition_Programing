using System;
using System.Linq;

namespace Partial_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            var A = int.Parse(Console.ReadLine());
            var dp = new bool[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new bool[A + 1];
            }
            dp[0][0] = true;
            for (int i = 1; i <= A; i++)
            {
                dp[0][i] = false;
            }
            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= A; j++)
                {
                    var num = input.ElementAt(i - 1);
                    dp[i][j] = dp[i - 1][j];
                    if (num <= j)
                    {
                        dp[i][j] = dp[i][j] ? true : dp[i - 1][j - num];
                    }
                }
            }
            Console.WriteLine(dp[n][A] ? "YES" : "NO");
            Console.ReadLine();
        }
    }
}
