using KerstApp_Eindevaluatie.Interfaces;
using KerstApp_Eindevaluatie.ViewModels.Base;
using KerstAppBL.Model;
using KerstAppBL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstApp_Eindevaluatie.ViewModels.Wenslijst
{
    public class WensLijstdetailViewModel: VieuwModel, IQueryAttributable
    {
        private readonly WenslijstItemService srv;

        public WenslijstItem Item { get;  set; } = new();

        private string? error;
        public string? Foutmelding { get  { return error; } set { error = value; OnPropertyChanged(nameof(Foutmelding)); }  }

        public Command OpslaanCommand { get; init; }
        public Command AnulleerCommand { get; init; }
        private readonly INavigationService _navigationService;

        public WensLijstdetailViewModel(WenslijstItemService service,INavigationService NavigatieService)
        {
            srv = service;
            _navigationService = NavigatieService;
            OpslaanCommand = new Command(async () => await opslaan());
            AnulleerCommand = new Command(async () => await _navigationService.GoBackAsync());
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Foutmelding = null;

            if (query.TryGetValue("wenslijstItem", out var wenslijstItemObj) && wenslijstItemObj is WenslijstItem wenslijstItem)   //
            {
                Item = wenslijstItem;
            }
            else
            {
                Item = new WenslijstItem();
            }

            OnPropertyChanged(nameof(Item));
        }

        private async Task opslaan()
        {
            Foutmelding = null;

            if (string.IsNullOrWhiteSpace(Item.Titel))
            {
                Foutmelding = "Titel is verplicht.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Item.Website))
            {
                Foutmelding = "Website is verplicht.";
                return;
            }

            srv.VoegWenslijstItemToe(Item); 
            await _navigationService.GoBackAsync();
        }
    }
}
