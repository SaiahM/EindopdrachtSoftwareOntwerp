using KerstApp_Eindevaluatie.Interfaces;
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
    public class KerstlijstDetailViewModel: VieuwModel,IQueryAttributable
    {
        private readonly KerstLijstItemService _kerstService;
        private readonly PersoonService _persoonService;

        public KerstlijstItem Item { get; private set; } = new();

        public ObservableCollection<Persoon> Personen { get; } = new();

        private Persoon? _selectedPersoon;
        public Persoon? SelectedPersoon
        {
            get { return _selectedPersoon; }
            set { _selectedPersoon = value; }
        }

        private string _prijsInput = "";
        public string PrijsInput
        { get { return _prijsInput; } set { _prijsInput = value; } }

        private string? error;
        public string? Foutmelding { get { return error; } set { error = value; OnPropertyChanged(nameof(Foutmelding)); } }

        public Command SaveCommand { get; init; }
        public Command CancelCommand { get; init; }
        private readonly INavigationService _navigationService;

        public KerstlijstDetailViewModel(KerstLijstItemService kerstService, PersoonService persoonService, INavigationService Navigatie)
        {
            _kerstService = kerstService;
            _persoonService = persoonService;
            _navigationService = Navigatie;

            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await _navigationService.GoBackAsync());

            LoadPersonen();
        }

        private void LoadPersonen()
        {
            Personen.Clear();
            foreach (var p in _persoonService.GeefAllePersonen())
                Personen.Add(p);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Foutmelding = null;

            if (query.TryGetValue("kerstlijstItem", out var kerstlijstItemObj) && kerstlijstItemObj is KerstlijstItem kerstlijstItem)
            {
                Item = kerstlijstItem;
            }
            else
            {
                Item = new KerstlijstItem();
            }

            
            PrijsInput = Item.Prijs.HasValue ? Item.Prijs.Value.ToString() : "";

            
            SelectedPersoon = Item.PersoonId.HasValue
                ? Personen.FirstOrDefault(p => p.Id == Item.PersoonId.Value)
                : null;

            OnPropertyChanged(nameof(Item));
        }

        private async Task Save()
        {
            Foutmelding = null;

            if (string.IsNullOrWhiteSpace(Item.Titel))
            {
                Foutmelding = "Titel is verplicht.";
                return;
            }

          
            if (string.IsNullOrWhiteSpace(PrijsInput))
            {
                Item.Prijs = null;
            }
            else
            {
                if (!decimal.TryParse(PrijsInput, out var prijs))
                {
                    Foutmelding = "Prijs heeft een ongeldig formaat.";
                    return;
                }

                if (prijs < 0)
                {
                    Foutmelding = "Prijs mag niet negatief zijn.";
                    return;
                }

                Item.Prijs = prijs;
            }

           
            _kerstService.VoegkerstitemToe(Item);
            await _navigationService.GoBackAsync();
        }
    }
}
