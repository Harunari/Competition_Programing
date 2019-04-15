using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _20190413
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                var input = GetArrayIntInput();

                var str = Console.ReadLine().AsEnumerable<char>().Select(c => c.ToString().ToInt()).ToArray();
                var dic = new Dictionary<int, int>();
                var queue = new Queue<int>();
                for (int i = 0; i < input[0]; i++)
                {
                    if (0 == str[i])
                    {
                        queue.Enqueue(i);
                    }
                    else
                    {
                        if (queue.Any())
                        {
                            dic.Add(queue.Peek(), queue.Count);
                            queue.Clear();
                        }
                    }
                }
                if (queue.Any())
                {
                    dic.Add(queue.Peek(), queue.Count);
                    queue.Clear();
                }

                dic = new Dictionary<int, int>(dic.OrderByDescending(d => d.Value).ThenByDescending(d => d.Key));
                for (int i = 0; i < Math.Min(input[1], dic.Count); i++)
                {
                    var tmp = dic.ElementAt(i);
                    for (int j = tmp.Key; j < tmp.Key + tmp.Value; j++)
                    {
                        str[j]++;
                    }
                }
                CWrite(string.Join("", str).Split('0').Max(s => s.Length));
            }
        }

        static string[] GetArrayCharInput() => Console.ReadLine().Split();
        static int[] GetArrayIntInput() => Console.ReadLine().StringToIntArray();
        static int GetIntInput() => Console.ReadLine().ToInt();
        static void CWrite<T>(T str) => Console.WriteLine(str);
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
                    Console.WriteLine("Process was supended");
                }
                if (records.Any())
                {
                    Console.WriteLine($"AveTime is {records.Average()}ms");
                }
            }
        }
    }
}
