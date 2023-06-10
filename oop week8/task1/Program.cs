using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder c1 = new Cylinder();
            Console.WriteLine(c1.getVolume());
            Console.WriteLine(c1.toString());

            Cylinder c2 = new Cylinder(2.5, 3.5);
            Console.WriteLine(c2.getVolume());
            Console.WriteLine(c2.toString());

            Cylinder c3 = new Cylinder(3, 4, "pink");
            Console.WriteLine(c3.getVolume());
            Console.WriteLine(c3.toString());
            Console.ReadKey();
           

        }
    }
}
