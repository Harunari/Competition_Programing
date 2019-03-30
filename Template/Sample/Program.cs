﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Get_AC
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                Console.WriteLine("Hello World");
            }
        }

        static string[] GetArrayCharInput() => Console.ReadLine().Split();
        static int[] GetArrayIntInput() => Console.ReadLine().StringToIntArray();
        static int GetIntInput() => Console.ReadLine().ToInt();
        static void CWrite(string str) => Console.WriteLine(str);

    }

    class SetConsole : IDisposable
    {
        public SetConsole()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
        }
        public void Dispose()
        {
            Console.Out.Flush();
        }
    }

    static class ExtentionsLibrary
    {
        public static int[] StringToIntArray(this string str) =>
            str.Split().Select(int.Parse).ToArray();
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
                    var s = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
                    Console.SetOut(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Process was supended");
                    break;
                }
                if (records.Any())
                {
                    Console.WriteLine($"AveTime is {records.Average()}ms");
                }
            }
        }
    }
}
