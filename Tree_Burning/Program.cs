using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree_Burning
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(float.Parse);
            var length = input.ElementAt(0);
            var n = input.ElementAt(1);
            var trees = new List<float>();
            for (float i = 0; i < n; i++)
            {
                trees.Add(float.Parse(Console.ReadLine()));
            }
            float currentLocation = 0;
            float sum = 0;
            while (trees.Any())
            {
                float a;
                if (trees.First() < currentLocation)
                {
                    a = trees.First() + length - currentLocation;
                }
                else
                {
                    a = trees.First() - currentLocation;
                }
                float b;
                if (trees.Last() > currentLocation)
                {
                    b = currentLocation + (length - trees.Last());
                }
                else
                {
                    b = currentLocation - trees.Last();
                }

                if (a > b)
                {
                    sum += a;
                    currentLocation = trees.First();
                    trees.RemoveAt(0);
                }
                else
                {
                    sum += b;
                    currentLocation = trees.Last();
                    trees.RemoveAt(trees.Count - 1);
                }
            }
            
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
