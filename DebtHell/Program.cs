using System;

namespace DebtHell
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            double SumMoney = 100;
            for (int i = 0; i < input; i++)
            {
                SumMoney *= 1.05;
                double e = SumMoney % 1;
                if (e == 0)
                {

                }
                else
                {
                    SumMoney = SumMoney - e + 1;
                }
            }
            
            Console.WriteLine(SumMoney * 1000);
            Console.Read();
        }
    }
}
