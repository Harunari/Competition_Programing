using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stable_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            var input2 = new string[n];
            Array.Copy(input, input2, n);
            BubbleSort(input, n);
            var str = String.Join(" ", input);
            Console.WriteLine(str);
            Console.WriteLine("Stable");

            SelectionSort(input2, n);
            str = String.Join(" ", input2);
            Console.WriteLine(str);
            if (IsStable(input, input2, n))
            {
                Console.WriteLine("Stable");
            }
            else
            {
                Console.WriteLine("Not Stable");
            }

            Console.Out.Flush();
            Console.ReadLine();
        }
        private static bool IsStable(string[] input, string[] input2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (!(input[i] == input2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static void BubbleSort(string[] input, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    bool flag = int.Parse(input[j - 1][1].ToString()) > int.Parse(input[j][1].ToString());
                    if (flag)
                    {
                        var temp = input[j];
                        input[j] = input[j - 1];
                        input[j - 1] = temp;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private static void SelectionSort(string[] input, int n)
        {
            int minj;
            for (int i = 0; i < n; i++)
            {
                minj = i;
                for (int j = i + 1; j < n; j++)
                {
                    minj = (int.Parse(input[j][1].ToString()) < int.Parse(input[minj][1].ToString()))? j : minj;
                }
                var temp = input[i];
                input[i] = input[minj];
                input[minj] = temp;
            }
        }
    }
}
