using System;
using System.Linq;

namespace Maximum_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var input in inputs)
            {
                min = (input < min) ? input : min;
                max = (input > max) ? input : max;
            }

            Console.WriteLine(max - min);
        }
    }
}
