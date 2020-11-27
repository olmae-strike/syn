using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_typecasting
    {
    }
    public class Currency
    {
        decimal money;
        public decimal Money { get { return money; } }
        public Currency(decimal money)
        {
            this.money = money;
        }

    }
    public class Won : Currency
    {
        public Won(decimal money) : base(money) { } 
        public override string ToString()
        {
            return Money + "Won";
        }
    }
    
    public class Dollar : Currency
    {
        public Dollar(decimal money) : base(money) { }
        public override string ToString()
        {
            return Money + "Dollar";
        }
    }

    public class Yen : Currency
    {
        public Yen(decimal money) : base(money) { }
        public override string ToString()
        {
            return Money + "Yen";
        }
        static public implicit operator Won(Yen yen)
        {
            return new Won(yen.Money * 13m);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");
            Yen yen = new Yen(100);

            Won won1 = yen;
            Won won2 = (Won)yen;

            Console.WriteLine(won1 + " 암시적 형변환을 오버로딩을 통해 구현한 결과");
            Console.WriteLine(won2 + " 명시적으로도 가능해진다");
        }
    }
}
