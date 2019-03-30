using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NAMINAMI
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole())
            {
                int n = GetIntInput();
                var input = GetArrayIntInput();
                var edic = new Dictionary<int, int>();
                var odic = new Dictionary<int, int>();
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (edic.ContainsKey(input[i]))
                        {
                            edic[input[i]]++;
                        }
                        else
                        {
                            edic.Add(input[i], 1);
                        }
                    }
                    else
                    {
                        if (odic.ContainsKey(input[i]))
                        {
                            odic[input[i]]++;
                        }
                        else
                        {
                            odic.Add(input[i], 1);
                        }
                    }
                }
                var commonInE = edic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);
                var commonInO = odic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);

                if (commonInE.Key == commonInO.Key  && (edic.Count == 1 || odic.Count == 1))
                {
                    if (1 < edic.Count)
                    {
                        edic.Remove(commonInE.Key);
                        var secondCommonInE = edic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);
                        edic.Remove(secondCommonInE.Key);
                        edic.Add(commonInE.Key, commonInE.Value);
                        CWrite(edic.Sum(d => d.Value));
                    }
                    else if (1 < odic.Count)
                    {
                        odic.Remove(commonInE.Key);
                        var secondCommonInO = odic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);
                        odic.Remove(secondCommonInO.Key);
                        odic.Add(commonInO.Key, commonInO.Value);
                        CWrite(odic.Sum(d => d.Value));
                    }
                    else
                    {
                        CWrite(n / 2);
                    }
                }
                else if (commonInE.Key == commonInO.Key)
                {
                    var copiedEDic = new Dictionary<int, int>(edic);
                    var copiedODic = new Dictionary<int, int>(odic);
                    copiedEDic.Remove(commonInE.Key);
                    copiedODic.Remove(commonInO.Key);
                    var secondCommonInO = copiedODic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);
                    copiedODic.Remove(secondCommonInO.Key);
                    copiedODic.Add(commonInO.Key, commonInO.Value);
                    var sum1 = copiedEDic.Sum(d => d.Value) + copiedODic.Sum(d => d.Value);

                    copiedEDic = new Dictionary<int, int>(edic);
                    copiedODic = new Dictionary<int, int>(odic);
                    copiedEDic.Remove(commonInE.Key);
                    copiedODic.Remove(commonInO.Key);
                    var secondCommonInE = copiedEDic.Aggregate((acc, e) => acc.Value < e.Value ? e : acc);
                    copiedEDic.Remove(secondCommonInE.Key);
                    copiedEDic.Add(commonInE.Key, commonInE.Value);
                    var sum2 = copiedEDic.Sum(d => d.Value) + copiedODic.Sum(d => d.Value);
                    CWrite(sum1 < sum2 ? sum1 : sum2);
                }
                else
                {
                    edic.Remove(commonInE.Key);
                    odic.Remove(commonInO.Key);
                    CWrite(edic.Sum(d => d.Value) + odic.Sum(d => d.Value));
                }
            }
        }

        static string[] GetArrayCharInput() => Console.ReadLine().Split();
        static int[] GetArrayIntInput() => Console.ReadLine().StringToIntArray();
        static int GetIntInput() => Console.ReadLine().ToInt();
        static void CWrite<T>(T str) => Console.WriteLine(str);
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
                }
                catch (Exception ex)
                {
                    var s = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
                    Console.SetOut(s);
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("Process was supended");
                    Console.ReadLine();
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
