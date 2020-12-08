using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_generic1
    {
    }
    ///제네릭의 사용은 박싱/언박싱으로 발생하는 비효율적인 힙 메모리 사용 문제를 없애고
    ///데이터 타입에 따른 코드 중복 문제도 해결해 준다
    ///제네릭이란? 컬렉션에 먼저 도입된 문법인데 <T>로 나타내어 특정 타입이, 타입 매개변수 T자리에 들어가면
    ///CLR은 컴파일 시에 클래스를 대응 타입에 따라 대체하고 확장한다. 예를들어 <int> 와 <double> 을 사용하면
    ///<T>를 읽은 CLR은 2가지의 클래스를 기계어로 자동 생성한다. 이렇게 제네릭이 클래스 수준에서 지정된 것을
    ///제네릭 클래스 라고 하고, 메서드 수준에서도 정의될 수 있다.
    ///ex) class GenericClass<T>, public void GenericMethod<T>(T item)

    public class NewStack<T>
    {
        T[] _objList;
        int _pos;

        public NewStack(int size)
        {
            _objList = new T[size];
        }

        public void Push(T newValue)
        {
            _objList[_pos] = newValue;
            _pos++;
        }
        public T Pop()
        {
            _pos--;
            return _objList[_pos];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewStack<int> intStack = new NewStack<int>(10);
            intStack.Push(1);
            intStack.Push(3);
            intStack.Push(5);
            intStack.Push(9);

            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Console.WriteLine(intStack.Pop());
            Utility.WriteLog<bool>(true);
            Utility.WriteLog<int>(0x05);
            Utility.WriteLog<float>(3.141592f);
            Utility.WriteLog<string>("test");
        }
    }
    public class GenericSample<Type>
    {
        Type _item;
        public GenericSample(Type value)
        {
            _item = value;
        }
    }
    public class TwoGeneric<K,V>
    {
        K _key;
        V _value;

        public void Set(K key, V value)
        {
            _key = key;
            _value = value;
        }
    }
    public class Utility
    {
        public static void WriteLog<T>(T item)
        {
            string output = string.Format("{0} : {1}", DateTime.Now, item);
            Console.WriteLine(output);
        }
    }









}

