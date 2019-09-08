using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using static Sample.Settings;
using static System.Math;

namespace Sample
{
    public sealed class Program : BaseProgram
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole()) { Solve(); }
        }
        public static void Solve()
        {
            var nm = GetArray<int>();
            var jobs = new List<List<int>>(nm[1]);
            for (int i = 0; i < nm[0]; i++)
            {
                var ab = GetArray<int>();
                if (ab[0] > nm[1]) { continue; }
                jobs[nm[1] - ab[0]].Add(ab[1]);
            }

            for (int i = nm[1] - 1; i >= 0; i--)
            {
                foreach (var j in jobs[i])
                {

                }
            }
        }
    }

    public class BaseProgram
    {
        protected static void CWrite<T>(T str) => Console.WriteLine(str);
        protected static string GetString() => Console.ReadLine();
        protected static T GetNumber<T>()
        {
            var t = typeof(T);
            if (t == typeof(int))
            {
                return (T)(object)GetString().ToInt();
            }
            else if (t == typeof(long))
            {
                return (T)(object)GetString().ToLong();
            }
            else if (t == typeof(double))
            {
                return (T)(object)GetString().ToDouble();
            }
            throw new NotSupportedException();
        }
        protected static T[] GetArray<T>()
        {
            var str = Console.ReadLine();
            if (str == null) { throw new NullReferenceException("標準入力がnullです Solveメソッド内の解答コードが間違っています"); }
            return str.ToArray<T>();
        }
        protected static void Swap<T>(ref T item1, ref T item2)
        {
            var tmp = item1;
            item1 = item2;
            item2 = tmp;
        }
        protected class SetConsole : IDisposable
        {
            readonly StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            public SetConsole()
            {
                sw.AutoFlush = false;
                Console.SetOut(sw);
            }
            public void Dispose()
            {
                Console.Out.Flush();
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
        }
    }
    static class ExtentionsLibrary
    {
        public static List<T> CopyList<T>(this List<T> list) => CopyArray(list.ToArray()).ToList();
        public static T[] CopyArray<T>(this T[] array)
        {
            var newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);
            return newArray;
        }
        public static T[,] CopyArray<T>(this T[,] array)
        {
            var firstDimentionLength = array.GetLength(0);
            var secondDimentionLength = array.GetLength(1);
            var newDArray = new T[firstDimentionLength, secondDimentionLength];
            Array.Copy(array, newDArray, firstDimentionLength * secondDimentionLength);
            return newDArray;
        }
        public static T[] ToArray<T>(this string str)
        {
            var t = typeof(T);
            if (t == typeof(string))
            {
                return (T[])(object)str.Split();
            }
            if (t == typeof(int))
            {
                return (T[])(object)str.Split().Select(int.Parse).ToArray();
            }
            if (t == typeof(long))
            {
                return (T[])(object)str.Split().Select(long.Parse).ToArray();
            }
            if (t == typeof(double))
            {
                return (T[])(object)str.Split().Select(double.Parse).ToArray();
            }
            if (t == typeof(BigInteger))
            {
                return (T[])(object)str.Split().Select(BigInteger.Parse).ToArray();
            }
            throw new NotSupportedException();
        }
        public static int ToInt(this string str) => int.Parse(str);
        public static int ToInt(this char chr) => int.Parse(chr.ToString());
        public static long ToLong(this string str) => long.Parse(str);
        public static double ToDouble(this string str) => double.Parse(str);
        public static BigInteger ToBigInteger(this string str) => BigInteger.Parse(str);
        public static DateTime ToDateTime(this string str) => DateTime.Parse(str);
        public static string StringJoin(this object[] array, string separator) => string.Join(separator, array);
    }
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly Priority priority;
        private List<T> heap = new List<T> { default };

        private PriorityQueue() { }
        public PriorityQueue(Priority p)
        {
            priority = p;
        }
        public int Count() => heap.Count - 1;
        public T Peek()
        {
            if (heap.Count - 1 <= 0) { throw new Exception("要素が空です"); }
            return heap[1];
        }
        public T Dequeue()
        {
            if (heap.Count - 1 <= 0) { throw new Exception("要素が空です"); }

            var max = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MaxHeapify(1);
            return max;
        }
        public void Enqueue(T key)
        {
            HeapIncreaseKey(key);
        }
        public void Clear()
        {
            heap = new List<T>() { default };
        }
        private void MaxHeapify(int i)
        {
            int largest;
            int l = Left(i);
            int r = Right(i);

            if (l <= heap.Count - 1 && Compare(heap[i], heap[l]) < 0)
            {
                largest = l;
            }
            else
            {
                largest = i;
            }
            if (r <= heap.Count - 1 && Compare(heap[r] ,heap[largest]) > 0)
            {
                largest = r;
            }

            if (largest != i)
            {
                var temp = heap[i];
                heap[i] = heap[largest];
                heap[largest] = temp;
                MaxHeapify(largest);
            }
        }
        private void HeapIncreaseKey(T key)
        {
            heap.Add(key);
            int lastIndex = heap.Count - 1;
            while (lastIndex > 1 && Compare(heap[Parent(lastIndex)], heap[lastIndex]) < 0)
            {
                var temp = heap[lastIndex];
                heap[lastIndex] = heap[Parent(lastIndex)];
                heap[Parent(lastIndex)] = temp;
                lastIndex = Parent(lastIndex);
            }
        }
        private static int Parent(int i) => i / 2;
        private static int Left(int i) => i * 2;
        private static int Right(int i) => i * 2 + 1;
        private int Compare(T x, T y)
        {
            return priority == Priority.Larger ? x.CompareTo(y) : y.CompareTo(x);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 1; i < heap.Count; i++)
            {
                yield return heap[i];
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 1; i < heap.Count; i++)
            {
                yield return heap[i];
            }
        }
    }
    public class Settings
    {
        public enum Priority : byte
        {
            Smaller = 0,
            Larger = 1
        }
    }
}
