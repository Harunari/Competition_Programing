using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SameInteger_BFS
{
    class Program
    {
        public static int[] ad = new int[] { 2, 0, 0, 1, 1, 0 };
        public static int[] bd = new int[] { 0, 2, 0, 1, 0, 1 };
        public static int[] cd = new int[] { 0, 0, 2, 0, 1, 1 };
        static void Main(string[] args)
        {
            CWrite(BFS(GetArray<int>()));
        }

        private static int BFS(int[] abc)
        {
            int count = 0;
            if (abc[0] == abc[1] & abc[1] == abc[2]) { return 0; }
            abc = abc.OrderBy(n => n).ToArray();
            while (abc[1] + 3 <= abc[2])
            {
                count++;
                abc[1] = abc[1] + 2;
            }
            while (abc[0] + 3 <= abc[1])
            {
                count++;
                abc[0] = abc[0] + 2;
            }

            var q = new Queue<int[]>();
            q.Enqueue(new int[] { abc[0], abc[1], abc[2], count });
            while (q.Any())
            {
                var tmp = q.Dequeue();
                for (int i = 0; i < ad.Length; i++)
                {
                    var a = tmp[0] + ad[i];
                    var b = tmp[1] + bd[i];
                    var c = tmp[2] + cd[i];

                    if (a == tmp.Max() + 2 || b == tmp.Max() + 2 || c == tmp.Max() + 2)
                    {
                        continue;
                    }
                    count = tmp[3] + 1;
                    if (a == b & b == c) { return count; }
                    q.Enqueue(new int[] { a, b, c, count });
                }
            }
            return int.MaxValue;
        }

        static void CWrite<T>(T str) => Console.WriteLine(str);
        static string GetString() => Console.ReadLine();
        static T[] GetArray<T>()
        {
            var t = typeof(T);
            var str = Console.ReadLine();
            if (t == typeof(string))
            {
                return (T[])(object)str.Split();
            }
            if (t == typeof(int))
            {
                return (T[])(object)str.ToNumArray<T>();
            }
            if (t == typeof(long))
            {
                return (T[])(object)str.ToNumArray<T>();
            }
            if (t == typeof(double))
            {
                return (T[])(object)str.ToNumArray<T>();
            }
            throw new NotSupportedException($"{t} is not supported.");
        }
    }



    class SetConsole : IDisposable
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

    static class ExtentionsLibrary
    {
        public static T[] CopyArray<T>(this T[] array)
        {
            var newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);
            return newArray;
        }
        public static T[,] CopyTwoDimensionalArray<T>(this T[,] dArray)
        {
            var firstDimentionLength = dArray.GetLength(0);
            var secondDimentionLength = dArray.GetLength(1);
            var newDArray = new T[firstDimentionLength, secondDimentionLength];
            Array.Copy(dArray, newDArray, firstDimentionLength * secondDimentionLength);
            return newDArray;
        }
        public static T[] ToNumArray<T>(this string str)
        {
            var t = typeof(T);
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
            throw new NotSupportedException();
        }
        public static int ToInt(this string str) => int.Parse(str);
        public static int ToInt(this char chr) => int.Parse(chr.ToString());
        public static long ToLong(this string str) => long.Parse(str);
    }
}
