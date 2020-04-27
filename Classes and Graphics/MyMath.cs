using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{
    static class MyMath
    {
        public static double Distance(int x1, int y1, int x2, int y2)
        {
            return Distance(new Point(x1, y1), new Point(x2, y2));
        }
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
}
