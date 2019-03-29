using System;

namespace Longest_Common_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var x = Console.ReadLine();
                var y = Console.ReadLine();
                var l = x.Length;
                var m = y.Length;
                var C = new int[l + 1, m + 1];
                for (int j = 0; j <= l; j++)
                {
                    C[j, 0] = 0;
                }
                for (int k = 1; k <= m; k++)
                {
                    C[0, k] = 0;
                }
                for (int j = 1; j <= l; j++)
                {
                    for (int k = 1; k <= m; k++)
                    {
                        if (x[j - 1] == y[k - 1])
                        {
                            C[j, k] = C[j - 1, k - 1] + 1;
                        }
                        else if (C[j - 1, k] >= C[j, k - 1])
                        {
                            C[j, k] = C[j - 1, k];
                        }
                        else
                        {
                            C[j, k] = C[j, k - 1];
                        }
                    }
                }
                Console.WriteLine(C[l, m]);
            }
            Console.ReadLine();
        }
    }
}
