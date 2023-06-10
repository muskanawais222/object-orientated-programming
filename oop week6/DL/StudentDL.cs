using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.BL;
using System.IO;

namespace Uams_lab6.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        // function add int student list
        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
        // sort student by merit
       public static List<Student> sort_student_by_merit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach (Student s in studentList)
            {
                s.calculateMerit();
            }
            sortedStudentList = studentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentList;
        }

        // giving addmision 
      public  static void givingAdmission(List<Student> sortedstudent)
        {
            foreach (Student stu in sortedstudent)
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
        public static Student studentPresent(string name)
        {
            foreach(Student s in studentList)
            {
                if(name == s.studentName && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
         // store into file
         public static void storeIntoFile(string path , Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeName = "";
            for(int x = 0; x< s.preference.Count-1; x++)
            {
                degreeName = degreeName + s.preference[x].degreeName + ";";
            }
            f.WriteLine(s.studentName + "," + s.Age + "," + s.fscMarks  + "," + s.EcatMarks + "," +degreeName);
            f.Flush();
            f.Close();
        }
        // read from file
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {

                    string[] splittedRecord = record.Split(','); // array
                    string Name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();
                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d))) ;
                            preferences.Add(d);
                        }
                    }
                    Student s = new Student(Name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
                return false;
        }
    }
}
