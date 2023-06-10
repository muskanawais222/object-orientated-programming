using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labTask2Library.BL;

namespace labTask2Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> book_chapters = new List<string>(); // list of chapters
            List<book> Record = new List<book>(); // list of book to add record
            book book1 = new book();
            bool running = true;
            while(running)
            {
                int choice = menu();
                if (choice == 1)
                {
                    Record.Add(book1.InputBookData());

                }
                else if (choice == 2)
                {
                    book1.ViewBookRecords(Record);

                }
                else if (choice == 3)
                {
                    book1.SetNewBookMark(Record);
                }
                else if (choice == 4)
                {
                    book1.FindBookmark(Record);

                }
                else if (choice == 5)
                {
                    book1.SetNewBookPrice(Record);
                }
                else if (choice == 6)
                {
                    Console.Write(book1.FindBookPrice(Record));
                    Console.ReadKey();


                }
                else if (choice == 7)
                {
                    Console.Write(book1.FindChapter(Record));
                    Console.ReadKey();

                }
                else if (choice == 8)
                {
                    running = false;
                    Console.WriteLine("END");
                }

                else
                    Console.WriteLine("Invalid input");
                Console.ReadKey();

            }


        }
        public static int menu()
        {
            Console.Clear();
            Console.WriteLine("1. Enter information for Books");
            Console.WriteLine("2. view book record");
            Console.WriteLine("3. Set Book Mark of book");
            Console.WriteLine("4. Get book mark of book");
            Console.WriteLine("5. Set book price");
            Console.WriteLine("6. Get price of book ");
            Console.WriteLine("7. Get chapters of book");
            Console.WriteLine("8. Exit");
            Console.WriteLine("Enter your option");
            int option = int.Parse(Console.ReadLine());
            return option;

        }
    }
}
