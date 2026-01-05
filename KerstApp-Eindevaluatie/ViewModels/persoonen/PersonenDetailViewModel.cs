using KerstApp_Eindevaluatie.ViewModels.Base;
using KerstAppBL.Model;
using KerstAppBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KerstApp_Eindevaluatie.ViewModels.persoonen
{
    public class PersonenDetailViewModel : VieuwModel, IQueryAttributable
    {
        private  PersoonService persSrvc;

        private string? foutbooschap;
        public string? Foutbooschap
        {
            get { return foutbooschap; }
            set { value = foutbooschap; }
        }

        public PersonenDetailViewModel(PersoonService PersoonService)
        {
            persSrvc = PersoonService;

            SaveCommand = new Command(async () => await Opslaan());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

        }

        public Persoon Item { get; private set; } = new();

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Foutbooschap = null;

            if (query.TryGetValue("id", out var idObj) && int.TryParse(idObj?.ToString(), out var id))
            {
                var bestaande = persSrvc.GeefIdVanPersoon(id); // pas aan
                Item = bestaande ?? new Persoon();
            }
            else
            {
                Item = new Persoon();
            }

            OnPropertyChanged(nameof(Item));
        }

        private async Task Opslaan()
        {
            Foutbooschap = null;

            if (string.IsNullOrWhiteSpace(Item.Voornaam))
            {
                Foutbooschap = "Voornaam is verplicht.";
                return;
            }

            persSrvc.VoegPersoonToe(Item); 
            await Shell.Current.GoToAsync("..");
        }
    }
}
