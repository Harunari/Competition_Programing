using System;
using System.Text;

namespace checkDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                int even = 0, odd = 0;
                var str = Console.ReadLine();
                for (int j = 0; j < 15; j++)
                {
                    if (j % 2 == 0)
                    {
                        int temp = int.Parse(str[j].ToString());
                        if (temp > 4)
                        {
                            switch (temp)
                            {

                                case 5:
                                    even += 1;
                                    break;
                                case 6:
                                    even += 3;
                                    break;
                                case 7:
                                    even += 5;
                                    break;
                                case 8:
                                    even += 7;
                                    break;
                                case 9:
                                    even += 9;
                                    break;
                            }

                        }
                        else
                        {
                            even += temp * 2;
                        }
                    }
                    else
                    {
                        odd += int.Parse(str[j].ToString());

                    }
                }
                int sum = even + odd;
                for (int k = 0; k <= 9; k++)
                {
                    if ((sum + k) % 10 == 0)
                    {
                        Console.WriteLine(k);
                        break;
                    }
                }
            }
            
            
        }
    }
}
