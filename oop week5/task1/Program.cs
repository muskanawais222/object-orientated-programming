using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;
using task1.UL;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<student> data = new List<student>();
            List<DegreeProgram> programs = new List<DegreeProgram>();
            List<Subjects> subject = new List<Subjects>();

            bool running = true;
            while (running)
            {
                Console.Clear();
                string option = UserInterFace.menu(); // menu is placed in userInterface
                if (option == "1")
                {
                    DegreeProgram d = takeInputForDegree();
                    addIntoDegreeList(d, programs);
                   
                }
                else if (option == "2")
                {
                    if (programs.Count > 0)
                    {
                        student s = takeInputForStudent(programs);
                        addStudentIntoList(s, data);
                    }
                }
                else if (option == "3")
                {
                    List<student> sortedStudentList = new List<student>();
                    sortedStudentList = sort_student_by_merit(data);
                }
                else if (option == "4")
                {
                    viewRegisteredStudent(data);
                    Console.ReadKey();
                }
                else if (option == "5")
                {
                    Console.WriteLine("Enter degree name");
                    string degreeName = Console.ReadLine();
                    viewStudentInDegree(degreeName, data);
                }
                else if (option == "6")
                {
                    Console.Write("Enter the student name:");
                    string name = Console.ReadLine();
                    student s = studentPresent(name, data);
                        {
                        if(s!= null)
                        {
                            viewSubject(s);
                            registerSubjects(s);
                        }
                    }
                }
                else if(option =="7")
                {
                    calculateFee(data);
                }



                else if (option == "8")
                {
                    running = exit(running);

                }
                else
                    invalid();

            }

            Console.ReadKey();



        }
        // add student
        static student takeInputForStudent(List<DegreeProgram> addPref)
        {
            List<DegreeProgram> addPreference = new List<DegreeProgram>();
            /*Console.Clear();*/
            Console.Write("Enter the name of student ");
            string name = Console.ReadLine();
            Console.Write("Enter the age of student ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Fsc Marks of student ");
            float fsc = float.Parse(Console.ReadLine());
            Console.Write("Enter Ecat marks");
            float ecat = float.Parse(Console.ReadLine());
            Console.Write("available degree program :");
            viewDegreeProgram(addPref);
            Console.Write("Enter how many preference to enter ");
                int x = int.Parse(Console.ReadLine());
            for (int a = 0; a < x; a++)
            {
                Console.WriteLine(" Enter Preference ");
                string program = Console.ReadLine();
                /*student Prefer = new student(program);*/
                bool flag = false;
                foreach (DegreeProgram dp in addPref)
                {
                    if (name == dp.title && !(addPreference.Contains(dp)))
                    {
                        addPreference.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter valid degree program");
                    x--;
                }
            }
            student user = new student(name, age, fsc, ecat, addPreference); // parameterized constructor
            return user;
            Console.ReadKey();
        }

        static void viewDegreeProgram(List<DegreeProgram> programList)
        {
            foreach(DegreeProgram dp in programList)
            {
                Console.WriteLine(dp.title); // title is degree name
            }
            Console.ReadKey();

        }
       
     

       
     
        //.......................................................................//
        // view list of student
        static void viewStudent(List<student> student)
        {
            Console.WriteLine("Name               Age          Ecat            FSC   ");

            foreach (student data in student)
            {
                Console.WriteLine(data.studentName + "    ,       " + data.Age + "    ,       " + data.EcatMarks + "    ,         " + data.fscMarks);
            }
            Console.ReadKey();
        }

        static void invalid()         
        {
            Console.WriteLine("Your choice is invalid");
            Console.WriteLine("Plese enter valid option");

        }
        static bool exit(bool run)
        {
            Console.WriteLine("You exit the prOgram");
            Console.WriteLine("Thanks for using");
            run = false;
            return run;

        }
        ///................................/////
        ///to check student present 
        static student studentPresent(string name, List<student> data)
        {
            foreach (student stu in data)
            {
                if (name == stu.studentName && stu.regDegree != null)
                {
                    return stu;
                }
            }
            return null;
        }
        static void calculateFee(List<student> data)
        {
            foreach (student s in data)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.studentName + "has " + s.calculateFee() + "fees");
                }
            }
        }

        //. re.............registered student
        static void registerSubjects(student s)
        {
            Console.WriteLine("Enter how many student you want to register");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter subject code");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (Subjects sub in s.regDegree.subjects)
                {
                    if (code == sub.Code && !(s.regSubject.Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter invalid course");
                    x--;
                }

            }
        }

        static List<student> sort_student_by_merit(List<student> data)
        {
            List<student> sortedStudentList = new List<student>();
            foreach (student s in data)
            {
                s.calculateMerit();
            }
            sortedStudentList = data.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }

        // giving addmision 
        static void givingAdmission(List<student> sortedstudent)
        {
            foreach (student stu in sortedstudent)
            {
                foreach (DegreeProgram deg in stu.preference)
                {
                    if (deg.seats > 0 && stu.regDegree == null)
                    {
                        stu.regDegree = deg;
                        deg.seats--;
                        break;
                    }
                }

            }
        }
        // print student
        static void printStudent(List<student> print)
        {
            foreach (student s in print)
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

        static void viewStudentInDegree(string degreeName, List<student> studentList)
        {
            Console.WriteLine("Name \t FSC \t Ecat \t age");
            foreach (student s in studentList)
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
        static void viewRegisteredStudent(List<student> studentList)
        {
            Console.WriteLine("Name \t FSC \t Ecat \t age");
            foreach (student s in studentList)
            {
                if (s.regDegree != null)
                { 
                    Console.WriteLine(s.studentName + "\t" + s.fscMarks + "\t" + s.EcatMarks + "\t" + s.Age);

                }

            }

        }

        static void addIntoDegreeList(DegreeProgram d,List<DegreeProgram> programs)
        {
            programs.Add(d);
        }
        static DegreeProgram takeInputForDegree()
        {
                Console.Write("Enter Degree's Name : ");
                string Name = Console.ReadLine();
                Console.Write("Enter Degree's Duration : ");
                int Duration = int.Parse(Console.ReadLine());
                Console.Write("Enter Available Seats For " + Name + " : ");
                int Seats = int.Parse(Console.ReadLine());
                DegreeProgram DegreeRecord = new DegreeProgram(Name, Duration, Seats);
            Console.Write("Enter how many subjects to enter: ");
            int subjects = int.Parse(Console.ReadLine());
            List<Subjects> subList = new List<Subjects>(); 
            for(int x = 0; x < subjects; x++)
            {
                DegreeRecord.addSubject(takeInputForSubject());
            }

                return DegreeRecord;
        }

        static Subjects takeInputForSubject( )
        {
           
                Console.Write("Enter Subject's Name : ");
                string SubjectCode = Console.ReadLine();
                Console.Write("Enter Subject's Type : ");
                string SubjectType = Console.ReadLine();
                Console.Write("Enter Subject's Credit Hours : ");
                int CreditHours = int.Parse(Console.ReadLine());
                Console.Write("Enter Subject's Fees : ");
                int SubjectFees = int.Parse(Console.ReadLine());
                Subjects SubjectRecord = new Subjects(SubjectCode, SubjectType, CreditHours, SubjectFees);
                return SubjectRecord;
        }
        static void addStudentIntoList(student s , List<student> stuList)
        {
            stuList.Add(s);
        }
        // view subject
        static void viewSubject(student s)
        {
            if(s.regDegree != null)
            {
                Console.WriteLine("subcode \t subtype");
                foreach(Subjects sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.Code + "\t \t" + sub.SubjectType);
                }
            }
        }


    }
}
