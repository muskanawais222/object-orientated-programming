using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pd4Task1.BL;

namespace pd4Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ship> ships = new List<ship>();
            ship s = null;
            int option;
            do
            {
                Console.Clear();
                option = menu();
                if (option == 1)
                {
                    ship s1 = new ship();
                    s1 = addShip();
                    ships.Add(s1);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Serial no to find its position:");
                    string no = Console.ReadLine();
                    for (int x = 0; x < ships.Count; x++)
                    {
                        if (ships[x].ship_Number == no)
                        {
                            Console.WriteLine("Ship is at " + ships[x].longitude.degrees + "\u00b0" + ships[x].longitude.minutes + "'" + ships[x].longitude.direction + ships[x].latitude.degrees + "\u00b0" + ships[x].latitude.minutes + "'" + ships[x].latitude.direction);
                            Console.ReadLine();
                        }
                    }

                }
                else if(option == 3)
                {
                    Console.WriteLine("Enter the ship serial number to find its position:");
                    string no = Console.ReadLine();
                    angle latitude = s.returnLocationLatitude(ships, no);
                    angle logitude = s.returnLocationLongitude(ships, no);




                }
                else if (option == 4)
                {
                    ship ship = takeInputForChangePosition(ships, s);
                    ships.Add(s);
                }
                else  if(option == 5)
                    option = -1;
                
            }
            while (option != -1);


        }
        static int menu()
        {
            int option;
           
            Console.WriteLine("1. Add ship");
            Console.WriteLine("2. View Ship position");
            Console.WriteLine("3. View Ship serial Number");
            Console.WriteLine("4. Change ship position");
            Console.WriteLine("5. exit");
            Console.WriteLine("Enter your choice");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static ship addShip()
        {
            ship s = new ship();
            Console.WriteLine("Enter ship number: ");
            s.ship_Number = Console.ReadLine();
            Console.WriteLine("Enter Latitude’s Degree:");
            s.latitude.degrees = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Minute:");
            s.latitude.minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Direction:");
            s.latitude.direction = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude:");
            Console.WriteLine("Enter Longitude’s Degree:");
            s.longitude.degrees = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Minute:");
            s.longitude.minutes = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Direction:");
            s.longitude.direction = char.Parse(Console.ReadLine());
            return s;

        }
        public static ship takeInputForChangePosition(List<ship> s, ship ships)
        {
            Console.Write("Enter ship number: ");
            string number = Console.ReadLine();
            foreach (ship x in s)
            {
                if (number == x.ship_Number)

                    Console.WriteLine("Enter ship longitude:");
                Console.Write("Enter longitude's degree: ");
                int degree = int.Parse(Console.ReadLine());
                x.longitude.degrees = degree;
                Console.Write("enter longitude's Minutes: ");
                float minutes = float.Parse(Console.ReadLine());
                x.longitude.minutes = minutes;
                Console.Write("enter longitude's direction: ");
                char direction = char.Parse(Console.ReadLine());
                x.longitude.direction = direction;
                angle shiplongitude = new angle(degree, minutes, direction);
                Console.WriteLine("enter ship latitude:");

                Console.Write("enter latitude's degree: ");
                int degreeL = int.Parse(Console.ReadLine());
                x.latitude.degrees = degreeL;
                Console.Write("enter latitude's Minutes: ");
                float minutesl = float.Parse(Console.ReadLine());
                x.latitude.minutes = minutesl;
                Console.Write("enter latitude's direction: ");
                char directionL = char.Parse(Console.ReadLine());
                x.latitude.direction = directionL;
                angle shiplatitude = new angle(degreeL, minutesl, directionL);
                ship newShip = new ship(number, shiplongitude, shiplatitude);
                return newShip;
            }
            return ships;
        }
        public static void viewShipAngle(angle latitude, angle longitude)
        {
            Console.WriteLine(latitude.degrees + "'" + latitude.minutes + "'" + latitude.direction + "'");
            Console.WriteLine(longitude.degrees + "'" + longitude.minutes + "'" + longitude.direction + "'");
        }

    }
}
