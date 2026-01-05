using KerstApp_Eindevaluatie.ViewModels.Base;
using KerstAppBL.Model;
using KerstAppBL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstApp_Eindevaluatie.ViewModels.Kertslijst
{
    public class KerstlijstViewModel : VieuwModel
    {
        private readonly KerstLijstItemService _kerstService;
        private readonly PersoonService _persoonService;

        public ObservableCollection<KerstlijstItem> Items { get; } = new();
        public ObservableCollection<Persoon> Personen { get; } = new(); 

        public Command verversCmm { get; }
        public Command NieuwComm { get; }
        public Command OpenPersonenCommand { get; }
        public Command<KerstlijstItem> OpenDetailCommand { get; }

        public KerstlijstViewModel(KerstLijstItemService kerstService, PersoonService persoonService)
        {
            _kerstService = kerstService;
            _persoonService = persoonService;

            verversCmm = new Command(Load);
            NieuwComm = new Command(async () => await Shell.Current.GoToAsync("kerstlijst-detail"));
            OpenPersonenCommand = new Command(async () => await Shell.Current.GoToAsync("personen"));

            OpenDetailCommand = new Command<KerstlijstItem>(async (item) =>
            {
                if (item is null) return;
                await Shell.Current.GoToAsync($"kerstlijst-detail?id={item.Id}");
            });

            Load();
        }

        private void Load()
        {
            Personen.Clear();
            foreach (var p in _persoonService.GeefAllePersonen())
                Personen.Add(p);

            Items.Clear();
            foreach (var item in _kerstService.GeefAlle())
                Items.Add(item);

            
        }
    }
}
