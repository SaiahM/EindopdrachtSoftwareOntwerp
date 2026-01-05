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

        private string? _error;
        public string? Error { get { return _error; } set { _error = value; } }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public KerstlijstDetailViewModel(KerstLijstItemService kerstService, PersoonService persoonService)
        {
            _kerstService = kerstService;
            _persoonService = persoonService;

            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

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
            Error = null;

            if (query.TryGetValue("id", out var idObj) && int.TryParse(idObj?.ToString(), out var id))
            {
                Item = _kerstService.GeefIdVanKerstLijstItem(id) ?? new KerstlijstItem();
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
            Error = null;

            if (string.IsNullOrWhiteSpace(Item.Titel))
            {
                Error = "Titel is verplicht.";
                return;
            }

            // Prijs parsing
            if (string.IsNullOrWhiteSpace(PrijsInput))
            {
                Item.Prijs = null;
            }
            else
            {
                if (!decimal.TryParse(PrijsInput, out var prijs))
                {
                    Error = "Prijs heeft een ongeldig formaat.";
                    return;
                }

                if (prijs < 0)
                {
                    Error = "Prijs mag niet negatief zijn.";
                    return;
                }

                Item.Prijs = prijs;
            }

           
            _kerstService.VoegkerstitemToe(Item);
            await Shell.Current.GoToAsync("..");
        }
    }
}
