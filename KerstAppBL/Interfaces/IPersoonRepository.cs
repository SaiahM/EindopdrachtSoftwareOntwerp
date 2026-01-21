using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Interfaces
{
    public  interface IPersoonRepository
    {
        public List<Persoon> GeefAllePersonen();
        public Persoon? GeefPersoonId(int id);
        public int VoegPersoon(Persoon persoon);
        public bool Verwijder(int id);
    }
}
