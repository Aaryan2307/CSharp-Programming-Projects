using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List_App
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.append("Aaryan");
            list.push("Purohit");
            list.push("B");
            Console.WriteLine(list.pop());
            Console.WriteLine(list.pop());
            Console.WriteLine(list.pop());
            Console.ReadLine();
        }
    }
   class Node
   {
       public string item;
       public Node next;
       public Node(string s)
       {
           item = s;
           next = null;
       }
   }
   class LinkedList
   {
       private Node head;
       public LinkedList()
       {
           head = null;
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
       public bool isFull()
       {
           return false;
       }
       public void append(string item)
       {
           if (isEmpty() == true)
           {
               head = new Node(item);
           }
           else
           {
               Node p = head;
               while (p.next != null)
               {
                   p = p.next;
               }
               p.next = new Node(item);
           }
       }
       public int length()
       {
           Node p = head;
           if (p == null)
           {
               return 0;
           }
           else
           {
               int count = 1;
               while (p.next != null)
               {
                   p = p.next;
                   count++;
               }
               return count;
           }
       }
       public string pop()
       {
           if (isEmpty() == true)
           {
               Console.WriteLine("Error - List is empty");
               return ("0");
           }
           else
           {
               string popItem = head.item;
               head = head.next;
               return popItem;
           }
       }
       public void push(string item)
       {
           Node p = head;
           head = new Node(item);
           head.next = p;
       }
   }
}
