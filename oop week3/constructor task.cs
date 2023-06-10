using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using constructorsTasks.BL;

namespace constructorsTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // task1();
            //task2();
            // task3();
            // task5();
            // task6();
            task7();
        }
        // task1
        public static void task1()
        {
            student s1 = new student();
            Console.WriteLine(s1.sName);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();

        }
        // task2
        public static void task2()
        {
            student s = new student();
            Console.Read();
        }
        //task3
        public static void task3()
        {
            student s2 = new student();
            Console.WriteLine(s2.sName);
            Console.Read();
        }

        // task5 copy constructor
        public static void task5()
        {
            student s1 = new student();
            s1.sName = "Jack";
            student s2 = new student(s1);
            Console.WriteLine(s1.sName);
            Console.WriteLine(s2.sName);
            Console.Read();
        }

        ///////// FOR EACH LOOP ???
        ///concept of for loop
        static void task6()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for(int x = 0; x< numbers.Count(); x++)
            {
                Console.WriteLine(numbers[x]);
            }
            Console.Read();
        }
        static void task7()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }

    }
  
}
