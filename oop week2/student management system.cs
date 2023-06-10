using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem;

namespace StudentManagementSystem
{
    class Program
    {
        class students
        {
            public string sName;
            public int roll_no;
            public float cgpa;
            public char isHostelide;
            public string department;

        }
        static void Main(string[] args)
        {
            students[] s = new students[10]; // students array
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count = count+1;
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }


            }
            while (option != '4');
            {
                Console.WriteLine("Press enter to exit..");
                Console.Read();

            }
        }
        // menu
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for ADDING a student: ");
            Console.WriteLine("Press2 for VIEW  student: ");
            Console.WriteLine("Press3 for Top three  student: ");
            Console.WriteLine("Press4 for to exit ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        // add students
        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine("Enter the name ");
            s1.sName = Console.ReadLine();
            Console.WriteLine("Enter the Roll no ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the CGPA ");
            s1.cgpa = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the DEPARTMENT ");
            s1.department = Console.ReadLine();
            Console.WriteLine("IS hostelide (y||N): ");
            s1.isHostelide = char.Parse(Console.ReadLine());
            return s1;

        }
        // view students
        static void viewStudent(students[] s, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name:  {0} Roll No : {1} CGPA: {2} Department: {3} IHostelide : {4} ", s[i].sName, s[i].roll_no, s[i].cgpa, s[i].department, s[i].isHostelide);
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        // to see the top students
        static void topStudent(students[] s , int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("no record presents");
            }
            else if (count == 1)
            {
                viewStudent(s, 1);
            }
            else if (count == 2)
            {
                for (int x = 0; x < 2; x++)
                {

                    int index = largest(s, x ,count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 3);
            }
        }
        // largest
        static int largest(students[] s, int start , int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for(int x = start; x < end; x++)
            {
                if(large< s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }

    }
}
