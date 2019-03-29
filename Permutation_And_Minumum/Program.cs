﻿using System;
using System.Linq;

namespace Poisonous_Cookies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            var canEat = 0;

            // Cを何枚食べられるか
            var b = input.ElementAt(1);
            var gedoku = input.ElementAt(0) + b;
            var doku = input.ElementAt(2);
            if (gedoku >= doku)
            {
                canEat += doku;
            }
            else
            {
                // 死ぬ前提で一枚余分に毒を食べられる
                canEat += gedoku + 1;
            }

            canEat += b;
            Console.WriteLine(canEat);
            Console.ReadLine();
        }
    }
}
