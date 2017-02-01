using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class LineSegment
    {
        public Point p1 { get; set; }
        public Point p2 { get; set; }
       
        public LineSegment() {

        }

        public LineSegment(int point1X, int point1Y, int point2X, int point2Y) {
            p1 = new Point();
            p2 = new Point();
            p1.x = point1X;
            p1.y = point1Y;
            p2.x = point2X;
            p2.y = point2Y;
        }

        private static void read_point(Point p)
        {
            Console.Write("\t\tx co-ordinate : ");
            p.x = int.Parse(Console.ReadLine());//Console.ReadLine(p.x);
            Console.Write("\t\ty co-ordinate : ");
            p.y = int.Parse(Console.ReadLine());
        }
        private static void print_point(Point p)
        {
            Console.Write("\t\tx co - ordinate : " + p.x);
            Console.WriteLine("\n\t\ty co - ordinate : " + p.y);
        }
        public void read_LineSeg()
        {
            Console.WriteLine("\n\tEnter the co-ordinates of the 1st point : ");
            read_point(p1);
            Console.WriteLine("\n\tEnter the co-ordinates of the 2nd point :");
            read_point(p2);
        }
        public void print_LineSeg()
        {
            Console.WriteLine("\tThe co-ordinates of the 1st point : ");
            print_point(p1);
            Console.WriteLine("\tThe co-ordinates of the 2nd point : ");
            print_point(p2);
        }
    }
    public static class LineSegmentUtil
    {
        public static bool SegIntersect(LineSegment l1, LineSegment l2)
        {
            float dy1 = l1.p2.y - l1.p1.y;
            float dx1 = l2.p2.x - l2.p1.x;
            float dx2 = l1.p2.x - l1.p1.x;
            float dy2 = l2.p2.y - l2.p1.y;

            if (dy1 == 0 && dx1 == 0)
            {   //slope of 1st line is 0 and 2nd line is perpendicular to it
                int fixedPoint = l1.p1.y;
                for (int arb = l2.p1.y; arb <= l2.p2.y; arb++)
                {
                    if (fixedPoint == arb)
                        return true;
                    else
                        return false;
                }
            }
            else if (dy2 == 0 && dx2 == 0)
            {     //slope of 1st line is 90 and 2nd line is perpendicular to it
                int fixedPoint = l2.p1.y;
                for (int arb = l1.p1.y; arb <= l1.p2.y; arb++)
                {
                    if (fixedPoint == arb)
                        return true;
                    else
                        return false;
                }
            }
            else if (dx2 == 0 && dy2 != 0)
            { // if slope of 1st line is 90 and 2nd line is not perpendicular to it.
                float fixedx = l1.p1.x, fixedy;
                if (l2.p1.y < l2.p2.y)
                {
                    for (fixedy = l2.p1.y; fixedy <= l2.p2.y; fixedy += 0.1f)
                    {
                        if ((l1.p1.x * (l1.p2.y - fixedy) + l1.p2.x * (fixedy - l1.p1.y) + fixedx * (l1.p1.y - l1.p2.y)) == 0)
                            break;
                    }
                    if (l1.p1.y < l1.p2.y)
                    {
                        if (l1.p1.y <= fixedy && fixedy <= l1.p2.y)
                            return true;
                        else
                            return false;
                    }
                    else if (l1.p2.y < l1.p1.y)
                    {
                        if (l1.p2.y <= fixedy && fixedy <= l1.p1.y)
                            return true;
                        else
                            return false;
                    }
                }
                else if (l2.p2.y < l2.p1.y)
                {
                    for (fixedy = l2.p2.y; fixedy <= l2.p1.y; fixedy = fixedy + 0.1f)
                    {
                        if ((l1.p1.x * (l1.p2.y - fixedy) + l1.p2.x * (fixedy - l1.p1.y) + fixedx * (l1.p1.y - l1.p2.y)) == 0)
                            break;
                    }
                    if (l1.p1.y < l1.p2.y)
                    {
                        if (fixedy >= l1.p1.y && fixedy <= l1.p2.y)//l1.p1.y<=fixedy<=l1.p2.y
                            return true;
                        else
                            return false;
                    }
                    else if (l1.p2.y < l1.p1.y)
                    {
                        if (fixedy >= l1.p2.y && fixedy <= l1.p1.y)//l1.p2.y<=fixedy<=l1.p1.y
                            return true;
                        else
                            return false;
                    }
                }
            }
            else if (dx1 == 0 && dy1 != 0)
            {  //if 1st line is not perpendicular to 2nd line whose slope is 90
                float fixedx = l2.p1.x, fixedy;
                if (l1.p1.x < l1.p2.x)
                {
                    for (fixedy = l1.p1.y; fixedy <= l1.p2.y; fixedy += 0.1f)
                    {
                        if ((l2.p1.x * (l2.p2.y - fixedy) + l2.p2.x * (fixedy - l2.p1.y) + fixedx * (l2.p1.y - l2.p2.y)) == 0)
                            break;
                    }
                    if (l2.p1.y < l2.p2.y)
                    {
                        if (l2.p1.y <= fixedy && fixedy <= l2.p2.y)
                            return true;
                        else
                            return false;
                    }
                    else if (l2.p2.y < l2.p1.y)
                    {
                        if (l2.p2.y <= fixedy && fixedy <= l2.p1.y)
                            return true;
                        else
                            return false;
                    }
                }
                else if (l1.p2.x < l1.p1.x)
                {
                    for (fixedy = l1.p2.y; fixedy <= l1.p1.y; fixedy += 0.1f)
                    {
                        if ((l2.p1.x * (l2.p2.y - fixedy) + l2.p2.x * (fixedy - l2.p1.y) + fixedx * (l2.p1.y - l2.p2.y)) == 0)
                            break;
                    }
                    if (l2.p1.y < l2.p2.y)
                    {
                        if (l2.p1.y <= fixedy && fixedy <= l2.p2.y)
                            return true;
                        else
                            return false;
                    }
                    else if (l2.p2.y < l2.p1.y)
                    {
                        if (l2.p2.y <= fixedy && fixedy <= l2.p1.y)
                            return true;
                        else
                            return false;
                    }
                }
            }
            else if (dx1 != 0 && dy1 == 0)
            { // if slope of 1st line is 0 and 2nd line is not perpendicular to it.
                float fixedy = l1.p1.x, fixedx;
                if (l2.p1.y < l2.p2.y)
                {
                    for (fixedx = l2.p1.x; fixedx <= l2.p2.x; fixedx += 0.1f)
                    {
                        if ((l1.p1.y * (l1.p2.x - fixedx) + l1.p2.y * (fixedx - l1.p1.x) + fixedy * (l1.p1.x - l1.p2.x)) == 0)
                            break;
                    }
                    if (l1.p1.x < l1.p2.x)
                    {
                        if (l1.p1.x <= fixedx && fixedx <= l1.p2.x)
                            return true;
                        else
                            return false;
                    }
                    else if (l1.p2.x < l1.p1.x)
                    {
                        if (l1.p2.x <= fixedx && fixedx <= l1.p1.x)
                            return true;
                        else
                            return false;
                    }
                }
                else if (l2.p2.y < l2.p1.y)
                {
                    for (fixedx = l2.p2.x; fixedx <= l2.p1.x; fixedx += 0.1f)
                    {
                        if ((l1.p1.y * (l1.p2.x - fixedx) + l1.p2.y * (fixedx - l1.p1.x) + fixedy * (l1.p1.x - l1.p2.x)) == 0)
                            break;
                    }
                    if (l1.p1.x < l1.p2.x)
                    {
                        if (l1.p1.x <= fixedx && fixedx <= l1.p2.x)
                            return true;
                        else
                            return false;
                    }
                    else if (l1.p2.x < l1.p1.x)
                    {
                        if (l1.p2.x <= fixedx && fixedx <= l1.p1.x)
                            return true;
                        else
                            return false;
                    }
                }
            }
            else if (dx2 != 0 && dy2 == 0)
            {     //if 1st line is not perpendicular to 2nd line whose slope is 0
                float fixedy = l2.p1.x, fixedx;
                if (l1.p1.y < l1.p2.y)
                {
                    for (fixedx = l1.p1.x; fixedx <= l1.p2.x; fixedx += 0.1f)
                    {
                        if ((l2.p1.y * (l2.p2.x - fixedx) + l2.p2.y * (fixedx - l2.p1.x) + fixedy * (l2.p1.x - l2.p2.x)) == 0)
                            break;
                    }
                    if (l2.p1.x < l2.p2.x)
                    {
                        if (l2.p1.x <= fixedx && fixedx <= l2.p2.x)
                            return true;
                        else
                            return false;
                    }
                    else if (l2.p2.x < l2.p1.x)
                    {
                        if (l2.p2.x <= fixedx && fixedx <= l2.p1.x)
                            return true;
                        else
                            return false;
                    }
                }
                else if (l1.p2.y < l1.p1.y)
                {
                    for (fixedx = l1.p2.x; fixedx <= l1.p1.x; fixedx += 0.1f)
                    {
                        if ((l2.p1.y * (l2.p2.x - fixedx) + l2.p2.y * (fixedx - l2.p1.x) + fixedy * (l2.p1.x - l2.p2.x)) == 0)
                            break;
                    }
                    if (l2.p1.x < l2.p2.x)
                    {
                        if (l2.p1.x <= fixedx && fixedx <= l2.p2.x)
                            return true;
                        else
                            return false;
                    }
                    else if (l2.p2.x < l2.p1.x)
                    {
                        if (l2.p2.x <= fixedx && fixedx <= l2.p1.x)
                            return true;
                        else
                            return false;
                    }
                }
            }
            float x12 = l1.p1.x - l1.p2.x;
            float x34 = l2.p1.x - l2.p2.x;
            float y12 = l1.p1.y - l1.p2.y;
            float y34 = l2.p1.y - l2.p2.y;

            float c = x12 * y34 - y12 * x34;

            if (Math.Abs(c) < 0.01)
            {
                // No intersection
                return false;
            }
            else
            {
                // Intersection
                float a = l1.p1.x * l1.p2.y - l1.p1.y * l1.p2.x;
                float b = l2.p1.x * l2.p2.y - l2.p1.y * l2.p2.x;
                //float x = (a * x34 - b * x12) / c;
                //float y = (a * y34 - b * y12) / c;
                return true;
            }
        }
    }
    public class Point
    {
        public int x;
        public int y;
    }
}
