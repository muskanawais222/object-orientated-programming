using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.BL
{
    class Animal
    {
        protected string name;
        // parameterized constructor
        public Animal(string name)
        {
            this.name = name;
        }

        public virtual string toString()
        {
            return "Name : " + name; 
        }

        public  virtual void greets()
        {
            Console.WriteLine("Woof");
        }
    }
}
