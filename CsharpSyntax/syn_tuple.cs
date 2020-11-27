using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_tuple
    {    }

    public class IntResult
    {
        public bool Parsed { get; set; }
        public int Number { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");

            Program pg = new Program();


            //(bool, int) result = pg.ParseInteger("50");
            //Console.WriteLine(result.Item1);
            //Console.WriteLine(result.Item2);

            var result = pg.ParseInteger("50");     //var 예약어로 호출하고 구현부에 튜플 타입으로 하여 매개변수 이름 지정 가능
            Console.WriteLine(result.Parsed);
            Console.WriteLine(result.Number);

            //(bool success, int n) result = pg.ParseInteger("50");     //호출 측에서 강제로 이름 지정 가능
            //Console.WriteLine(result.success);
            //Console.WriteLine(result.n);

            //(var success,var number) result = pg.ParseInteger("50");      //var 예약어로 개별로 분리 가능
            //Console.WriteLine(success);
            //Console.WriteLine(number);

        }

        //        (bool,int) ParseInteger(string text)
        (bool Parsed,int Number) ParseInteger(string text)
        {
            int number = 0;
            bool result = false;

            try
            {
                number = Int32.Parse(text);
                result= true;
            }
            catch
            {
            }
            return (result,number);
        }
    }
    
}
