using System;
using System.Collections.Generic;
using System.Linq;

namespace Allocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            int n = input.ElementAt(0);
            int k = input.ElementAt(1);

            var weights = new List<int>();
            for (int i = 0; i < n; i++)
            {
                weights.Add(int.Parse(Console.ReadLine()));
            }

            var answer = Solve(weights, n, k);
            Console.WriteLine(answer);
            Console.ReadLine();

        }

        public static int Solve(List<int> weights, int baggageAmount, int truckAmount)
        {
            int left = 0;
            int right = 100000 * 10000;
            int mid;
            while (right - left > 1)
            {
                mid = (right + left) / 2;
                int v = MeasureTruckCanCarry(mid, weights, baggageAmount, truckAmount);
                if (v >= baggageAmount)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            return right;
        }


        public static int MeasureTruckCanCarry(int loadCapacity, List<int> weights, int baggageAmount, int truckAmount)
        {
            int baggageIndex = 0;
            for (int i = 0; i < truckAmount; i++)
            {
                int loadSize = 0;
                while (loadSize + weights[baggageIndex] <= loadCapacity)
                {
                    loadSize += weights[baggageIndex];
                    baggageIndex++;
                    if (baggageAmount == baggageIndex)
                    {
                        return baggageAmount;
                    }
                }
            }
            return baggageIndex;
        }
    }
}
