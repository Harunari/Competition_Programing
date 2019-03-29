using System;
using System.Text;

namespace LeetString
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'A':
                        sb.Append('4');
                        break;
                    case 'E':
                        sb.Append('3');
                        break;
                    case 'G':
                        sb.Append('6');
                        break;
                    case 'I':
                        sb.Append('1');
                        break;
                    case 'O':
                        sb.Append('0');
                        break;
                    case 'S':
                        sb.Append('5');
                        break;
                    case 'Z':
                        sb.Append('2');
                        break;
                    default:
                        sb.Append(str[i]);
                        break;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
