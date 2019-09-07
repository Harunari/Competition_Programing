using System;
using System.Collections.Generic;
using System.Linq;

namespace Linear_Approximation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var inputs = Console.ReadLine().Split().Select(int.Parse);
            int i = 1;
            var result = inputs.Select(a => Math.Abs(a - i++))
                .OrderBy(a => a).ToArray();
            int medianIndex = (int)Math.Round((double)(n / 2));
            int median = result[medianIndex];
            int sum = result.Select(a => Math.Abs(a - median)).Sum();
            Console.WriteLine(sum);            
        }
    }
}
