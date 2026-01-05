using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Interfaces
{
    public interface IWensLijstItemDbRepository
    {
        public List<WenslijstItem> GeefAlle();
        public WenslijstItem? GeefWenslijstItemId(int id);
        public int VoegWenslijstItem(WenslijstItem wenslijstItem);
        public bool VerwijderWenslijstItem(int id);
    }
}
