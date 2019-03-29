using System;
using static System.Math;

namespace Maximum_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var c = new int[n + 1];
            c[0] = 0;
            
            for (int i = 1; i <= n; i++)
            {
                c[i] = Max(c[i - 1], c[i - 1] + int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(c[n]);
            Console.ReadLine();

        }
    }
}
