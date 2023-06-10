using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uams_lab6.BL
{
    class DegreeProgram
    {
        public string degreeName;
        public float duration;
        public int seats;
        public List<subject> subjects;

        // parameterized constructor
        public DegreeProgram(string name, float duration, int seats)
        {
            this.degreeName = name;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<subject>();
        }

        // member function in degree program

        // check subject exists or not
        public bool addSubject(subject s) // passing an object 
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
        public int calculateCreditHour()
        {
            int count = 0;
            for (int x = 0; x < subjects.Count; x++) // where subjects is list of subject
            {
                count = count + subjects[x].Credithour;
            }
            return count;
        }

        // to check is subject exists
        public bool isSubjectExists(subject s)
        {
            foreach (subject sub in subjects) // sub is var .... subjects is list ... Capital S is class
            {
                if (sub.Code == s.Code)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
