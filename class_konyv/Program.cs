using class_konyv.exceptions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_konyv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            konyvespolc polc1= new konyvespolc();
            //példa helyes input: 0837868564|szerző1|cím1|2023|Magyar|false|n
            while (true)
            {


                try
                {
                    string[] input = Console.ReadLine().Split('|');
                    if (input.Length!=7)
                    {
                        Console.WriteLine("Nem megfelelő mennyiségű paraméterek!");
                        continue;
                    }
                    int year;
                    if (!int.TryParse(input[3], out year))
                    {
                        Console.WriteLine("Évszám helytelen formátum!");
                        continue;
                    }
                    bool enc;
                    if (!bool.TryParse(input[5], out enc))
                    {
                        Console.WriteLine("Enciklopédia helytelen formátum!");
                        continue;
                    }
                    char ebook;
                    if (char.TryParse(input[6], out ebook))
                    {
                        if (!(ebook.Equals('n') || ebook.Equals('i')))
                        {
                            Console.WriteLine("E-book helytelen formátum!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("E-book helytelen formátum!");
                    }
                    Konyv konyv1 = new Konyv(input[0], input[1], input[2], year, input[5], enc, ebook);

                    if (konyv1.exceptions.Count>0)
                    {
                        throw new AggregateException(konyv1.exceptions);
                    }
                    polc1.KonyvHozzaadas(konyv1);
                    
                }
                catch (AggregateException e)
                {
                    foreach (Exception item in e.InnerExceptions)
                    {
                        Console.WriteLine(item.Message);
                    }
                }
                Console.WriteLine($"Könyvek száma a polcon: {polc1.konyvekSzama}");
            }
            Console.ReadKey();
        }
    }
}
