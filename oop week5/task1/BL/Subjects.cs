using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1.BL
{
    class Subjects
    {
        public string Code;
        public int Credithour;
        public string SubjectType;
        public int SubjectFee;
        // parameterized constructor
        public Subjects(string code, int credihour, string type, int fee)
        {
            this.Code = code;
            this.Credithour = credihour;
            this.SubjectType = type;
            this.SubjectFee = fee;
        }

        // default constructor 
        public Subjects()
        {

        }
         public Subjects(string code , string type , int credit_hours , int fee )
        {
            this.Code = code;
            this.Credithour = credit_hours;
            this.SubjectFee = fee;
            this.SubjectType = type; 
        }
        // function 
       
        // 




    }


}

