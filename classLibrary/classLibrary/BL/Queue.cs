using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace classLibrary.BL
{
    public class Queue
    {
        private Node rear;
        private Node front;
        private int length;
        public Queue()
        {
            this.rear = null;
            this.front = null;
            this.length = 0;
        }

        public void enqueue(Cards data)
        {
            Node newNode = new Node(data);
            if(rear == null)
            {
                front = rear = newNode;
                this.length++;
                return;
            }
            rear.Next = newNode;
            rear = newNode;
            this.length++;
        }

        public Cards dequeue()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty");
                return null;
            }
            Cards card = front.Data;
            front = front.Next;
            if(front == null)
            {
                rear = null;
            }
            length--;
            return card;

        }

        public bool isEmpty()
        {
            if(front == null)
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
            Node current = front;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public int getLength()
        {
            return this.length;
        }

        public Cards peekend()
        {
            return rear.Data;
        }

        public Cards peekfront()
        {
            return front.Data;
        }

    }
}
