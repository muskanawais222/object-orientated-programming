using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.DL;
using Uams_lab6.BL;
namespace Uams_lab6.UI
{
    class studentUI
    {

        public static void printStudent()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.NameOfdegree + " got admission in " + s.regDegree);

                }
                else
                {
                    Console.WriteLine(s.studentName + "Did not get admission");
                }
            }
        }

       public static void viewStudentInDegree(string degreeName)
        {
            Console.WriteLine("Name \t FSC \t Ecat \t age");
            foreach (Student s in StudentDL.studentList)

            {
                if (s.regDegree != null)
                {
                    if (degreeName == s.NameOfdegree)
                    {
                        Console.WriteLine(s.studentName + "\t" + s.fscMarks + "\t" + s.EcatMarks + "\t" + s.Age);
                    }
                }
            }
            Console.Read();
        }
       public static void viewRegisteredStudent()
        {
            Console.WriteLine("Name \t FSC \t Ecat \t age");
            foreach (Student s in StudentDL.studentList)

            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.studentName + "\t" + s.fscMarks + "\t" + s.EcatMarks + "\t" + s.Age);

                }

            }
        }

        public static Student takeInputForStudent()
        {
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            /*Console.Clear();*/
            Console.Write("Enter the name of student ");
            string name = Console.ReadLine();
            Console.Write("Enter the age of student ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Fsc Marks of student ");
            double fsc = double.Parse(Console.ReadLine());
            Console.Write("Enter Ecat marks");
            double ecat = double.Parse(Console.ReadLine());
            Console.Write("Available degree program :");
            DegreeprogramUI.viewDegreeProgram();
            Console.Write("Enter how many preference to enter ");
            int count = int.Parse(Console.ReadLine());
            for (int a = 0; a < count; a++)
            {
                Console.WriteLine(" Enter DegreeName ");
                string degreeName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in DegreeProgramDL.programList)
                {
                    if (name == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid degree program");
                    count--;
                }
            }
            Student user = new Student(name, age, fsc, ecat, preferences); // parameterized constructor
            return user;
        }
        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.studentList)

            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.studentName + "has " + s.calculateFee() + "fees");
                }
            }
        }
    }
}
