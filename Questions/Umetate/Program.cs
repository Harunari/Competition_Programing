using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Math;

namespace Umetate
{
    class Program
    {
        public static int[] xd = new int[] { 1, 0, 0, -1 };
        public static int[] yd = new int[] { 0, 1, -1, 0 };

        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                // [x, y]
                var map = new bool[12, 12];
                for (int y = 1; y <= 10; y++)
                {
                    var row = GetString();
                    for (int x = 1; x <= 10; x++)
                    {
                        map[x, y] = row[x - 1] == 'o' ? true : false;
                    }
                }

                for (int y = 1; y <= 10; y++)
                {
                    for (int x = 1; x <= 10; x++)
                    {
                        if (map[x, y]) { continue; }
                        var newMap = new bool[12, 12];
                        Array.Copy(map, newMap, 12 * 12);
                        DFS(newMap, x, y);
                        var flag = false;
                        for (int i = 1; i <= 10; i++)
                        {
                            for (int j = 1; j <= 10; j++)
                            {
                                flag = flag ? true : newMap[i, j];
                            }
                        }
                        if (!flag) { CWrite("YES"); return; }
                    }
                }
                CWrite("NO");
            }
        }

        private static void DFS(bool[,] map, int x, int y)
        {
            // x, y
            var stk = new Stack<int[]>();
            stk.Push(new int[] { x, y });
            while (stk.Any())
            {
                var xy = stk.Pop();
                map[xy[0], xy[1]] = false;
                for (int i = 0; i < xd.Length; i++)
                {
                    if (map[xy[0] + xd[i], xy[1] + yd[i]])
                    {
                        stk.Push(new int[] { xy[0] + xd[i], xy[1] + yd[i] });
                    }
                }
            }
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

    // 提出の際はこちらをコピペしない
    class Local
    {
        static void Main()
        {
            var records = new List<long>();
            while (true)
            {
                try
                {
                    using (var sc = new SetConsole())
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        Program.Main(null);
                        sw.Stop();
                        records.Add(sw.ElapsedMilliseconds);
                        sw.Reset();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("\n====================");
                    Console.WriteLine("Process was supended");
                    Console.WriteLine("====================\n");
                }
                if (records.Any())
                {
                    Console.WriteLine("\n====================");
                    Console.WriteLine($"Time is {records.Last()}ms");
                    Console.WriteLine($"AveTime is {records.Average()}ms");
                    Console.WriteLine("====================\n");
                }
            }
        }
    }
}
