using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_konyv.exceptions
{
    public class ISBNLengthException : Exception
    {
        string length;
        public ISBNLengthException(string len)
        {
            length = len;
        }

        public string InvalidLength
        {
            get { return length; }
            set { length = value; }
        }

        public override string Message => $"Nem megfelelő hossz (10/13): {length}";

    }
    public class ISBNInvalidException :Exception
    {

        string code;
        public ISBNInvalidException(string len)
        {
            code = len;
        }

        public string InvalidCode
        {
            get { return code; }
            set { code = value; }
        }

        public override string Message => $"Nem megfelelő ISBN Kód: {code}";
    }
}