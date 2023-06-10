using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.DL;
using Uams_lab6.UI;
using Uams_lab6.BL;

namespace Uams_lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            if(SubjectDL.readFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data loaded sucessfully.");
            }
            if(DegreeProgramDL.readFromFile(degreePath))
            {
                Console.WriteLine("Segree Data loaded sucessfully.");
            }
            if(StudentDL.readFromFile(studentPath))
            {
                Console.WriteLine("Student Data loaded sucessfully.");
            }
            int option;
            do
            {
                option = MenuUI.menu();
                MenuUI.clearScreen();
                if (option == 1)
                {
                    DegreeProgram d = DegreeprogramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                    DegreeProgramDL.storeIntoFile(degreePath, d);

                }
                else if (option == 2)
                {
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = studentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                        StudentDL.storeIntoFile(studentPath, s);
                    }
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sort_student_by_merit();
                    StudentDL.givingAdmission(sortedStudentList);
                    studentUI.printStudent();
                }
                else if (option == 4)
                {
                    studentUI.viewRegisteredStudent();
                }
                else if (option == 5)
                {
                    Console.WriteLine("Enter degree name ");
                    string degreeName = Console.ReadLine();
                    studentUI.viewStudentInDegree(degreeName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the name of student : ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.studentPresent(name);
                    if (s != null)
                    {
                        SubjectUI.viewSubject(s);
                        SubjectUI.registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    studentUI.calculateFeeForAll();
                }
                MenuUI.clearScreen();

            }
            while (option != 8);
        }
    }
}
