using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_indexer
    {
    }
    class IntegerText
    {
        char[] txtNumber;

        public IntegerText(int number)
        {
            this.txtNumber = number.ToString().ToCharArray();
        }
        public char this[int index]
        {
            get { return txtNumber[txtNumber.Length - index - 1]; }
            set { txtNumber[txtNumber.Length - index - 1] = value; }
        }
        public override string ToString()
        {
            return new string(txtNumber);
        }
        public int ToInt32()
        {
            return Int32.Parse(ToString());
        }

    }
    class Notebook
    {
        int inch;
        int memoryGB;

        public Notebook(int inch, int memoryGB)
        {
            this.inch = inch;
            this.memoryGB = memoryGB;
        }
        public int this[string propertyName]
        {
            get
            {
                switch(propertyName)
                {
                    case "인치":
                        return inch;
                    case "메모리크기":
                        return memoryGB;
                }
                return -1;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");

            IntegerText aInt = new IntegerText(123456);

            int step = 1;
            for(int i = 0; i < aInt.ToString().Length; i++)
            {
                Console.WriteLine(step + "의 자리수: " + aInt[i]);
                step *= 10;
            }
            aInt[3] = '5';
            Console.WriteLine(aInt.ToInt32());


            Notebook normal = new Notebook(13, 4);

            Console.WriteLine("모니터 인치: " + normal["인치"] + "\"");
            Console.WriteLine("메모리 크기: " + normal["메모리크기"] + "GB");
        }
    }
}
