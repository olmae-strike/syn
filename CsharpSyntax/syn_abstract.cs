using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_abstract
    {

    }
    class Point
    {
        int x, y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            //return base.ToString();
            //{
                return "X: " + x + ", Y: " + y;
           //}
        }
    }

    abstract class DrawingObject
    {
        public abstract void Draw();    //추상메서드(뼈대만 제공)
        public void Move() { Console.WriteLine("Move"); }   //일반 메서드도 사용가능

    }
    
    class Line : DrawingObject
    {
        Point pt1, pt2;
        public Line(Point pt1,Point pt2)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
        }
        public override void Draw()
        {
            Console.WriteLine("Line " + pt1.ToString() + " ~~~~ " + pt2.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello C#!");
            DrawingObject line = new Line(new Point(10, 10), new Point(20, 20));
            line.Draw();
        }
    }
}
