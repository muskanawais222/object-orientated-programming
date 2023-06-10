using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    class DegreeProgram
    {
        public string title;
        public int duration;
        public int seats;
        public List<Subjects> subjects;

        // parameterized constructor
        public DegreeProgram(string name , int duration ,int seats )
        {
            this.title = name;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<Subjects>();
        }
        public DegreeProgram()
        {

        }
         // member function  for adding is subject exists and adding subjects and calculate credthour
         public int calculateCreditHour()
        {
            int count = 0;
            for(int x=0;x< subjects.Count; x++) // where subjects is list of subject
            {
                count = count + subjects[x].Credithour;
            }
            return count;
        }

        // check subject exists or not
        public bool addSubject(Subjects s) // passing an object 
        {
            int creditHour = calculateCreditHour();
            if (creditHour + s.Credithour <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
                return false;
        }

        // to check is subject exists
        public bool isSubjectExists(Subjects s)
        {
            foreach(Subjects sub in subjects) // sub is var .... subjects is list ... Capital S is class
            {
                if(sub.Code == s.Code)
                {
                    return true;
                }
            }
            return false;
        }



    }
}
