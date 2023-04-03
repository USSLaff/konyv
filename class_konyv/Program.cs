using class_konyv.exceptions;
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
            while (true)
            {
                try
                {
                    Console.Write("Adja meg a könyv ISBN kódját: ");
                    Konyv xd = new Konyv();
                    //xd.isbn = "9789635683659";
                    string input = Console.ReadLine();
                    if (!long.TryParse(input, out long temp))
                    {
                        throw new FormatException("Helytelen formátum; csak számokat tartalmazhat!");
                    }
                    string formatted = "";
                    foreach (var item in input.Split('-'))
                    {
                        formatted += item;
                    }
                    xd.isbn = formatted;

                    Console.WriteLine($"ISBN kód helyes: {xd.isbn}");
                }
                catch (ISBNLengthException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                catch (ISBNInvalidException e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
