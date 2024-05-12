using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace Linked_list;

class Program

{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T>? Next { get; set; }
    }

    public class Node2
    {
        public Node2(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public Node2? Next { get; set; }
    }
    public class IntLinkedList : IEnumerable
    {
        Node2? Head;
        Node2? Tail;
        int count;
        public void Add(int data)
        {
            Node2 node2 = new Node2(data);
            if (Head == null)
            {
                Head = node2;
            }
            else
            {
                Tail!.Next = node2;
            }
            Tail = node2;
            count++;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node2? current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void DelletAll()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public bool DelletAlement(int data)
        {
            Node2 current = Head;
            Node2 previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную Tail
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение Head
                        Head = Head?.Next;

                        // если после удаления список пуст, сбрасываем Tail
                        if (Head == null)
                            Tail = null;
                    }
                    count--;
                    return true;


                }
                previous = current;
                current = current.Next;
            }
            return false;
        }








        // public void PrintIntLinkedList(IntLinkedList VarNode)
        // {Console.Write($"{VarNode.}");

        // }
        // public class LinkedList<T> : IEnumerable<T>  // односвязный список
        // {
        //     Node<T>? Head; // головной/первый элемент
        //     Node<T>? Tail; // последний/хвостовой элемент
        //     int count;  // количество элементов в списке

        //     // добавление элемента
        //     public void Add(T data)
        //     {
        //         Node<T> node = new Node<T>(data);

        //         if (Head == null)
        //             Head = node;
        //         else
        //             Tail!.Next = node;
        //         Tail = node;

        //         count++;
        //     





        //     IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //     {
        //         Node<T>? current = Head;
        //         while (current != null)
        //         {
        //             yield return current.Data;
        //             current = current.Next;
        //         }
        //     }
        //     IEnumerator IEnumerable.GetEnumerator()
        //     {
        //         return ((IEnumerable<T>)this).GetEnumerator();
        //     }
        // }
    }

        static void Main(string[] args)
        {
            // LinkedList<int> ListNode = new LinkedList<int>{
            //     32,
            //     55,
            //     47
            // };
            IntLinkedList IntListnode = new IntLinkedList();
            IntListnode.Add(5);
            IntListnode.Add(4);
            IntListnode.Add(55);
            foreach (var inumb in IntListnode)
                Console.WriteLine($"{inumb}");
            IntListnode.DelletAlement(4);
            foreach (var inumb in IntListnode)
                Console.WriteLine($"{inumb}");


            Console.ReadLine();
        }



    }
