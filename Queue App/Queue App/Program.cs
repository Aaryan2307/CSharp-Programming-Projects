using System;

namespace Queue_App
{
    class Program
    {
        static void Main(string[] args)
        {
             Queue myQueue = new Queue();
            string[] q1 = myQueue.queueArray;
            mainMenu(myQueue, q1);
        }
        static void mainMenu(Queue myQueue, string[] q1)
        {
            Console.WriteLine("Please choose an option below:\n1: Add Patients\n2: Remove Patients\n3: Display Current Queue\n4: Exit Program");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                   q1 = addPatients(myQueue, q1);
                    break;
                case "2":
                    q1 = removePatients(myQueue, q1);
                    break;
                case "3":
                    Console.ReadLine();
                    if (myQueue.isEmpty() == true)
                    {
                        Console.WriteLine("The queue is currently empty");
                    }
                    else
                    {
                        int count = myQueue.frontPointer;
                        do
                        {
                            Console.WriteLine(q1[count]);
                            count = (count + 1) % 5;
                        } while (count != (myQueue.rearPointer));
                        Console.WriteLine(q1[count]);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    mainMenu(myQueue, q1);
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the program");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        
        }
        static string[] addPatients(Queue myQueue, string[] q1)
        {
            int noOfPatients;
            if (myQueue.isFull() != true)
            {
                Console.Write("Please enter the amount of patients to send to the waiting room: ");
                string patientString = Console.ReadLine();
                int.TryParse(patientString, out noOfPatients);
                while (((noOfPatients > 5) || ((noOfPatients + myQueue.size) > 5)) || (int.TryParse(patientString, out noOfPatients)) != true)
                {
                    Console.WriteLine("Please enter the amount of patients to send to the waiting room. It can fit a maximum of 5. Current amount is {0}", myQueue.size);
                    patientString = Console.ReadLine();
                    int.TryParse(patientString, out noOfPatients);
                }
                for (int i = 0; i < noOfPatients; i++)
                {
                    Console.Write("Please enter a patient to send to the waiting room: ");
                    string patient = Console.ReadLine();
                    myQueue.enQueue(patient);
                }
                Console.WriteLine("You have entered the inputted amount of patients. You will now be returned to the main menu");
            }
            else
            {
               Console.WriteLine("The queue is now full, please come back another time to add more patients");
            }           
            Console.ReadLine();
            Console.Clear();
            mainMenu(myQueue, q1);
            return q1;
        }
        static string[] removePatients(Queue myQueue, string[] q1)
        {
            int noOfPatients;
            Console.Write("Please enter the amount of patients to be taken to the doctor now: ");
            int.TryParse(Console.ReadLine(), out noOfPatients);
            for (int i = 0; i < noOfPatients; i++)
            {
                myQueue.deQueue();
            }
            Console.WriteLine("The patients have been removed from the waiting room. You will now be returned to the main menu");
            Console.ReadLine();
            Console.Clear();
            mainMenu(myQueue, q1);
            return q1;
        }
    }
    class Queue
    {
      public string[] queueArray = new string[5];
      public int frontPointer = 0;
      public int rearPointer = -1;
      public int size = 0;
        public Queue()
        {

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
    }
}