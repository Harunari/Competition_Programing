using System;
using System.Collections.Generic;
using System.Linq;

namespace GhostLeg2
{
    
    class HorizontalLine
    {
        public int VerticalBarNumber { get; set; }
        public int ToRightBarLength { get; set; }
        public int ToLeftBarLength { get; set; }
    }
    class Program
    {
        static int N;
        static int Length;
        static int MyPoint;

        static void Main(string[] args)
        {
            var lmn = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int l = lmn[0];
            int n = lmn[1];
            int m = lmn[2];
            var horizontalLines = new List<HorizontalLine>();
            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                horizontalLines.Add(new HorizontalLine
                {
                    VerticalBarNumber = input[0],
                    ToLeftBarLength = input[1],
                    ToRightBarLength = input[2]
                    
                });
            }

            Length = l;
            // 各縦線から探索
            for (int i = 1; i <= n; i++)
            {
                N = i;
                MyPoint = 0;
                while (MyPoint != Length)
                {
                    SeachGoal(horizontalLines);
                }
                
                if (N == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.ReadLine();
        }

        static void SeachGoal(List<HorizontalLine> horizontalLines)
        {
            // 今いる位置より下に横棒が全くなければゴールはn
            if (!horizontalLines
                .Where(a => a.ToLeftBarLength >= MyPoint)
                .Select(a => a.VerticalBarNumber).Contains(N))
            {
                
                if (!horizontalLines
                .Where(a => a.ToRightBarLength >= MyPoint)
                .Select(a => a.VerticalBarNumber).Contains(N - 1))
                {
                    MyPoint = Length;
                    return;
                }
            }


            var ToRightLines = horizontalLines.Where(a => a.VerticalBarNumber == N)
                .Where(a => a.ToLeftBarLength > MyPoint)
                .OrderBy(a => a.ToLeftBarLength);
            var ToLeftLines = horizontalLines.Where(a => a.VerticalBarNumber == N - 1)
                .Where(a => a.ToRightBarLength > MyPoint)
                .OrderBy(a => a.ToRightBarLength);

            if (ToRightLines.Count() == 0)
            {
                if (ToLeftLines.Count() == 0)
                {
                    MyPoint = Length;
                    return;
                }
                MyPoint = ToLeftLines.ElementAt(0).ToLeftBarLength;
                N--;
            }
            else if (ToLeftLines.Count() == 0)
            {
                if (ToRightLines.Count() == 0)
                {
                    MyPoint = Length;
                    return;
                }
                MyPoint = ToRightLines.ElementAt(0).ToRightBarLength;
                N++;
            }
            else if (ToRightLines.ElementAt(0).ToLeftBarLength < ToLeftLines.ElementAt(0).ToRightBarLength)
            {
                MyPoint = ToRightLines.ElementAt(0).ToRightBarLength;
                N++;
            }
            else
            {
                MyPoint = ToLeftLines.ElementAt(0).ToLeftBarLength;
                N--;
            }
        }
    }
}
