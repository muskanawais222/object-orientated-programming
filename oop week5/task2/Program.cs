using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selfTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            // sortingString();
            //sortingInteger();
            // sortingClass();
            sortingClassinDescending();
        }
        static void sortingString()
        {
            List<string> stringList = new List<string>();
            Console.WriteLine("Enter string ");
            for (int i = 0; i < 5; i++)
            {
                string no = (Console.ReadLine());
                stringList.Add(no);
            }
            // sorting
            stringList.Sort();
            foreach (string i in stringList)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();

        }
        // integerList
        static void sortingInteger()
        {
            List<int> intList = new List<int>() { 6, 7, 4, 3, 9, 1 };
            intList.Sort();
            foreach(int i in intList)
            {
                Console.WriteLine(" " + i);
                Console.ReadKey();
            }
        }
         // sorting list of class in ascending order
         static void sortingClass()
        {
            List<student> sortingAscending = new List<student>();
            for(int i = 0; i<3; i++)
            {
                student sort = new student();
                Console.Write("Enter name ");
                sort.Name = Console.ReadLine();
                Console.Write("Enter age ");
                sort.Age = int.Parse(Console.ReadLine());
                Console.Write("enter ecat marks");
                sort.EcatMarks = int.Parse(Console.ReadLine());
                Console.Write("enter roll no");
                sort.RollNo = int.Parse(Console.ReadLine());
                sortingAscending.Add(sort);
            }
            // syntax for sorting
            List<student> sortedList = sortingAscending.OrderBy(o => o.RollNo).ToList();
            Console.WriteLine(" name \t Roll no \t ecatmarks \t age ");
            foreach(student var in sortedList)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} ", var.Name, var.RollNo, var.EcatMarks, var.Age);
            }
            Console.Read();
        }

        // in descending order

        static void sortingClassinDescending()
        {
            List<student> sortingDescending= new List<student>();
            for (int i = 0; i < 3; i++)
            {
                student sort = new student();
                Console.Write("Enter name ");
                sort.Name = Console.ReadLine();
                Console.Write("Enter age ");
                sort.Age = int.Parse(Console.ReadLine());
                Console.Write("enter ecat marks");
                sort.EcatMarks = int.Parse(Console.ReadLine());
                Console.Write("enter roll no");
                sort.RollNo = int.Parse(Console.ReadLine());
                sortingDescending.Add(sort);
            }
            // syntax for sorting
            List<student> sortedList = sortingDescending.OrderByDescending(o => o.RollNo).ToList();
            Console.WriteLine(" name \t Roll no \t ecatmarks \t age ");
            foreach (student var in sortedList)
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3} ", var.Name, var.RollNo, var.EcatMarks, var.Age);
            }
            Console.Read();
        }
    }
}