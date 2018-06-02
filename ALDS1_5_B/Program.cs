using System;

namespace ALDS1_5_B
{
    class Program
    {
        static long cnt = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            // rightの初期値は配列の要素数
            MergeSort(S, 0, n);

            Console.WriteLine(cnt);
        }

        static void Merge(int[] A, int left, int mid, int right)
        {
            int n1 = mid - left;
            int n2 = right - mid;
            // 左右それぞれ一つ多く要素を作る
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            // もとの配列を左右に分ける
            for (int i = 0; i < n1; i++)
            {
                L[i] = A[left + i];
            }
            for (int i = 0; i < n2; i++)
            {
                R[i] = A[mid + i];
            }

            // 無限みたいな
            L[n1] = int.MaxValue;
            R[n2] = int.MaxValue;

            int m = 0, j = 0;
            for (int k = left; k < right; k++)
            {
                if (L[m] <= R[j])
                {
                    A[k] = L[m];
                    m++;

                    cnt += j;
                }
                else
                {
                    A[k] = R[j];
                    j++;
                }
            }
        }


        static void MergeSort(int[] A, int left, int right)
        {
            if (left + 1 < right)
            {
                int mid = (left + right) / 2;
                MergeSort(A, left, mid);
                MergeSort(A, mid, right);
                Merge(A, left, mid, right);
            }
        }

    }
}
