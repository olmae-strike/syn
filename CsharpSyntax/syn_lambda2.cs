using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_lambda2
    {
    }

    ///delegate int? myDivide(int a,int b);
    ///delegate int myAdd(int a,int b);
    ///람다 메서드는 일회성으로 사용하는 간단한 코드를 표현할 때 사용하는데 일일히 delegate를 정의해야해서 불편
    ///제네릭 형식을 써서 BCL 에 Action과 Func 도입

    ///public delegate void Action<T>(T obj)
    ///public delegate void Action<T1,T2,,,T16>(T1 arg1,T2 arg2,,,T16 arg16)
    ///반환값이 없을 때 Action 사용, 파라미터는 입력 인자 타입.
    ///
    ///반환값이 있을 때 Func 사용, 파라미터는 입력 인자,...,반환 타입
    ///public delegate TResult Func<TResult>()
    ///public delegate TResult Func<T1,T2,T3,,,TResult>(T1 arg1,T2 arg2,T3 arg3,,)
    ///
    ///Func<int,string,bool> is TooLong = (int x, string s) => s.Length > x; 컴파일러가 형식 유추할 수 없을 때 명시
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> logOut =
                (txt) =>
                {
                    Console.WriteLine(DateTime.Now + ": " + txt);
                };
            logOut("This is my world!");

            Func<double> pi = () => 3.141592;
            Console.WriteLine(pi());
            Console.WriteLine();

            List<int> list = new List<int> { 3, 1, 4, 5, 2 };
            
            foreach (var item in list)
            {
                Console.WriteLine(item + " *2 == " + (item * 2));

            }
            Console.WriteLine();

            ///List<T>에 정의된 ForEach
            ///public void ForEach(Action<T> action);
            ///
            /// Array에 정의된 ForEach
            /// public static void ForEach<T>(T[] array,Action<T> action);

            list.ForEach((elem) => { Console.WriteLine(elem + " *2 == " + (elem * 2)); });
            Console.WriteLine();

            Array.ForEach(list.ToArray(), (elem) => { Console.WriteLine(elem + " *2 ==" + (elem * 2)); });  //람다메서드
            Console.WriteLine();

            list.ForEach(delegate (int elem) { Console.WriteLine(elem + " *2 == " + (elem * 2)); });    //익명메서드
            Console.WriteLine();

            ///list에 있는 모든 요소를 Action<T>에 전달 ForEach( (elem)=> { } );






        }
    }

}
