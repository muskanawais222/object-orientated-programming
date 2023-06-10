using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    class student
    {
        public string studentName;
        public int Age;
        public float fscMarks;
        public float EcatMarks;
        public string NameOfdegree;
        public double merit;
        public List<DegreeProgram> preference;
        public List<Subjects> regSubject;
        public DegreeProgram regDegree;
        public string prefer;
        // default constructor
        public student()
        {

        }
      public student(string name , int age , float fsc,float ecat , List<DegreeProgram> prefer)
        {
            this.studentName = name;
            this.Age = age;
            this.fscMarks = fsc;
            this.EcatMarks = ecat;
           /* this.NameOfdegree = degree;*/
            this.preference = prefer;
            regSubject = new List<Subjects>();

        }
/*        public student (string preference)
        {
            this.prefer = preference;
        }*/
        // calculate merit
        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) + 0.45F) + ((EcatMarks / 400) * 0.55F) * 100);
        }
        // to check registerd student
        public bool regStudentSubject(Subjects s)
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
        //  get credit hour
        public int getCreditHour()
        {
            int count = 0;
            foreach (Subjects sub in regSubject)
            {
                count = count + sub.Credithour;
                    
             }
            return count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if(regDegree != null)
                foreach(Subjects sub in regSubject)
                {
                    fee = fee + sub.SubjectFee;

                }
            return fee;
        }
            
    }

}
