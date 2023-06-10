using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3SelfTasks.BD;

namespace week3SelfTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //  taskClockType();
            task1();

        }
        static void taskClockType()
        {
            // default constructor
            clockType empty_time = new clockType();
            Console.WriteLine("Empty time: ");
            empty_time.printTime();

            // parameterized constructor with one parameter
            clockType hour_time = new clockType(5);
            Console.WriteLine("hour time: ");
            hour_time.printTime();

            // parameterized constructor with two parameter
            clockType minutes_time = new clockType(5, 10);
            Console.WriteLine("Minutes time: ");
            minutes_time.printTime();

            // parameterized constructor with three parameter
            clockType full_time = new clockType(5, 10, 10); /////// full time constructor
            Console.WriteLine("full time: ");
            full_time.printTime();

            //////////FOR INCREMENT TIME //////////
            /// increment second
            full_time.incrementSecond();
            Console.Write("Full time (increment second): ");
            full_time.printTime();

            /// increment hours
            full_time.incrementHours();
            Console.Write("Full time (increment hours): ");
            full_time.printTime();

            /// increment second
            full_time.incrementMinutes();
            Console.Write("Full time (increment minutes): ");
            full_time.printTime();

            // call functions with timing 
            // call function with manual timing 
            bool flag = full_time.isEqual(6, 11, 11);
            Console.WriteLine("Flag is " + flag);

            //call function with object timing
            clockType obj = new clockType(10, 12, 1);
            flag = full_time.isEqual(obj);
            Console.WriteLine(" object Flag is " + flag);

            // elapsed time
            Console.WriteLine();
            Console.WriteLine("Elapsed time in seconds : ");
            full_time.elapsedTime();

            // remaining time
            Console.WriteLine();
            full_time.remaining_time();

            // check far apart of two clocks // time difference
            int hr, min, sec;
            Console.WriteLine();
            Console.WriteLine("Enter new time in hours: ");
            hr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in minutes: ");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in seconds: ");
            sec = int.Parse(Console.ReadLine());
            full_time.time_difference(hr, min, sec);
            Console.ReadLine();

        }
        static void task1()
        {

            student s1 = new student();
            Console.WriteLine(s1.Sname);
            Console.WriteLine(s1.MMarks);
            Console.WriteLine(s1.FSCmarks);
            Console.WriteLine(s1.EcatMarks);
            Console.WriteLine(s1.aggregate);

            Console.Read();
        }

    }
}
