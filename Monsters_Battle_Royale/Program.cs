using System;
using System.Collections.Generic;
using System.Linq;

namespace Monsters_Battle_Royale
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < n - 1; i++)
            {
                int x, y;
                if (input[i] > input[i + 1])
                {
                    x = input[i];
                    y = input[i + 1];
                }
                else
                {
                    y = input[i];
                    x = input[i + 1];
                }
                var mod = x % y;
                while (mod != 0)
                {
                    if (mod > y) { x = mod; }
                    else
                    {
                        x = y;
                        y = mod;
                    }

                    mod = x % y;
                }
                input[i + 1] = y;
            }


            Console.WriteLine(input[n - 1]);
            Console.ReadLine();
        }
    }
}
