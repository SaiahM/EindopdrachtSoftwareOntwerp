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
    public class KerstItemLiteDb : IKerstLijstItemRepository
    {
        private Lazy<ILiteDatabase> _database = new Lazy<ILiteDatabase>(() => new LiteDatabase("KerstItem.db"));
        private ILiteCollection<KerstlijstItem> kerstitems;
        private ILiteCollection<KerstlijstItem> KerstItemLijst => kerstitems ??= _database.Value.GetCollection<KerstlijstItem>();

        public List<KerstlijstItem> GeefAlle()
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
