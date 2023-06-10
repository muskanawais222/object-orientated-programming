using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uams_lab6.BL
{
    class Student
    {
        public string studentName;
        public int Age;
        public double fscMarks;
        public double EcatMarks;
        public string NameOfdegree;
        public double merit;
        public List<DegreeProgram> preference;
        public List<subject> regSubject;
        public DegreeProgram regDegree;
        // parameterized constructor
        public Student(string name, int age, double fsc, double ecat, List<DegreeProgram> prefer)
        {
            this.studentName = name;
            this.Age = age;
            this.fscMarks = fsc;
            this.EcatMarks = ecat;
            this.preference = prefer;
            regSubject = new List<subject>();

        }
        // merit calculate
        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) + 0.45F) + ((EcatMarks / 400) * 0.55F) * 100);
        }
        // to check registerd student
        public bool regStudentSubject(subject s)
        {
            int stuCH = getCreditHour();
            if (regDegree != null && regDegree.isSubjectExists(s) && stuCH + s.Credithour <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
                return false;
        }
        public int getCreditHour()
        {
            int count = 0;
            foreach (subject sub in regSubject)
            {
                count = count + sub.Credithour;

            }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
                foreach (subject sub in regSubject)
                {
                    fee = fee + sub.SubjectFee;

                }
            return fee;
        }
    }
}
