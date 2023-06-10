using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1UniversityRecord.BL;

namespace task1UniversityRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            List<student> students = new List<student>();
            student s = new student();
            int choice;
            do
            {
                choice = menu();

                if (choice == 1)
                {
                    student objStudent = takeInformation();
                    students.Add(objStudent);
                }
                if(choice == 2)
                {
                    viewStudentDetail(students);

                }

            }
            while (choice != 3);
            Console.ReadKey();
        }
        public static int menu()
        {
            Console.Clear();

            int option;
            Console.WriteLine("1. Add Information");
            Console.WriteLine("2. Check ScholarShip");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your option ");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        public static student takeInformation()
        {
            Console.Clear();

            student s1 = new student();
            Console.WriteLine("Enter your name:");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Enter your Roll No:");
            s1.RollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your cgpa");
            s1.CGPA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter your fscmarks");
           s1.FscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your ecat marks");
            s1.ecat = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your matricmarks");
            s1.MatricMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your home town name");
            s1.HomeTown = Console.ReadLine();
            Console.WriteLine("Enter Is You Are hostelide , True/False");
            s1.isHostelite = bool.Parse(Console.ReadLine());

            return s1;
        }
        static void viewStudentDetail(List<student> students)
        {
            Console.Clear();

            int x = 0;
            {
                foreach(student storedUser in students)
                {
                    Console.Clear();
                    Console.WriteLine("student stored in list at no" + x++);
                    Console.WriteLine();
                    Console.WriteLine("Student name is " + storedUser.Name);
                    Console.WriteLine("student fsc marks are " + storedUser.FscMarks);
                    Console.WriteLine("Student Matric marks are " + storedUser.MatricMarks);
                    Console.WriteLine("Student ecat Marks are " + storedUser.ecat);
                    Console.WriteLine("Student CGPA is " + storedUser.CGPA);
                    Console.WriteLine("Student Home toen is " + storedUser.HomeTown);
                    Console.WriteLine("Student is hostelite or not {0}" ,storedUser.isHostelite);
                    Console.WriteLine("Student is avail scholarship or not " + storedUser.IsAvailScholarShip);
                    Console.ReadKey();
                }
            }
        }
    }
}
