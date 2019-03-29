using System;
using System.Linq;

namespace _2019024AtCoderA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EvalEra(Console.ReadLine()));
        }

        public static string EvalEra(string input)
        {
            var yyyymmdd = input.Split('/').Select(int.Parse);
            var year = yyyymmdd.ElementAt(0);
            if (2019 > year)
            {
                return "Heisei";
            }
            var month = yyyymmdd.ElementAt(1);
            if (year == 2019 && 4 >= month)
            {
                return "Heisei";
            }
            return "TBD";
        }
    }
}
