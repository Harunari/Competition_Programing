using System;

namespace ALDS1_5_D
{
    class Program
    {
        static long count = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Comp(array, n - 1, n - 1, 0);
            Console.WriteLine(count);
            Console.ReadLine();
        }

        static void Comp(int[] array, int x, int y, int cnt)
        {
            if (array[x - 1] > array[x])
            {
                count++;
                int tmp = array[x];
                array[x] = array[x - 1];
                array[x - 1] = tmp;
                
            }
            if (x == 1) return;
            if (y == cnt || y == 1) return;
            Comp(array, x - 1, y, cnt + 1);
            Comp(array, x, y - 1, 0);
            
        }
    }
}
