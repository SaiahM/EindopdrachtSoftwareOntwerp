using KerstAppBL.Interfaces;
using KerstAppBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstAppBL.Services
{
    public class KerstLijstItemService(IKerstLijstItemRepository repo)
    {
        private IKerstLijstItemRepository Repo { get; } = repo;
        

        public List<KerstlijstItem> GeefAlle() => Repo.GeefAlle();

        public int VoegkerstitemToe(KerstlijstItem kl)// 
        {
            

            return Repo.VoegKerstlijstItem(kl );
        }

        public KerstlijstItem? GeefIdVanKerstLijstItem(int id) => Repo.GeefKerstlijstItemId(id);

        public bool VerwijderKerstLijstItem(int id) => Repo.VerwijderKerstlijstItem(id);
    }
}
