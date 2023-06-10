using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.BL
{
    class Dog : Mammal
    {
        public Dog(string name) : base(name)
        {

        }
        public override void greets()
        {
            Console.WriteLine("Woof");
        }

        public override string toString()
        {
            return base.toString();
        }

    }
}
