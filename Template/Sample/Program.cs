using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using static System.Math;

namespace Sample
{
    public sealed class Program : BaseProgram
    {
        public static void Main(string[] args)
        {
            using (var sc = new SetConsole()) { Solve(); }
        }
        private static void Solve()
        {
            
        }
    }

    public class BaseProgram
    {
        protected static void CWrite<T>(T str) => Console.WriteLine(str);
        protected static string GetString() => Console.ReadLine();
        protected static T[] GetArray<T>()
        {
            var str = Console.ReadLine();
            if (str == null) { throw new NullReferenceException("標準入力がnullです Solveメソッド内の解答コードが間違っています"); }
            return str.ToArray<T>();
        }
        protected class SetConsole : IDisposable
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
        public static T[] ToArray<T>(this string str)
        {
            var t = typeof(T);
            if (t == typeof(string))
            {
                return (T[])(object)str.Split();
            }
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
            if (t == typeof(BigInteger))
            {
                return (T[])(object)str.Split().Select(BigInteger.Parse).ToArray();
            }
            throw new NotSupportedException();
        }
        public static int ToInt(this string str) => int.Parse(str);
        public static int ToInt(this char chr) => int.Parse(chr.ToString());
        public static long ToLong(this string str) => long.Parse(str);
        public static double ToDouble(this string str) => double.Parse(str);
        public static BigInteger ToBigInteger(this string str) => BigInteger.Parse(str);
        public static DateTime ToDateTime(this string str) => DateTime.Parse(str);
    }
}
