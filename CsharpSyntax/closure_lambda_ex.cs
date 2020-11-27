using System;
using System.Collections;
namespace TestProject
{
    class Program
    {
        public static void Main(string[] args)
        { 
            // 가짜 버튼을 10개를 만들어서, 
            PseudoButton[] buttons = new PseudoButton[10];
            // 각 버튼마다 클릭 이벤트 때 할 일들을 정해준다. 
            for (int i = 0; i < 10; i++) 
            { 
                buttons[i] = new PseudoButton(); 
                buttons[i].SetOnClick(() => { Console.WriteLine(string.Format("I am {0}th button", i)); }); 
            } 
            // "I am 5th button"이 출력되길 기대한다. 
            buttons[5].OnClick(); 
        } 
    } 

    // 여기선 단순히 버튼의 onClick 메소드만 보관하는 가짜 버튼 클래스 
    class PseudoButton
    { 
        public delegate void VoidDelegate(); 
        private VoidDelegate onClick; 
        public void SetOnClick(VoidDelegate onClick) { this.onClick = onClick; } 
        public void OnClick() 
        { // 유니티에서 못 쓰는거 여기에서라도 써보자 
            this.onClick?.Invoke(); } 
    } 
}

        //출처: https://enghqii.tistory.com/49 [그냥저냥 휴학생]

       