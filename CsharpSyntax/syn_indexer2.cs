using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_indexer2
    {
    }
    // Indexer 예제 클래스
    class Node
    {
        // 맴버 변수
        private List<string> data = new List<string>();
        // 이것이 인덱서 문법이다.
        // 반환형과 함수명 자리에는 this를 넣고, 배열같이 대괄호로 데ㅇ이터를 받는다.
        public int this[string keyword]
        {
            // 인덱서의 get입니다.
            get
            {
                // 해당 키워드의 위치를 반환한다.
                for (int i = 0; i < data.Count; i++)
                {
                    // 키워드와 맴버 변수 리스트의 객체 아이템과 같은 값이면
                    if (string.Equals(data[i], keyword))
                    {
                        // 위치 반환
                        return i;
                    }
                }
                // 키워드가 없으면 -1를 반환
                return -1;
            }
            // 인덱서의 set입니다.
            set
            {
                // 리스트에서 해당 키워드를 제거
                data.Remove(keyword);
                // 리스트에 index에 해당하는 위치에 키워드를 추가
                data.Insert(value, keyword);
            }
        }
        // 출력 함수
        public void Print()
        {
            // 맴버 변수 리스트 순서대로
            foreach (var d in this.data)
            {
                // 콘솔 출력한다.
                Console.WriteLine(d);
            }
        }
    }
    class Program
    {
        // 실행 함수
        static void Main(string[] args)
        {
            // Node 인스턴스 생성
            Node node = new Node();
            // 인덱서를 이용하기 때문에 마치 배열처럼 들어간다.
            node["Hello"] = 0;
            node["World"] = 1;
            node["why"] = 2;
            node["no black"] = 3;
            node["Ok"] = 4;
            // 콘솔 출력
            node.Print();
            // 개행
            Console.WriteLine();
            // 인덱서 set을 통해서 Hello의 배열 위치를 바꾼다.
            Console.WriteLine(node["Hello"]);
            Console.WriteLine(node["World"]);

            node["Ok"] = 0;
            // 인덱서 get을 통해서 Hello의 배열 위치를 확인한다.
            Console.WriteLine(node["Hello"]);
            // 개행
            Console.WriteLine();
            // 콘솔 출력
            node.Print();
            // 아무 키나 누르시면 종료합니다.
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }


    //출처: https://nowonbun.tistory.com/428 [명월 일지]
}
