using classLibrary.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace classLibrary.BL
{

    public class Stacks
    {
        private Node head;
        private String name;
        private int length;

        public Stacks()
        {
            this.head = null;
            this.length = 0;
        }

        public Stacks(String name)
        {
            this.head = null;
            this.name = name;
            this.length = 0;
        }

        public void push(Cards data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            this.length++;
        }

       

        public Cards pop()
        {
            if (head == null)
            {
                Console.WriteLine("Stack is empty");
                return null;
            }
            else
            {
                Cards poppedCard = head.Data;
                head = head.Next;
                this.length--;
                return poppedCard;
            }
        }


        public Cards peek()
        {
            if (head == null)
            {
                Console.WriteLine("Stack Is Empty");
                return null;
            }
            else
            {
                return head.Data;
            }
        }



        public Cards peekat(int i)
        {
            Node temp = head;
            int x = this.getLength();
            while (head != null)
            {
                if (x == i)
                {
                    return temp.Data;
                }
                else
                {
                    x--;
                    temp = temp.Next;
                }
            }

            return null;
        }

        public void displayStack()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public bool isEmpty()
        {
            if (head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<Cards> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public string getName()
        {
            return this.name;
        }

        public int getLength()
        {
            return this.length;
        }

        public void clear()
        {
            for(int i = 0; i < length; i++)
            {
                pop();
            }
        }
    }
}
