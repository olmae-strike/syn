using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_var
    {
    }
    /// type inference 기능으로 지역변수 선언을 타입에 관계없이 var 예약어로 할수 있게 됨.
    /// 실제 타입으로 치환 되는 것 뿐(컴파일 시 타입 고정됨)이므로 필요한 곳에만 쓰면 가독성이 좋아짐
    /// ex)Dictionary 요소 열람
    /// 
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            List<int> numbers2 = new List<int>(new int[] { 6, 7, 8, 9, 10 });

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();

            dict["first"] = numbers1;
            dict["second"] = numbers2;

            foreach (KeyValuePair<string, List<int>> elem in dict)//foreach(var elem in dict)
            {
                Console.WriteLine(elem.Key + ": " + Output(elem.Value));
                
            }
        }
        private static string Output(List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int elem in list)
                sb.AppendFormat("{0},", elem);
            return sb.ToString().TrimEnd(',');
        }
    }

}
