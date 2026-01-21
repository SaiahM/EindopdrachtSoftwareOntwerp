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
    public class KerstAppRepository: IKerstLijstItemRepository,IPersoonRepository,IWensLijstItemRepository
    {
        private static readonly Lazy<ILiteDatabase> _dbKerstApp = new(() => new LiteDatabase("KerstApp.db"));

        public static ILiteCollection<KerstlijstItem> KerstItemLijst => _dbKerstApp.Value.GetCollection<KerstlijstItem>("KerstItems");

        public static ILiteCollection<Persoon> PersonenLijst = _dbKerstApp.Value.GetCollection<Persoon>("Personen");

        public static ILiteCollection<WenslijstItem> WensItemsLijst => _dbKerstApp.Value.GetCollection<WenslijstItem>("WensItems");


        /// <summary>
        /// ///////Wenslijst
        /// </summary>
        /// <returns></returns>
        public List<WenslijstItem> GeefAlleWensItem()
        {
            return WensItemsLijst.Query().OrderBy(p => p.Titel).ToList();
        }

        public WenslijstItem? GeefWenslijstItemId(int id)
        {
            return WensItemsLijst.FindById(id);
        }

        public bool VerwijderWenslijstItem(int id)
        {
            return WensItemsLijst.Delete(id);
        }

        public int VoegWenslijstItem(WenslijstItem wenslijstItem)
        {
            WensItemsLijst.Upsert(wenslijstItem);
            return wenslijstItem.Id;
        }

        /////////////////////////////////////Personen///////////
        public List<Persoon> GeefAllePersonen() => PersonenLijst.Query().OrderBy(p => p.Voornaam).ToList();


        public Persoon? GeefPersoonId(int id) => PersonenLijst.FindById(id);


        public bool Verwijder(int id) => PersonenLijst.Delete(id);


        public int VoegPersoon(Persoon persoon)
        {
            PersonenLijst.Upsert(persoon);
            return persoon.Id;
        }

        ////////////////////KerstItem
        ///
        public List<KerstlijstItem> GeefAlleKerstItem()
        {
            return KerstItemLijst.Query().OrderBy(p => p.Titel).ToList();
        }

        public KerstlijstItem? GeefKerstlijstItemId(int id)
        {
            return KerstItemLijst.FindById(id);
        }

        public bool VerwijderKerstlijstItem(int id)
        {
            return KerstItemLijst.Delete(id);
        }

        public int VoegKerstlijstItem(KerstlijstItem kerstlijstItem)
        {
            KerstItemLijst.Upsert(kerstlijstItem);
            return kerstlijstItem.Id;
        }
    }
}
