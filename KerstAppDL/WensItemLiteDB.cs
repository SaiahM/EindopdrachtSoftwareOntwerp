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
    public class WensItemLiteDB : IWensLijstItemDbRepository
    {
        private Lazy<ILiteDatabase> _database = new Lazy<ILiteDatabase>(() => new LiteDatabase("WensItem.db"));
        private ILiteCollection<WenslijstItem> wensItems;
        private ILiteCollection<WenslijstItem> WensItemsLijst => wensItems ??= _database.Value.GetCollection<WenslijstItem>();

        public List<WenslijstItem> GeefAlle()
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
    }
}
