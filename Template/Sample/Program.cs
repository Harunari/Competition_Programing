using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Sample
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                CWrite("Hello World");
                GetArrayCharInput();
            }
        }

        static string[] GetArrayCharInput() => Console.ReadLine().Split();
        static int[] GetArrayIntInput() => Console.ReadLine().StringToIntArray();
        static int GetIntInput() => Console.ReadLine().ToInt();
        static void CWrite(string str) => Console.WriteLine(str);

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
