using KerstAppBL.Interfaces;
using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Services
{
    public class PersoonService(IPersoonRepository repo)
    {
        private IPersoonRepository Repo { get; } = repo;
        //IPersoonLiteDBrepository

            public List<Persoon> GeefAllePersonen() => Repo.GeefAllePersonen();

        public int VoegPersoonToe(Persoon achternm)// wekrt niet
        {


            return Repo.VoegPersoon(achternm);
        }

        public Persoon? GeefIdVanPersoon(int id) => Repo.GeefPersoonId(id);

        public bool VerwijderPersoon(int id) => Repo.Verwijder(id);
    }
}
