using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_interface
    {
    }

    class Computer { }
    interface IMonitor
    {
        void TurnOn();
    }
    interface IKeyboard { }

    class Notebook : Computer, IMonitor, IKeyboard
    {
        //public void TurnOn() { }    //abstrack class 와 달리 override 안써도 됨.구현은 해야함
        void IMonitor.TurnOn(){}  //2번방식
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C#!");
            Notebook notebook = new Notebook();
            //notebook.TurnOn();

            IMonitor mon = notebook as IMonitor;    //2번 방식으로 하면 interface명을 명시했기 때문에 interface형으로 형변환해야 호출 가능
            mon.TurnOn();
            Console.WriteLine(mon.ToString());
            System.Int32 a;
        }
    }
}
