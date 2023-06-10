using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labTask
{
    class Program
    {
        class student
        {
            public string sName;
            public int roll_no;
            public float cgpa;
            public char isHostelide;
            public string department;

        }

        static void Main(string[] args)
        {
            //task1();
            // task2();
            //task3();
            task4();

        }
        static void task1()
        {
            Console.Read();
        }
        static void task2()
        {
            student s1 = new student();
            s1.sName = "Muskan";
            s1.roll_no = 5;
            s1.cgpa = 3.5F;
            Console.WriteLine("Name: " + s1.sName + "  Roll no " + s1.roll_no + "  CGPA " + s1.cgpa);
            Console.ReadLine();
        }
        static void task3()
        {// first object
            student s1 = new student();
            s1.sName = "Muskan";
            s1.roll_no = 5;
            s1.cgpa = 3.5F;
            Console.WriteLine("Name: " + s1.sName + "  Roll no " + s1.roll_no + "  CGPA " + s1.cgpa);
            // second object
            student s2 = new student();
            s2.sName = "Mahi";
            s2.roll_no = 6;
            s2.cgpa = 3.2F;
            Console.WriteLine("Name: " + s2.sName + "  Roll no " + s2.roll_no + "  CGPA " + s2.cgpa);
            Console.Read();

        }
        static void task4()
        {
            student s1 = new student();

            Console.WriteLine("Enter the name ");
            s1.sName = Console.ReadLine();
            Console.WriteLine("Enter the Roll no ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CGPA ");
            s1.cgpa = int.Parse(Console.ReadLine());
            Console.WriteLine("Name: " + s1.sName + "  Roll no " + s1.roll_no + "  CGPA " + s1.cgpa);
            Console.Read();

        }
     
    }
}