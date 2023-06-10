using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.UL
{
    class UserInterFace
    {
        public static string menu()
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
           string option = Console.ReadLine();
            return option;

        }
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }

}
