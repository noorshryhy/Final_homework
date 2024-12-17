using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_HomeWork
{
    class Node
    {
        public student Data { get; set; }
        public Node Next { get; set; }
        public Node() { }
        public Node(student st)
        { Data = st; }

    }
    class LinkedList
    {
        public Node First { get; set; }
     
        public void Add(Node newstudent)
        {

            if (First == null)
            {
                First =newstudent ;
                return;
            }
            if (First.Data.Finalmark > newstudent.Data.Finalmark)
            {
                newstudent.Next = First;
                First = newstudent;
                return;
            }
            Node move = First;
            while (move != null)
            {
                if (move.Next.Data.Finalmark > newstudent.Data.Finalmark)
                {
                    newstudent.Next = move.Next;
                    move.Next = newstudent;
                    return;
                }
            }
            move.Next = newstudent;
        }
        public void Print()
        { Node move = First;
            while(move!=null)
            {
                Console.WriteLine(+move.Data.Id+"\n"+move.Data.Name+"\n"+ move.Data.Finalmark + "\n"+move.Data.estimate );
                Console.WriteLine("************************");
                move = move.Next;
            }
          
        }

        public void Add(student s)
        {
         
            Add(new Node(s));
        }

        }
    class student
    {
        static int  Idst=1;
        int id ;
        public int Id
        {
            get { return id; }
        }
        public string Name { get; set; }
        public double Exam1 { get; set; }
        public double Exam2 { get; set; }
        double finalmark;
        public double Finalmark { get { return (Exam1 + Exam2) / 2; } }
         public Estimate estimate
        {
            get
            {
                if (finalmark <= 100 && finalmark >= 80) { return Estimate.Exlent; }
                if (finalmark <= 80 && finalmark >= 60) { return Estimate.VeryGood; }
                if (finalmark <= 60 && finalmark >= 40) { return Estimate.Good; }
                if (finalmark <= 40 && finalmark >= 0) { return Estimate.Fail; }
                else throw new Exception("The mark is not Correct"); 
            }
        }
        
        public student()
         {
            id =Idst++;
            Console.WriteLine("Enter Name student");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Exam1 student");
            Exam1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Exam2 student");
            Exam2 = Convert.ToInt32(Console.ReadLine());

        }
        public enum Estimate
        {
           Exlent,
           VeryGood,
           Good,
           Fail,
        }
    }
    class Program
    { 
        static void Main(string[] args)
        {
            LinkedList sts = new LinkedList();
            int  ch;
            do
            {
                Console.WriteLine( "1: Add stud.\n" +"2: Print list\n" +"3: exit.");

                ch = int.Parse(Console.ReadLine());

                if(ch==1)
                {
                    student n = new student();
                    sts.Add(n);
                }
                if(ch==2)
                {
                    sts.Print();
                }

            } while (ch!=3);
          
        }
    }
}
