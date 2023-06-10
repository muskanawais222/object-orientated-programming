using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using challenge2.BL;

namespace challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            MountainBike bike = new MountainBike(1, 4, 6, 7);
           int a = bike.getGear();
            Console.WriteLine(a);

            bike.setGear(9);

            int b = bike.getGear();
            Console.WriteLine(b);

            Console.ReadKey();

        }
    }
}
