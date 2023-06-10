using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1UniversityRecord;

namespace task1UniversityRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            List<student> record = new List<student>();



        }
        static student AddStudent()
        {
            student data= new student();
            Console.WriteLine("Enter name of student");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter roll no of student");
            int rollno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Cgpa of student ");
            float cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Matric Marks ");
            int marks1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fsc marks ");
            int fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Home town of student");
            string home = Console.ReadLine();
            Console.WriteLine("Enter is student hostelide ");
            bool hostelite = bool.Parse(Console.ReadLine());
            Console.WriteLine("Enter is student avail scholarship or not ");
            bool scholar = bool.Parse(Console.ReadLine());



            return data;
        }
    }
}
