using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kochCarve
{
    class Program
    {
        struct Coordinate
        {
            internal double x;
            internal double y;
        }

        static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Coordinate a, b;
            a.x = 0.0;
            a.y = 0.0;
            b.x = 100.0;
            b.y = 0.0;

            sb.AppendLine(string.Format("{0:f8} {1:f8}", a.x, a.y));
            Koch(n, a, b);
            sb.AppendLine(string.Format("{0:f8} {1:f8}", a.x, a.y));

            Console.WriteLine(sb);
            Console.ReadLine();
        }

        static void Koch(int n, Coordinate a, Coordinate b)
        {
            if (n == 0) return;

            double rd = Math.PI * 60.0 / 180;

            Coordinate s, t, u;
            s.x = (2.0 * a.x + 1.0 * b.x) / 3.0;
            s.y = (2.0 * a.y + 1.0 * b.y) / 3.0;
            t.x = (1.0 * a.x + 2.0 * b.x) / 3.0;
            t.y = (1.0 * a.y + 2.0 * b.y) / 3.0;
            u.x = (t.x - s.x) * Math.Cos(rd) - (t.y - s.y) * Math.Sin(rd) + s.x;
            u.y = (t.x - s.x) * Math.Sin(rd) - (t.y - s.y) * Math.Cos(rd) + s.y;

            Koch(n - 1, a, s);
            sb.AppendLine(string.Format("{0:f8} {1:f8}", s.x, s.y));
            Koch(n - 1, s, u);
            sb.AppendLine(string.Format("{0:f8} {1:f8}", u.x, u.y));
            Koch(n - 1, u, t);
            sb.AppendLine(string.Format("{0:f8} {1:f8}", t.x, t.y));
            Koch(n - 1, t, b);

        }

    }
}
//static void Koch(int n, Coordinate a, Coordinate b)
//{
//    if (n == 0) return;

//    // 60°のラジアン角
//    double rd = Math.PI * 60.0 / 180;

//    // 座標計算
//    Coordinate s, t, u;
//    s.x = (2.0 * a.x + 1.0 * b.x) / 3.0;
//    s.y = (2.0 * a.y + 1.0 * b.y) / 3.0;
//    t.x = (1.0 * a.x + 2.0 * b.x) / 3.0;
//    t.y = (1.0 * a.y + 2.0 * b.y) / 3.0;
//    u.x = (t.x - s.x) * Math.Cos(rd) - (t.y - s.y) * Math.Sin(rd) + s.x;
//    u.y = (t.x - s.x) * Math.Sin(rd) + (t.y - s.y) * Math.Cos(rd) + s.y;

//    Koch(n - 1, a, s);
//    sb.AppendLine(string.Format("{0:f8} {1:f8}", s.x, s.y));
//    Koch(n - 1, s, u);
//    sb.AppendLine(string.Format("{0:f8} {1:f8}", u.x, u.y));
//    Koch(n - 1, u, t);
//    sb.AppendLine(string.Format("{0:f8} {1:f8}", t.x, t.y));
//    Koch(n - 1, t, b);
//}