using System;
using System.Diagnostics;
using System.IO;

namespace Sample
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

    }

    class SetConsole : IDisposable
    {
        public SetConsole()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
        }
        public void Dispose() { Console.Out.Flush(); }
    }


    // 提出の際はこちらをコピペしない
    class Local
    {
        static void Main()
        {
            using (var sc = new SetConsole())
            {
                var sw = new Stopwatch();
                sw.Start();
                Program.Main(null);
                Console.WriteLine($"{sw.ElapsedMilliseconds}ms");
            }
            Console.ReadLine();
        }
    }
}
