using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.BL;
using Uams_lab6.DL;

namespace Uams_lab6.UI
{
    class DegreeprogramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            Console.Write("Enter Degree's Name : ");
            string Name = Console.ReadLine();
            Console.Write("Enter Degree's Duration : ");
            int Duration = int.Parse(Console.ReadLine());
            Console.Write("Enter Available Seats For " + Name + " : ");
            int Seats = int.Parse(Console.ReadLine());
            DegreeProgram DegreeRecord = new DegreeProgram(Name, Duration, Seats);
            Console.Write("Enter how many subjects to enter: ");
            int subjects = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count ; x++)
            {
                subject s = SubjectUI.takeInputForSubject();
                if(DegreeRecord.addSubject(s))
                {
                    // these are done here because we did not add a seprate option to add only the subjects'
                    if(!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeIntoFile("subject.txt", s);
                    }
                    Console.WriteLine("Subject added sucessfully");
                }
                else
                {
                    Console.WriteLine("Subject not added");
                    Console.WriteLine("Limit of 20 credit hour exceeded");
                    x--;

                }
            }

            return DegreeRecord;
        }

        public static void viewDegreeProgram()
        {
            foreach(DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
    }
}
