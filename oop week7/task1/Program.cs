using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //  task1();
            task2();
           
        }
        static void task1()
        {
            DayScholar std = new DayScholar();
            std.Name = "Ahmad";
            std.busNo = 1;
            Console.WriteLine(std.Name + " is Allocated at Bus " + std.busNo);
            Console.ReadKey();
        }
        static void task2()
        {
            hostelite std = new hostelite();
            std.Name = "ahmad";
            std.roomNumber = 12;
            Console.WriteLine(std.Name + " Is Allocated at Room " + std.roomNumber);
            Console.ReadKey();

        }
    }
}
