using System;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    a[i][j] = 0;
                }
            }


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse);
                for (int j = 0; j < input.ElementAt(1); j++)
                {
                    a[input.ElementAt(0) - 1][input.ElementAt(j + 2) - 1] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                var converted = Array.ConvertAll(a[i], Convert.ToString);
                Console.WriteLine(string.Join(' ', converted));
            }
            Console.ReadLine();
        }
    }
}
