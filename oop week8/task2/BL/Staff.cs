using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.BL
{
    class Staff : Person
    {
        protected string school;
        protected double pay;
        // parameterized constructor
        public Staff(string name1 , string address , string sch , double pay)
        {
            this.Name = name1;
            this.Address = address;
            this.school = sch;
            this.pay = pay;
        }
         // functions 
         public string getSchool()
        {
            return school;
        }
        public void SetSchool(string school)
        {
            this.school = school;
        }
        public void SetPay(double pay)
        {
            this.pay = pay;
        }
         // tostring
         public override string toString()
        {
            return "Name: " + Name + " ,Address: " + Address + " School: " + school + " Pay: " + pay;
        }
    }

}
