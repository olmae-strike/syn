using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace CsharpSyntax
{
    class syn_anonyMethod
    {
    }
    class Program
    {
        delegate int? MyDivide(int a, int b);
        static void Main(string[] args)
        {
            MyDivide myFunc = delegate (int a, int b)
            {
                if (b == 0)
                {
                    return null;
                }
                return a / b;
            };
            WriteLine("10/2 == " + myFunc(10, 2));
            WriteLine("10/2 == " + myFunc(10, 0));












            Console.WriteLine("Hello C#!");

            //Thread thread = new Thread(ThreadFunc);
            Thread thread = new Thread(
                delegate (object obj)
                {
                    Console.WriteLine("ThreadFunc in anonymous method called!");    
                });
            //Thread 타입의 생성자는 delegate 로 실행 함수를 전달 받는데 메서드 정의 대신
            //직접 delegate 예약어로 코드를 전달할 수도 이다. delegate 예약어 괄호 안에는 원래
            //delegate 형식에서 필요로 하는 매개변수를 전달해야 한다.

            thread.Start();

            thread.Join();
        }
        private static void ThreadFunc(object obj)
        {
            Console.WriteLine("ThreadFunc called!");
        }

    }
}
