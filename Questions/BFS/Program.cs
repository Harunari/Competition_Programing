using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;

namespace BFS
{
    public class Program
    {
        public static int[] xd = new int[] { 1, 0, 0, -1 };
        public static int[] yd = new int[] { 0, 1, -1, 0 };

        public static void Main(string[] args)
        {
            using (var sc = new SetConsole()) { Solve(); }
        }

        public static void Solve()
        {
            var rc = GetArray<int>();
            var r = rc[0];
            var c = rc[1];
            var start = GetArray<int>().Select(n => n - 1).ToArray();
            var goal = GetArray<int>().Select(n => n - 1).ToArray();
            // y, x
            var map = new int[r, c];

            for (int i = 0; i < r; i++)
            {
                int count = 0;
                foreach (int cell in GetString().Select(s => s == '#' ? -1 : 0))
                {
                    map[i, count++] = cell;
                }
            }
            var test = map[goal[0], goal[1]];
            CWrite(BFS(map, start, goal));
        }

        private static int BFS(int[,] map, int[] start, int[] goal)
        {
            var que = new Queue<int[]>();
            que.Enqueue(start);
            while (que.Any())
            {
                var coodinate = que.Dequeue();
                for (int i = 0; i < xd.Length; i++)
                {
                    var movedCell = map[coodinate[0] + yd[i], coodinate[1] + xd[i]];
                    if (0 != movedCell) { continue; }
                    map[coodinate[0] + yd[i], coodinate[1] + xd[i]] = map[coodinate[0], coodinate[1]] + 1;
                    que.Enqueue(new int[] { coodinate[0] + yd[i], coodinate[1] + xd[i] });
                }
            }
            return map[goal[0], goal[1]];
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
