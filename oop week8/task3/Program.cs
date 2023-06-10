using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task3.BL;

namespace task3 
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animalList = new List<Animal>();
            Cat c = new Cat("silky");
            Cat c1 = new Cat("Bluey");
            Dog d = new Dog("koi bhi");
            Dog d1 = new Dog("2");
            animalList.Add(c);
            animalList.Add(c1);
            animalList.Add(d);
            animalList.Add(d1);
            foreach(Animal a in animalList)
            {
                Console.WriteLine(a.toString());
                a.greets();
            }
            Console.ReadLine();
        }
    }
}
