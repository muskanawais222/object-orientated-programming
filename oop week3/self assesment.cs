using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week3SelfAssesment.BL;
using System.Threading;

namespace week3SelfAssesment
{
    class Program
    {
        static void Main(string[] args)
        {
            // task1a();
            //task1b();
            // task2a();
            // task2b();
            //taskClockType();
            clock2();
        }

        // task 1 a sef assesment
        static void task1a()
        {
            student s1 = new student();
            Console.WriteLine("Name is " + s1.sName);
            Console.WriteLine("Fsc marks are " + s1.fscMarks);
            Console.WriteLine("matric marks are " + s1.matricMarks);
            Console.WriteLine("ecat marks are " + s1.ecatMarks);
            Console.WriteLine("aggregate is " + s1.aggregate);
            Console.Read();

        }
        // task 1 b sef assesment
        static void task1b()
        {
            student s2 = new student();
            Console.WriteLine("Name is " + s2.sName);
            Console.WriteLine("Fsc marks are " + s2.fscMarks);
            Console.WriteLine("matric marks are " + s2.matricMarks);
            Console.WriteLine("ecat marks are " + s2.ecatMarks);
            Console.WriteLine("aggregate is " + s2.aggregate);

            Console.WriteLine();
            student s3 = new student();
            Console.WriteLine("Name is " + s3.sName);
            Console.WriteLine("Fsc marks are " + s3.fscMarks);
            Console.WriteLine("matric marks are " + s3.matricMarks);
            Console.WriteLine("ecat marks are " + s3.ecatMarks);
            Console.WriteLine("aggregate is " + s3.aggregate);
            Console.Read();


        }
        // task 2 a parameterized constructor
        static void task2a()
        {
            student s1 = new student("muskan", 10.5F, 23.3F, 34.5F, 8.6F);
            Console.WriteLine("Name is " + s1.sName);
            Console.WriteLine("Fsc marks are " + s1.fscMarks);
            Console.WriteLine("matric marks are " + s1.matricMarks);
            Console.WriteLine("ecat marks are " + s1.ecatMarks);
            Console.WriteLine("aggregate is " + s1.aggregate);
            Console.Read();

        }
        // task2 b parameterized constructors
        static void task2b()
        {
            student s1 = new student("muskan", 10.5F, 23.3F, 34.5F, 8.6F);
            Console.WriteLine("Name is " + s1.sName);
            Console.WriteLine("Fsc marks are " + s1.fscMarks);
            Console.WriteLine("matric marks are " + s1.matricMarks);
            Console.WriteLine("ecat marks are " + s1.ecatMarks);
            Console.WriteLine("aggregate is " + s1.aggregate);

            Console.WriteLine();
            student s2 = new student("mahi", 16.5F, 25.3F, 33.5F, 9.6F);
            Console.WriteLine("Name is " + s2.sName);
            Console.WriteLine("Fsc marks are " + s2.fscMarks);
            Console.WriteLine("matric marks are " + s2.matricMarks);
            Console.WriteLine("ecat marks are " + s2.ecatMarks);
            Console.WriteLine("aggregate is " + s2.aggregate);
            Console.Read();

        }
        //**************************************************//
        // class clock type
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
            clockType full_time = new clockType(5, 10, 10);
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
        }


        /////////////////////// task clock time //////////////////////
        static void clock2()
        {
            // parameterized constructor with 3 parameter  
            clockType time = new clockType();
            Console.WriteLine("Enter time in hours: ");
            time.hours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in minutes: ");
            time.minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in seconds: ");
            time.seconds = int.Parse(Console.ReadLine());



            // elapsed time
            int seconds = time.elapsed_Time(time);
            Console.WriteLine("Elapsed time is : " + seconds + " seconds");

            //remaing time
            int remain = time.remaining_time(time);
            Console.WriteLine("reaming time is : " + remain + " seconds");

            // check far apart of two clocks // time difference
            int hr, min, sec;
            Console.WriteLine("Enter new time in hours: ");
            hr = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in minutes: ");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new time in seconds: ");
            sec = int.Parse(Console.ReadLine());
            time.time_difference(hr, min, sec, time);



            // show time in minutes , hours and seconds///////////////////
            Console.WriteLine("Reaming time in form of hours min sec: ");
            time.displayTime(time);
            Console.Read();
        }
     }
}
