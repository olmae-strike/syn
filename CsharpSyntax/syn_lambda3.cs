using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpSyntax
{
    class syn_lambda3
    {
    }
    static class myextension
    {
        public static IEnumerable<int> WhereFunc(this IEnumerable<int> inst)
        {
            foreach (var item in inst)
            {
                if (item % 2 == 0)
                {
                    yield return item;
                }
            }
        }
    }
    class Person
    {
        public int Age;
        public string Name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 3, 1, 56, 34, 23, 77 };
            List<int> evenList = new List<int>();

            list.ForEach((elem) => { Console.WriteLine(elem + " * 2 == " + (elem * 2)); });

            foreach (var item in list)
            {
                if (item % 2 == -0)
                {
                    evenList.Add(item);
                }
            }
            foreach (var item in evenList)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
            List<int> evenList2 = list.FindAll((elem) => elem % 2 == 0);
            evenList2.ForEach((elem) => { Console.Write(elem + ","); });
            Console.WriteLine();
            Console.WriteLine();

            int count = list.Count((elem) => elem > 3); //extension method
            Console.WriteLine("3보다 큰수는" + count + "개 있습니다");

            IEnumerable<int> enumList = list.Where((elem) => elem % 2 == 0);
            Array.ForEach(enumList.ToArray(), (elem) => { Console.WriteLine(elem); });

            Console.WriteLine();


            IEnumerable<int> enumList3 = list.WhereFunc();
            Array.ForEach(enumList3.ToArray(), (elem) => { Console.WriteLine(elem); }); //확장메서드

            ///where 메서드는 FindAll과 유사하나 반환값이 IEnumerable<T>이다 확장메서드 WhereFunc와 유사하게 yield return에 가깝다.
            ///FindAll은 메서드 실행이 완료되는 순간 람다 메서드가 컬렉션의 모든 요소를 대상으로 실행되고 조건 만족하는 목록을 반환
            ///Where는 메서드 실행되어도 코드는 실행되지 않고, 열거자가 순회를 시작해야 람다메서드가 하나씩 실행된다.
            ///이를 지연된 평가(lazy evaluation)이라고 한다.
            ///IEnumerable<T>를 반환하는 모든 메서드가 이런 방식으로 동작. 소수 1만개 반환 메서드에서 500개만 필요해도 FindAll방식이면
            ///1만개 다 구할때까지 CPU가 실행되어야 하지만 IEnumerable<T>방식의 지연 평가를 사용하면 500개 필요한 조건에서 반환가능하다.
            Console.WriteLine();

            IEnumerable<double> doubleList = list.Select((elem) => (double)elem);
            Array.ForEach(doubleList.ToArray(), (elem) => { Console.WriteLine(elem); });    //Select 확장메서드는 요소별 형변환 가능
            Console.WriteLine(); 


            IEnumerable<Person> personList = list.Select((elem) => new Person { Age = elem, Name = Guid.NewGuid().ToString() });
            Array.ForEach(personList.ToArray(), (elem) => { Console.WriteLine(elem.Name); });   //형변환 뿐 아니라 객체 반환도 됨
            Console.WriteLine();

            var itemList = list.Select((elem) => new { TypeNo = elem, CreatedDate = DateTime.Now.Ticks });
            Array.ForEach(itemList.ToArray(), (elem) => { Console.WriteLine(elem.TypeNo + elem.CreatedDate); });    //익명 타입 변환 가능

            ///Select 역시 Where와 마찬가지로 IEnumerable<T> 타입을 반환하므로 지연 평가이다
            ///FindAll -> Where
            ///CovertAll - > Select 버전이라 생각해도 된다. 지연 평가 필요성에 따라 알맞은 것 사용하면 된다.

        }

    }
    
}
