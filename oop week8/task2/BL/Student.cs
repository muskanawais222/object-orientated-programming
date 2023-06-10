using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.BL
{
    class Student : Person
    {
        protected string program;
        protected int year;
        protected double fee;
        // parameterized constructor
        public Student(string name , string address,string program , int year , double fee)
        {
            this.Name = name;
            this.Address = address;
            this.year = year;
            this.fee = fee;
        }
        // functions
        public string getProgram()
        {
            return program; 
        }
        public void setProgram(string program)
        {
            this.program = program;
        }
        public int getYear()
        {
            return year;
        }
        public void setYear(int year)
        {
            this.year = year;
        }
        public double getFee()
        {
            return fee;
        }
        public void setFee(Double fee)
        {
            this.fee = fee;
        }

        public override string toString()
        {
            return "Name: " + Name + " ,Address: " + Address + " Program: " + program + " Year: " + year + " Fee: " + fee;  
        }
    }
}
