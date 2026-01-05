using KerstAppBL.Interfaces;
using KerstAppBL.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppDL
{
    public class PersoonLitedb : IPersoonLiteDBrepository
    {
        private Lazy<ILiteDatabase> _database = new Lazy<ILiteDatabase>(() => new LiteDatabase("Persoon.db"));
        private ILiteCollection<Persoon> personen;
        private ILiteCollection<Persoon> PersonenLijst => personen ??= _database.Value.GetCollection<Persoon>();

        public List<Persoon> GeefAlle() => PersonenLijst.Query().OrderBy(p => p.Voornaam).ToList();
        
      
        public Persoon? GeefPersoonId(int id) =>  PersonenLijst.FindById(id);
        

        public bool Verwijder(int id) => PersonenLijst.Delete(id);
       

        public int VoegPersoon(Persoon persoon)
        {
            PersonenLijst.Upsert(persoon);
            return persoon.Id;
        }

    }
}
