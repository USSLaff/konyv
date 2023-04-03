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
    public class InvalidLangException : Exception
    {
        public override string Message => $"Nem megfelelő nyelv!\nNyelv nem lehet üres!";
    }
    public class InvalidTitleException : Exception
    {
        public override string Message => $"Nem megfelelő hosszú cím!\nA címnek legalább 1 karakter hosszúnak kell lennie!";
    }
    public class InvalidWriterException : Exception
    {

        int length;
        public InvalidWriterException(int len)
        {
            length = len;
        }

        public int InvalidCode
        {
            get { return length; }
            set { length = value; }
        }

        public override string Message => $"Nem megfelelő hosszú ({length}) szerző!\nA szerzőnek legalább 6 karakter hosszúnak kell lennie";
    }


    public class InvalidReleaseException : Exception
    {

        int year;
        public InvalidReleaseException(int yr)
        {
            year = yr;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string Message => $"Nem megfelelő kiadási év ({year})!\nA kiadási évnek -10000 és 2023 között kell hogy legyen!";
    }
}