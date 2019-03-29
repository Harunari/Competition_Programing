using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B027
{
    public class Program
    {
        public enum MyEnum
        {
            matumu, kamei, kosei
        }
        static void Main(string[] args)
        {
            var test = EnumsReturn();
            Console.WriteLine(test.Contains(MyEnum.kosei));
            Console.ReadLine();
            
        }

        public static IEnumerable<MyEnum> EnumsReturn()
        {
            yield return MyEnum.matumu;
            yield return MyEnum.kamei;
            yield return MyEnum.kosei;
        }
    }
}
