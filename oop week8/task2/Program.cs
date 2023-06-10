using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.BL;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            Student s = new Student("123", "456Address", "Computer", 2022, 2098.56);
            Student s1 = new Student("789", "789Address", "Computer Science", 2025, 508.56);
            Staff sf1 = new Staff("staff1", "stAddress", "St School", 2059.45);
            Staff sf2 = new Staff("2staff", "2stAddress", "2St School", 3452059.45);
            personList.Add(s);
            personList.Add(s1);
            personList.Add(sf1);
            personList.Add(sf2);
            foreach(Person p in personList)
            {
                Console.WriteLine(p.toString());
            }
            Console.Read();
        }
    }
}
