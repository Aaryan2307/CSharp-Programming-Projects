using System;

namespace Queue_App_with_Inhertiance
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue(5);
            q.enQueue("Aaryan");
            Console.WriteLine(q.QueueArray);
        }
    }
    public class Queue
    {
        protected string[] queueArray;
        protected int frontPointer;
        protected int rearPointer;
        protected int size;
        public Queue(int maxSize)
        {
            queueArray = new string[maxSize];
            frontPointer = 0;
            rearPointer = -1;
            size = 0;
        }
        public bool isEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isFull()
        {
            if (size == queueArray.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void enQueue(string item)
        {
            if (isFull() == false)
            {
                rearPointer = (rearPointer + 1) % queueArray.Length;
                queueArray[rearPointer] = item;
                size++;
            }
            else
            {
                Console.WriteLine("Queue is already full");
            }
        }
        public void deQueue()
        {
            if (isEmpty() == false)
            {
                frontPointer = (frontPointer + 1) % queueArray.Length;
                size--;
            }
            else
            {
                Console.WriteLine("Queue is already empty");
            }
        }
        public string[] QueueArray
        {
            get { return queueArray; }
        }
        public class QueueJumper : Queue
        {
            public QueueJumper(int maxSize) : base(maxSize)
            { }
            public void enQueue(string item, bool priority = false)
            {
                if (priority == true)
                {
                    if (isFull() == false)
                    {
                        if (frontPointer == 0)
                        {
                            frontPointer = queueArray.Length - 1;
                            queueArray[frontPointer] = item;
                            size += 1;
                        }
                        else
                        {
                            frontPointer -= 1;
                            queueArray[frontPointer] = item;
                            size += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Queue is already full");
                    }
                }
                else
                {
                    base.enQueue(item);
                }
            }
        }
    }
}
