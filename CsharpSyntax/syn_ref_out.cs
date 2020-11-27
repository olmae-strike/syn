using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_ref_out
    {
    }

    



    class Program
    {
        static void Main(string[] args)
        {
            int v1 = 5;
            int v2 = 10;
            int c = 0;
            object a ="a";
            object b =1.0;
            //object a = new object();
            //object b = new object();
            Console.WriteLine("{0}  {1} ", a.GetType(),b.GetType());

            a = (object)(v1.ToString());
            Console.WriteLine("{0} {1}", a.GetType(),(object)v1.GetType());
            c = v1;
            Console.WriteLine("{0} {1}ffffffff", c.GetType(),v1.GetType());

            b = v2;
            Console.WriteLine("{0} + {1} {2}",a,b,a.GetType() );



        }
    }

}
