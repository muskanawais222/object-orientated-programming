using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uams_lab6.UI
{
    class MenuUI
    {
        public static int menu()
        {
            Console.WriteLine("1. Add degree program.");
            Console.WriteLine("2. Add student.");
            Console.WriteLine("3. Generate merit");
            Console.WriteLine("4. view registered student");
            Console.WriteLine("5. view student of specific program");
            Console.WriteLine("6.Register subjects for specific program");
            Console.WriteLine("7. Calculate fees for all student");
            Console.WriteLine("8. Exit");
            Console.Write("Enter option");
            int option = int.Parse(Console.ReadLine());
            return option;

        }
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void header()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("          UAMS              ");
            Console.WriteLine("***************************");

        }
    }
}
