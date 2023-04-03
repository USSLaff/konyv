using class_konyv.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace class_konyv
{
    internal class Konyv
    {
        string ISBN;
        string Szerzok;
        string Cim;
        int Kiadas;
        string Nyelv;
        bool Enciklopedia;
        char Ebook;
        public List<Exception> exceptions = new List<Exception>();
        public string isbn
        {
            get { return ISBN; }
            set
            {
                if (value.Length == 10)
                {
                    //type 1
                    int num = 0;
                    /*int index = 0;
                    for (int i = 10; i > 1; i--)
                    {
                        Console.WriteLine(i+"*"+ value[index]);
                        num += int.Parse(value[index].ToString()) * i;
                        index++;
                    }

                    int o1 = (num/11)*11;
                    int o2 = ((num / 11)+1) * 11;
                    int lastnum = int.Parse(value) % 10;
                    int validator ;
                    Console.WriteLine(num);
                    if (Math.Abs(num-o1)<Math.Abs(num-o2))
                    {
                        validator = Math.Abs(num - o1);
                    }
                    else
                    {
                        validator = Math.Abs(num - o2);
                    }
                    Console.WriteLine($"alatt: {Math.Abs(num - o1)}, {o1}, validator: {lastnum}");
                    Console.WriteLine($"fölött: {Math.Abs(num - o2)}, {o2}, validator: {lastnum}");

                    if (int.Parse(value[9].ToString()) == validator)
                    {
                        ISBN = value;
                        return;
                    }
                    else
                    {
                        throw new ISBNInvalidException(value);
                    }*/
                    //type 2
                    num = 0;
                    for (int i = 1; i < 10; i++)
                    {
                        num += int.Parse(value[i-1].ToString())*i;
                    }
                    if (int.Parse(value[9].ToString())==num%11)
                    {
                        ISBN = value;
                        return;
                    }
                    else
                    {
                        exceptions.Add(new ISBNInvalidException(value));
                        //throw new ISBNInvalidException(value);
                    }
                }
                if (value.Length == 13)
                {

                    int num = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        if (i % 2 ==0)
                        {
                            num += int.Parse(value[i].ToString());
                        }
                        else
                        {
                            num += int.Parse(value[i].ToString()) * 3;
                        }
                    }
                    int maradek = num % 10;
                    int validator;
                    if (maradek == 0)
                    {
                        validator = 0;
                    }
                    else
                    {
                       validator = 10 - maradek;
                    }
                    if (int.Parse(value[12].ToString()) == validator)
                    {
                        ISBN = value;
                        return;
                    }
                    else
                    {
                        exceptions.Add(new ISBNInvalidException(value));
                        //throw new ISBNInvalidException(value);
                    }

                }
                exceptions.Add(new ISBNLengthException(value));
                //throw new ISBNLengthException(value);
            }
        }

        public string szerzok
        {
            get { return Szerzok; }
            set
            {
                char[] chars = { ' ' };
                int trueLen = value.Trim(chars).Length;
                if (trueLen < 6)
                {
                    exceptions.Add(new InvalidWriterException(trueLen));
                    //throw new InvalidWriterException(trueLen);
                }
                else
                {
                    Szerzok = value;
                }
            }
        }

        public string cim
        {
            get { return Cim; }
            set
            {
                char[] chars = { ' ' };
                if (value.Trim(chars).Length < 2)
                {
                    exceptions.Add(new InvalidTitleException());
                    //throw new InvalidTitleException();
                }
                else
                {
                    Cim = value;
                }
            }
        }

        public int kiadas
        {
            get { return Kiadas; }
            set {
                if (value<-10000 || value>2023)
                {
                    exceptions.Add(new InvalidReleaseException(value));
                    //throw new InvalidReleaseException(value);
                }
                else {
                    Kiadas = value;
                }
                
            }
        }
        public string nyelv
        {
            get { return Nyelv; }
            set {
                char[] chars = { ' ' };
                if (value.Trim(chars).Length < 1)
                {
                    exceptions.Add(new InvalidLangException());
                    //throw new InvalidLangException();
                }
                else
                {
                    Nyelv = value;
                }
            }
        }
        public bool enciklopedia
        {
            get { return Enciklopedia; }
            set { Enciklopedia = value; }
        }
        public char ebook
        {
            get { return Ebook; }
            set { Ebook = value; }
        }

        public Konyv()
        {

        }
        ~Konyv()
        {
            Console.WriteLine("dest xd");
        }
        public Konyv(string iSBN, string  szerzok, string cim, int kiadas, string nyelv, bool enciklopedia, char ebook)
        {
            isbn = iSBN;
            this.szerzok = szerzok;
            this.cim = cim;
            this.kiadas = kiadas;
            this.nyelv= nyelv;
            this.enciklopedia = enciklopedia;
            this.ebook = ebook;
        }
    }
}
