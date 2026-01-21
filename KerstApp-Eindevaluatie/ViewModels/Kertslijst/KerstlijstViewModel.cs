using KerstApp_Eindevaluatie.Interfaces;
using KerstApp_Eindevaluatie.Service;
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

        public Command VerversCommand { get; init; }
        public Command NieuweKerstItemCommand { get; init; }
        public Command OpenPersonenCommand { get; init; }
      //  public Command<KerstlijstItem> OpenDetailCommand { get=> }

        private KerstlijstItem? _OpenDetailCommand;
        public KerstlijstItem? OpenDetailCommand { get => _OpenDetailCommand; set { _OpenDetailCommand = value; OnKerstlijstSelected(value); } }
        private readonly INavigationService _navigationService;




        public KerstlijstViewModel(KerstLijstItemService kerstService, PersoonService persoonService, INavigationService inn)
        {
            _kerstService = kerstService;
            _persoonService = persoonService;
            _navigationService = inn;

            VerversCommand = new Command(Load);
            NieuweKerstItemCommand = new Command(async () => await _navigationService.GoToAsync("KerstlijstDetailPage"));
            OpenPersonenCommand = new Command(async () => await _navigationService.GoToAsync("personen"));

           

            Load();
        }

        private async void OnKerstlijstSelected(KerstlijstItem KerstlijstItem)
        {
            var parameters = new Dictionary<string, object>
            {
                ["kerstlijstItem"] = KerstlijstItem
            };

            await _navigationService.GoToAsync("KerstlijstDetailPage",parameters);
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
