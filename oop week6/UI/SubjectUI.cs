using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.BL;

namespace Uams_lab6.UI
{
    class SubjectUI
    {

        public static subject takeInputForSubject()
        {

            Console.Write("Enter Subject's Name : ");
            string SubjectCode = Console.ReadLine();
            Console.Write("Enter Subject's Type : ");
            string SubjectType = Console.ReadLine();
            Console.Write("Enter Subject's Credit Hours : ");
            int CreditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject's Fees : ");
            int SubjectFees = int.Parse(Console.ReadLine());
            subject SubjectRecord = new subject(SubjectCode, SubjectType, CreditHours, SubjectFees);
            return SubjectRecord;
        }
        public static void viewSubject(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("subcode \t subtype");
                foreach (subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.Code + "\t \t" + sub.SubjectType);
                }
            }
        }
        public static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many student you want to register");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter subject code");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (subject sub in s.regDegree.subjects)
                {
                    if (code == sub.Code && !(s.regSubject.Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                    else
                        Console.WriteLine("A student can not have more than 9 credit hour");
                    flag = true;
                    break;
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid course");
                    x--;
                }
            }
        }
    }
}
