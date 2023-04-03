using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_konyv
{
    internal class konyvespolc
    {
        List<Konyv> _konyvek = new List<Konyv>();
        public int konyvekSzama
        {
            get { return _konyvek.Count; }
        }
        public konyvespolc() { }

        public void KonyvHozzaadas(Konyv konyv)
        {
            _konyvek.Add(konyv);
        }
        public void KonyvKivetel(Konyv konyv)
        {
            if (_konyvek.Contains(konyv))
            {
                _konyvek.Remove(konyv);
            }
        }
    }
}