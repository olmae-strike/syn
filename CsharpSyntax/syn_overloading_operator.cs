using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_overloading_operator
    {
    }
    public class Kilogram
    {
        double mass;

        public Kilogram(double value)
        {
            this.mass = value;
        }
        public Kilogram Add(Kilogram target)
        {
            return new Kilogram(this.mass + target.mass);
        }

        public override string ToString()
        {
            return mass + "Kg";
        }

        public static Kilogram operator +(Kilogram op1, Kilogram op2)
        {
            return new Kilogram(op1.mass + op2.mass);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");

            Kilogram kg1 = new Kilogram(5);
            Kilogram kg2 = new Kilogram(10);

            Kilogram kg3 = kg1.Add(kg2);
            Kilogram kg4 = kg1 + kg2;
            
            Console.WriteLine(kg3);
            Console.WriteLine("연산자 오버로딩으로~" + kg4);

        }
    }
}
