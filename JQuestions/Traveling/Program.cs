﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Math;

namespace Traveling
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                int n = GetString().ToInt();
                var ts = new List<int[]>
                {
                    new int[] { 0, 0, 0 }
                };
                for (int i = 1; i <= n; i++)
                {
                    ts.Add(GetArray<int>());
                }
                for (int i = 1; i <= n; i++)
                {
                    if (Abs(ts[i][0] - ts[i - 1][0]) < Abs(ts[i][1] - ts[i - 1][1]) + Abs(ts[i][2] - ts[i - 1][2]))
                    {
                        CWrite("No");
                        return;
                    }
                    if (ts[i][0] % 2 != (ts[i][1] + ts[i][2]) % 2)
                    {
                        CWrite("No");
                        return;
                    }
                }
                CWrite("Yes");
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
