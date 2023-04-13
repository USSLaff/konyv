using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_konyv
{
    internal class konyvespolc
    {
        private Dictionary<string, int> konyvDict = new Dictionary<string, int>();
        List<Konyv> _konyvek = new List<Konyv>();
        public int konyvekSzama
        {
            get { return _konyvek.Count; }
        }
        public konyvespolc() { }


        public void KonyvHozzaadas(Konyv konyv)
        {
            if (konyvDict.ContainsKey(konyv.isbn)) {
                Console.WriteLine("Könyv már létezik a polcon.");
                return;

            }
            _konyvek.Add(konyv);
            Console.WriteLine(getBookIndex(konyv));
            konyvDict.Add(konyv.isbn, getBookIndex(konyv));
        }
        public int getBookIndex(Konyv konyv)
        {
            if (_konyvek.Contains(konyv))
            {
                return _konyvek.LastIndexOf(konyv);
            }
            return -1;
        }
        public Dictionary<string, int> getKonyvesDict()
        {
            return konyvDict;
        }
    }
}