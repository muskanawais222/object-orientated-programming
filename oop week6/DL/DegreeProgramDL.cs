using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.BL;
using System.IO;
namespace Uams_lab6.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();
        // function to add into degreelist
        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        // degree exists
        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram d in programList) // sub is var .... subjects is list ... Capital S is class
            {
                if (d.degreeName == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
        // store int file
        public static void storeIntoFile(string path,  DegreeProgram d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string subjectName = "";
            for(int x = 0; x< d.subjects.Count-1; x++) // subjects is the list of subject.
            {
                subjectName = subjectName + d.subjects[x].SubjectType + ";";
            }
            subjectName = subjectName + d.subjects[d.subjects.Count-1].SubjectType + ";";

            f.WriteLine(d.degreeName + "," + d.duration + "," + d.seats + "," +subjectName);
            f.Flush();
            f.Close();
        }
        // read from file
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {

                    string[] splittedRecord = record.Split(','); // array
                    string degreeName = splittedRecord[0];
                    float degreeDuration = float.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForsubject = splittedRecord[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
                    for(int x = 0; x< splittedRecordForsubject.Length; x++)
                    {
                        subject s = SubjectDL.isSubjectExists(splittedRecordForsubject[x]);
                        if(s!= null)
                        {
                            d.addSubject(s);
                        }
                    }
                    addIntoDegreeList(d);
                }
                f.Close();
                return true;
            }
            else
                return false;
        }

    }
}
