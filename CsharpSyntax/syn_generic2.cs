using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CsharpSyntax
{
    class syn_generic2
    {
    }

    /// 제네릭 제약조건. <T> 로 대체될 타입이 특정 메서드를 지원하지 않을 때 컴파일 오류 발생
    /// 이때 T에 입력될 타입의 조건을 where 예약어로 제한조건을 줄 수 있다.
    /// 예시)
    /// where T : IComparable 
    /// IComparable 인터페이스를 상속한 타입으로 T를 제한하고 있다.
    /// where T: struct
    /// where T: class
    /// where T: new()
    /// where T: U
    /// 값,참조,기본생성자 정의,U형식 인수 해당 타입 또는 상속받은 클래스.
    /// Marshal type. System.Runtime.InteropServices 네임스페이스에 정의되어있고 
    /// 값 형식의 바이트 크기 반환하는 SizeOf메서드 제공. 이걸로 제네릭메서드->모든 값형식 크기
    /// 

    //static class myExtension
    //{
    //    public static int GetSizeOf<T>(this int item)
    //    {
    //        return Marshal.SizeOf(item);
    //    }
    //}
    



    public class Utility
    {
        public static T Max<T>(T item1, T item2) where T : IComparable
        {
            if(item1.CompareTo(item2) >= 0)
            {
                return item1;
            }
            return item2;
        }
    }
    public class BaseClass { }
    public class DerivedClass : BaseClass { }

    
    class Program
    {
        public static void CheckNull<T>(T item) where T : class
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
        }
        public static int GetSizeOf<T>(T item) where T: struct
        {
            return Marshal.SizeOf(item);
        }
        public static T AllocateIfNull<T>(T item) where T: class,new()  // 기본 생성자가 꼭 있어야 할때 거는 제약조건
        {
            if(item == null)
            {
                item = new T();
            }
            return item;
        }
        public class myUtil
        {
            public static T Allocate<T, V>() where V: T,new()
            {
                return new V();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Utility.Max(5, 6));
            Console.WriteLine(Utility.Max("Abc","AAf"));

            Console.WriteLine(GetSizeOf(0.5f));
            Console.WriteLine(GetSizeOf(4m));
            //Console.WriteLine(GetSizeOf("my")); // 컴파일은 되나 실행 시 오류발생. 제약조건 필요.
            //int? a=null;
            string b = "my";
            //CheckNull(a);
            CheckNull(b);

            BaseClass dInst = new DerivedClass();
            BaseClass dInst2 = myUtil.Allocate<BaseClass, DerivedClass>();
            //T == BaseClass, V == DerivedClass . Allocate 메서드는 Derived Class를 new로 할당해 BaseClass로 형변환 하여 반환함


        }
    }


}
