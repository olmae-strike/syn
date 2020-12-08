using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_closure1
    {
        public void DoTest()
        {
            List<Action> list = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(() => Console.WriteLine(i));
            }

            list.ForEach(p => p());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            syn_closure1 a = new syn_closure1();
            a.DoTest();
        }
        
    }
    
}
