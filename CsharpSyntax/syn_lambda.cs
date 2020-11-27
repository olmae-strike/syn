using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace CsharpSyntax
{
    class syn_lambda
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");
            Thread thread = new Thread(
                //delegate (object obj)
                (obj)=>
                {
                    Console.WriteLine("ThreadFunc in anonymous method called!");
                });
            //Thread 타입의 생성자는 delegate 로 실행 함수를 전달 받는데 메서드 정의 대신
            //직접 delegate 예약어로 코드를 전달할 수도 이다. delegate 예약어 괄호 안에는 원래
            //delegate 형식에서 필요로 하는 매개변수를 전달해야 한다.


            //Thread type constructor 는 void(object obj) 형식의 delegate인자 하나를 받는다는것을 컴파일러가 알고 있기 때문에 
            //더 단순화 해서 (obj)=>로 간편 표기할 수 있다.
            //anonymous method 에서 delegate(type iden) 형태인데, 여기서 delegate생략 하고 (identifier)=> 형태로 간편 표기법을 사용.
            // 이것은 람다 구문이 된다 lambda statement.
            thread.Start();

            thread.Join();
            Action line = () => Console.WriteLine();
            Func<double, double> cube = x => x * x * x;
            Func<int, int, bool> testForEquality = (x, y) => x == y;
            Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;
            Func<int, int, int> constant = (_, _) => 42;

        }
    }

}
