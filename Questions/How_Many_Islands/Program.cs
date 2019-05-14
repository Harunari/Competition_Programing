using System;
using System.Collections;
using System.Linq;


namespace How_Many_Islands
{
    class Program
    {
        public static int[] wds = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
        public static int[] hds = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };

        public static void Main(string[] args)
        {
            while (true)
            {
                var wh = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int w = wh[0];
                int h = wh[1];
                if (w == 0 & h == 0) { break; }

                var map = new bool[h + 2, w + 2];
                for (int i = 1; i <= h; i++)
                {
                    var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    for (int j = 1; j <= w; j++)
                    {
                        if (input[j - 1] == 1) { map[i, j] = true; }
                    }
                }

                var count = 0;
                for (int i = 1; i <= h; i++)
                {
                    for (int j = 1; j <= w; j++)
                    {
                        if (map[i, j])
                        {
                            map = DFS(map, i, j);
                            count++;
                        }
                    }
                }
                Console.WriteLine(count);
            }
        }

        static bool[,] DFS(bool[,] map, int y, int x)
        {
            var stk = new Stack();
            stk.Push(new int[] { y, x });
            while (stk.Count > 0)
            {
                var yx = (int[])stk.Pop();
                for (int i = 0; i < wds.Length; i++)
                {
                    int dy = hds[i];
                    int dx = wds[i];
                    if (map[yx[0] + dy, yx[1] + dx])
                    {
                        map[yx[0] + dy, yx[1] + dx] = false;
                        stk.Push(new int[] { yx[0] + dy, yx[1] + dx });
                    }
                }
            }
            return map;
        }
    }
}
