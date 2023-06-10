using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uams_lab6.BL;
using System.IO;

namespace Uams_lab6.DL
{
    class SubjectDL
    {
        public static List<subject> subjectList = new List<subject>();

        // function to add subject
        public static void addSubjectIntoList(subject s)
        {
            subjectList.Add(s);
        }
        // read from file
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while((record = f.ReadLine())!=null)
                {

                    string[] splittedRecord = record.Split(','); // array
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int credithour = int.Parse(splittedRecord[2]);
                    int subjectFee = int.Parse(splittedRecord[3]);
                    subject s = new subject(code, type, credithour, subjectFee);
                    addSubjectIntoList(s);
                }
                f.Close();
                return true;
            }
            else
                return false;
        }

        public static void storeIntoFile(string path , subject s)
        {
            StreamWriter f = new StreamWriter(path,true);
            f.WriteLine(s.Code + "," + s.SubjectType + "," + s.Credithour + "," + s.SubjectFee);
            f.Flush();
            f.Close();
        }
        public static subject isSubjectExists(string type)
        {
            foreach (subject sub in subjectList) // sub is var .... subjects is list ... Capital S is class
            {
                if (sub.SubjectType == type)
                {
                    return sub;
                }
            }
            return null;
        }
    }
}
