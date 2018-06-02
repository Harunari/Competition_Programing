using System;

namespace ALDS1_6_A
{
    class Program
    {
        

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] A = new int[n + 1];
            int[] B = new int[n];
            int Max = int.MinValue;
            for (int i = 1; i < n + 1; i++)
            {
                A[i] = array[i - 1];
                if (Max < A[i]) Max = A[i];

            }
            CountingSort(A, B, Max, n);
        }


        static void CountingSort(int[] A, int[] B, int k, int n)
        {
            int[] C = new int[k + 1];
            for (int i = 0; i < k + 1; i++)
            {
                C[i] = 0;
            }

            // C[i]にiの出現数を記録する A配列は便宜上1オリジン　
            for (int j = 1; j <= n; j++)
            {
                C[A[j]]++;
            }

            // C[i]にi以下の数(の総和)を記録する 
            for (int i = 1; i <= k; i++)
            {
                C[i] = C[i] + C[i - 1];
            }

            for (int j = n; j >= 1; j--)
            {
                B[C[A[j]] - 1] = A[j];
                C[A[j]]--;
            }
            Console.WriteLine(string.Join(" ", Array.ConvertAll(B, b => b.ToString())));

        }
    }
}
