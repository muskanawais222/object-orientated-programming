using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.BL
{
    class Person
    {
        protected string Name;
        protected string Address;
        //default constructor
        public Person()
        {

        }
        //parameterized constructor
        public Person(string name , string address)
        {
            this.Name = name;
            this.Address = address;
        }
        // functions 
        public string getName()
        {
            return Name;
        }
        public string getAddress()
        {
            return Address;
        }
        public void setAddress(string address)
        {
            this.Address = address;
        }
        public virtual string toString()
        {
            return "Name: " + Name + " Address: " + Address;
        }
    }
}
