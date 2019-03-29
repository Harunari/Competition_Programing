using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_Sort
{
    class Program
    {
        static int COUNT;
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            int n = int.Parse(Console.ReadLine());
            int[] input = new int[n];
            for (int i = 0; i < n; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }
            var g = ShellSort(input, n).ToArray();
            Console.WriteLine(g.Length);
            Console.WriteLine(String.Join(" ", g));
            Console.WriteLine(COUNT);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(input[i]);
            }
            Console.Out.Flush();
            Console.ReadLine();
        }

        static private void InsertionSort(int[] input, int n, int g)
        {
            for (int i = g; i < n; i++)
            {
                int v = input[i];
                int j = i - g;
                while (j >= 0 && input[j] > v)
                {
                    input[j + g] = input[j];
                    j -= g;
                    COUNT++;
                }
                input[j + g] = v;
            }
        }

        static private List<int> ShellSort(int[] input, int n)
        {
            COUNT = 0;
            List<int> g = new List<int>();

            for (int h = 1; ;)
            {
                if (h > n) { break; }
                g.Insert(0, h);
                h = 3 * h + 1;
            }
            for (int i = 0; i < g.Count; i++)
            {
                InsertionSort(input, n, g[i]);
            }
            return g;
        }
    }
}
