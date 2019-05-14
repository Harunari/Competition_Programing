using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Sugar_Water
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                var abcdef = GetArray<int>();
                var a = abcdef[0];
                var b = abcdef[1];
                var c = abcdef[2];
                var d = abcdef[3];
                var e = abcdef[4];
                var limitedPercent = e * 100.0 / (e + 100);
                var f = abcdef[5];

                var xs = new List<int>();
                var ys = new List<int>();
                for (int i = 0; i < f; i++)
                {
                    for (int j = 0; j < f; j++)
                    {
                        int x = a * 100 * i + b * 100 * j;
                        int y = c * i + d * j;
                        if (f >= x && x != 0) { xs.Add(x); }
                        if (f > y) { ys.Add(y); }
                    }
                }

                var pairs = new List<Tuple<int, int>>();
                foreach (var x in xs)
                {
                    foreach (var y in ys)
                    {
                        double percent = y * 100.0 / (x + y);
                        if (limitedPercent >= percent && f >= x + y) { pairs.Add(Tuple.Create(y, x)); }
                    }
                }
                var densitiest = pairs.Aggregate((acc, p) => (p.Item1 * 100.0 / (p.Item1 + p.Item2)) > acc.Item1 * 100.0 / (acc.Item1 + acc.Item2) ? p : acc);
                CWrite($"{densitiest.Item2 + densitiest.Item1} {densitiest.Item1}");
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
