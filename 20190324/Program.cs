using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _20190324
{
    class Program
    {
        public static int[][] dp;
        static void Main(string[] args)
        {
            var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var q = new List<int[]>();
            var str = Console.ReadLine();
            int max = 0; int min = int.MaxValue;
            for (int i = 0; i < nq[1]; i++)
            {
                q.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
                min = min > q[i][0] ? q[i][0] : min;
                max = max < q[i][1] ? q[i][1] : max;
            }

            dp = new int[max - min + 1][];
            for (int i = min; i <= max; i++) {
                dp[i] = new int[max - min + 1];
            }
            
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            dp[min - 1][min - 1] = 0;
            for (int i = min; i <= max; i++)
            {
                for (int j = i + 1; j <= max; j++)
                {
                    if (str[j - 2] == 'A' && str[j - 1] == 'C')
                    {
                        dp[i][j] = dp[i][j - 1] + 1;
                    }
                    else
                    {
                        dp[i][j] = dp[i][j - 1];
                    }
                }
            }
            
            for (int i = 0; i < nq[1]; i++)
            {
                Console.WriteLine(dp[q[i][0]][q[i][1]]);
            }
            Console.Out.Flush();
        }
    }
}
