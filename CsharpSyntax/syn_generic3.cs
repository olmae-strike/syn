using System;
namespace ConstraintsOnTypeParameters
{

    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public int Length { get; set; }

        public StructArray(int size)
        {
            Array = new T[size];
            Length = size;
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public int Length { get; set; }

        public RefArray(int size)
        {
            Array = new T[size];
            Length = size;
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public int Length { get; set; }

        public BaseArray(int size)
        {
            Array = new U[size];
            Length = size;
        }

        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }


    public interface IInterface
    {

    }

    public interface IWhatever : IInterface
    {
        void ShowArrayLength();
    }

    public class InterfaceArray<T> where T : IInterface
    {
        public T[] Array { get; set; }
        public int Length { get; set; }
        public InterfaceArray(int size)
        {
            Array = new T[size];
            Length = Array.Length;
        }
    }

    class Program
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main(string[] args)
        {

            // 값 형식으로 제약
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 1;
            a.Array[1] = 2;
            a.Array[2] = 3;

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a.Array[i]);
            }
            Console.WriteLine("/////////");

            // 참조형식으로 제약
            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(200);

            for (int i = 0; i < b.Length; i++)
            {
                Console.WriteLine(b.Array[i].Length);
            }
            Console.WriteLine("/////////");

            // 기반 클래스로 제약
            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(c.Array[i]);
            }
            Console.WriteLine("/////////");

            // 기반 클래스로 제약
            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived(); //Derived가 기반 클래스가 되기 때문에 Base 할당 불가
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d.Array[i]);
            }
            Console.WriteLine("/////////");

            // U로부터 상속받은
            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array);

            Console.WriteLine(e.Array.Length);

            //인터페이스 제약
            InterfaceArray<IWhatever> f = new InterfaceArray<IWhatever>(3);
        }
    }
}