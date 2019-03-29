using System;
using System.Linq;
using System.Text;

namespace CircumscribedCircleOfATriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                decimal[] input = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
                decimal[] b = {input[2] - input[0], input[3] - input[1],
            (input[2] * input[2] - input[0] * input[0] - input[1] * input[1] + input[3] * input[3])/ 2,
            input[4] - input[0], input[5] - input[1],
            (input[4] * input[4] - input[0] * input[0] - input[1] * input[1] + input[5] * input[5])/ 2 };
                decimal d, e;
                if (b[0] == 0)
                {
                    d = b[2] / b[1];
                    e = (b[5] - d * b[4]) / b[3];
                }
                else
                {
                    d = (b[5] - b[2] * b[3] / b[0]) / (b[4] - b[3] * b[1] / b[0]);
                    e = (b[2] - d * b[1]) / b[0];
                }

                double distance = Math.Pow((double)((e - input[0]) * (e - input[0]) + (d - input[1]) * (d - input[1])), 0.5);
                distance = Math.Round(distance * 1000) / 1000;

                sb.AppendLine(String.Format("{0:F3} {1:F3} {2:F3}", e, d, distance));
            }
            Console.Write(sb);
        }
    }
}
