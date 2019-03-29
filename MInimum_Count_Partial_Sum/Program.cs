using System;
using System.Linq;

namespace MInimum_Count_Partial_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            int A = int.Parse(Console.ReadLine());

            var dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[A + 1];
            }
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= A; j++) { dp[i][j] = 100*100; }
            }
            dp[0][0] = 0;
            
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= A; j++)
                {
                    int value = input.ElementAt(i - 1);
                    dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j]);
                    if (j >= value)
                    {
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - value] + 1);
                    }
                }
            }
            if (dp[n][A] == 100*100)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(dp[n][A]);
            }
            Console.ReadLine();
        }
    }
}
