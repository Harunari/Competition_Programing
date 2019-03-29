using System;
using System.Linq;

namespace _20190224AtCoderB
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                if (input.ElementAt(1)[0] == 'J')
                {
                    sum += int.Parse(input.ElementAt(0));
                }
                else
                {
                    sum += 380000 * double.Parse(input.ElementAt(0));
                }
            }
            Console.WriteLine(sum);

        }
    }
}
