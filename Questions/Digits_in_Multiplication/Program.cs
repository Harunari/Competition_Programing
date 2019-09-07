using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Math;

namespace Digits_in_Multiplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole()) { Solve(); }
        }

        public static void Solve()
        {
            var n = GetString().ToLong();
            var divsors = GetDivisors(n).ToArray();
            var list = new List<long>();
            for (int i = 0; i < divsors.Length; i += 2)
            {
                list.Add(Max(divsors[i], divsors[i + 1]));
            }
            CWrite(list.Min().ToString().Length);
        }

        static IEnumerable<long> GetDivisors(long num)
        {
            yield return 1;
            yield return num;
            for (long i = 2; i <= Pow(num, 0.5); i++)
            {
                if (num % i == 0)
                {
                    yield return i;
                    yield return num / i;
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
        public static DateTime ToDateTime(this string str) => DateTime.Parse(str);
    }
}
