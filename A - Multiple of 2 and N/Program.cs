using System;

namespace A___Multiple_of_2_and_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int gcd = (n > 2) ? Myfunc(n, 2) : 1;
            Console.WriteLine(2 / gcd * n);
        }

        public static int Myfunc(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return Myfunc(b, a % b);
        }
    }
}
