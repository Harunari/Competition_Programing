using System;
using System.Text;
using System.Threading.Tasks;

namespace C019
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine()), sum = 0;
                for (int j = 1; j < input; j++)
                {
                    if (input % j == 0)
                    {
                        sum += j;
                    }
                    
                }
                if (sum == input)
                {
                    sb.AppendLine("perfect");
                }
                else if (sum == input -1)
                {
                    sb.AppendLine("nearly");

                }
                else
                {
                    sb.AppendLine("neither");
                }
            }
            Console.Write(sb);
            Console.ReadLine();
        }
    }
}
