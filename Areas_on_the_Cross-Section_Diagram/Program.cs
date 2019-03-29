using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Areas_on_the_Cross_Section_Diagram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var s1 = new Stack();
            var s2 = new Stack();

            var inputStr = Console.ReadLine();
            for (int j = 0; j < inputStr.Length; j++)
            {
                if ('\\' == inputStr[j])
                {
                    s1.Push(j);
                }
                else if ('/' == inputStr[j] && s1.Count > 0)
                {
                    var backSlashCoodinate = (int)s1.Pop();
                    s2.PushCalcedInfo(backSlashCoodinate, j);
                }
            }
            
            var result = s2.Cast<ValueTuple<int,int>>().Select(s => s.Item1).ToList();
            var sb = new StringBuilder().Append($"{result.Count} ");
            result.ForEach(r => sb.Append($"{r} "));
            Console.WriteLine(result.Sum());
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
        
        
    }

    public static class MyExtention
    {
        public static void PushCalcedInfo(this Stack s2, int backSlashCordinate, int currentIndex)
        {
            int areaSum = currentIndex - backSlashCordinate;
            var tempStack = (Stack)s2.Clone();
            while (tempStack.Count > 0)
            {
                var AreaAndcoordinate = (ValueTuple<int, int>)tempStack.Pop();
                if (backSlashCordinate < AreaAndcoordinate.Item2)
                {
                    areaSum += AreaAndcoordinate.Item1;
                    s2.Pop();
                }
                else
                {
                    break;
                }
            }

            s2.Push((areaSum, backSlashCordinate));            
        }
    }
}
