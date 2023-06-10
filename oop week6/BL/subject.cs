using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uams_lab6.BL
{
    class subject
    {
        public string Code;
        public int Credithour;
        public string SubjectType;
        public int SubjectFee;
        // parameterized constructor
        public subject(string code, string type, int credihour, int fee)
        {
            this.Code = code;
            this.Credithour = credihour;
            this.SubjectType = type;
            this.SubjectFee = fee;
        }
    }
}
