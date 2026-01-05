using KerstApp_Eindevaluatie.ViewModels.Base;
using KerstAppBL.Model;
using KerstAppBL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstApp_Eindevaluatie.ViewModels.persoonen
{
    public class PersonenViewModel :VieuwModel
    {
        private readonly PersoonService persoonsrvc;

        public ObservableCollection<Persoon> Personen { get; } = new();

       
        public Command NieuwPersoonaanmaakCOMM { get; }
        public Command<Persoon> OpenDetailCommand { get; }

        public PersonenViewModel(PersoonService service)
        {
            persoonsrvc = service;


            NieuwPersoonaanmaakCOMM = new Command(async () => await Shell.Current.GoToAsync("persoon-detail")); // geen id = nieuw
            OpenDetailCommand = new Command<Persoon>(async (p) =>
            {
                if (p is null) return;
                await Shell.Current.GoToAsync($"persoon-detail?id={p.Id}");
            });

            
        }
    }
}
