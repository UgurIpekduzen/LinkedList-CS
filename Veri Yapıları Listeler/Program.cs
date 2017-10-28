using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapıları_Listeler
{
    class Node
    {
        public string ad;
        public int vize;
        public int final;
        public Node next;


        public Node(string ad,int vize,int final)
        {
            this.ad = ad;
            this.vize = vize;
            this.final = final;
        }

    }
    class LinkedList
    {
        Node head;
        Node tail;
        int count;

        public void InsertAtFront(Node N)
        {
            if (IsEmpty())
                head = tail = N;
            else
            {
                N.next = head;
                head = N;
            }
            count++;
        }

        public void InsertAtBack(Node N)
        {
            if (IsEmpty())
                head = tail = N;
           /* else if (head.next == null)
            {
                head.next = N;
                tail = N;
            }*/
            else
            {
                N.next = tail;
                tail = N;
            }
            count++;
        }

        public void InsertAt(Node N,int Index)
        {
            if (Index < 0 || Index >= count)
                Console.WriteLine("Yanlis sıra");
            else if (IsEmpty())
                head = tail = N;
            else if (Index == 0)
                InsertAtFront(N);
            else
            {
                Node current = head;

                for (int i = 0; i < Index; i++)
                    current = current.next;

                N.next = current.next;
                current.next = N;
                count++;
            }            
        }

        public void RemoveFromFront()
        {
            if (IsEmpty())
                Console.WriteLine("Liste Bos");
            else if (head == tail)
                head = tail = null;
            else
                head = head.next;
            count--;
        }

        public void RemoveFromBack()
        {
            if (IsEmpty())
                Console.WriteLine("Liste Bos");
            else if (head == tail)
                head = tail = null;
            else
            {
                Node current = head;
                while (current.next != tail)
                    current = current.next;
                tail = current;
                current.next = null;
            }
            count--;
        }

        public void RemoveFrom(int Index)
        {
            if (Index < 0 || Index >= count)
                Console.WriteLine("Yanlis sira");
            else if (IsEmpty())
                Console.WriteLine("Liste Bos");
            else if (Index == 0)
                RemoveFromFront();
            else if (Index == (count - 1))
                RemoveFromBack();
            else
            {
                Node current = head;
                for (int i = 1; i < Index; i++)
                    current = current.next;
                current.next = current.next.next;
                count--;
            }
        }

        public bool IsEmpty() { return count == 0; }

        public int GetCount() { return count; }

        public void Show()
        {
            Node Current = this.head;
            for(int i = 0;i < count; i++)
            {
                Console.Write("{0}: {1} {2}|",Current.ad,Current.vize,Current.final);
                Current = Current.next;
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList List = new LinkedList();

            Node N1 = new Node("Ali",90,70);
            Node N2 = new Node("Veli", 30, 60);
            Node N3 = new Node("Can", 40, 80);

            List.InsertAtFront(N1);
            List.InsertAtBack(N2);
            List.InsertAt(N3,1);
            List.Show();
        }
    }
}
