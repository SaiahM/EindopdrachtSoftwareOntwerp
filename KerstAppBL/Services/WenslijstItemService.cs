using KerstAppBL.Interfaces;
using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Services
{
    public class WenslijstItemService(IWensLijstItemRepository repo)
    {
        private IWensLijstItemRepository Repo { get; } = repo;


        public List<WenslijstItem> GeefAlleWenslijstItem() => Repo.GeefAlleWensItem();

        public int VoegWenslijstItemToe(WenslijstItem yy)
        {


            return Repo.VoegWenslijstItem(yy);
        }

        public WenslijstItem? GeefWenslijstItemId(int id) => Repo.GeefWenslijstItemId(id);

        public bool VerwijderWenslijstItem(int id) => Repo.VerwijderWenslijstItem(id);

    }
}
