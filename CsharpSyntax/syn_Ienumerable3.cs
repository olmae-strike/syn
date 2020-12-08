using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsharpSyntax
{
    class syn_Ienumerable3
    {
    }
    class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class Node
    {
        public object data;
        public Node left, right;

        public Node(Person data, Node left, Node right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }
    }

    class LinkedList : IEnumerable
    {
        private Node now;
        public LinkedList()
        {
            now = null;
        }
        public Node Head
        {
            get
            {
                while (now != null && now.left != null)
                    now = now.left;
                return now;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        MyEnumerator GetEnumerator()
        {
            return new MyEnumerator(Head);
        }
        public void Add(Person data)
        {
            if (now == null)
                now = new Node(data, null, null);
            while(now.right!=null)
            {
                now = now.right;
            }
            now.right = new Node(data, now, null);
            now = now.right;

        }
    }

    class MyEnumerator : IEnumerator
    {
        private Node node;
        public MyEnumerator(Node head)
        {
            this.node = head;
        }
        //private object Current => node.data;
        private object Current
        {
            get=> node.data;
        }
        object IEnumerator.Current
        {
            get => Current;
        }
        bool IEnumerator.MoveNext()
        {
            if (node.right == null)
                return false;
            else
            {
                node = node.right;
                return true;
            }
        }
        void IEnumerator.Reset()
        {
            while (node.left != null)
                node = node.left;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.Add(new Person("CheolSoo", 26));
            list.Add(new Person("CheolDoo", 34));
            list.Add(new Person("CheolGoo", 29));

            foreach(Person person in list)
            {
                Console.WriteLine($"name : {person.name}, age : {person.age}");

            }

            Console.ReadLine();

        }
    }



}






