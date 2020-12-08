using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpSyntax
{
    class Program
    {

        static void Main(string[] args)
        {
            object[] tt = new object[5];

            object[] testArr_1 = new object[] { 1, 2, "a", "b" };
            object[] testArr_2 = new object[] { "a", "b", 10, 115 };
            object[] testArr_3 = new object[] { };
            object[] testArr_4 = new object[] { -4, "k", 0 };
            object[] testArr_5 = new object[] { "Hell000!", 5 };

            //StringComparer dd;
            string[] dd = new string[testArr_1.Length];
            int n = 0;
            foreach (object obj in testArr_1)
            { 
                dd[n] = obj.ToString();
                n++;
            }
            printString(dd);

            bool result = testArr_1.SequenceEqual(testArr_2);
            Console.WriteLine("array equal? {0}", result);

        }
        public static void printString(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine($"{arr[i]} <-content type-> {arr[i].GetType()}==");
        }
        public static string[] ParseArray(object[] arr)
        {
            string[] convert = new string[arr.Length];
            for(int i =0;i<arr.Length;i++)
            {
                convert[i] = arr[i].ToString();
            }
            return convert;
        }
        public static string[] ParseArray2(object[] arr)
        {
            return arr.Select(o => o.ToString()).ToArray();
        }
        public static string[] ParseArray3(object[] arr)
        {
            return Array.ConvertAll(arr, x => x.ToString());
        }
    }

}
