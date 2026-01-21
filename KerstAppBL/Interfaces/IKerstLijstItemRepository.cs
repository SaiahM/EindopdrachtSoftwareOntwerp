using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Interfaces
{
    public interface IKerstLijstItemRepository
    {
        public List<KerstlijstItem> GeefAlleKerstItem();
        public KerstlijstItem? GeefKerstlijstItemId(int id);
        public int VoegKerstlijstItem(KerstlijstItem kerstlijstItem);
        public bool VerwijderKerstlijstItem(int id);
    }
}
