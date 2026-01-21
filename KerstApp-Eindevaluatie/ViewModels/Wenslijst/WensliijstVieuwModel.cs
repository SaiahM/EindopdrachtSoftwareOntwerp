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

namespace KerstApp_Eindevaluatie.ViewModels.Wenslijst
{
    public class WensliijstVieuwModel : VieuwModel
    {
        private  WenslijstItemService wenslijstsrv;

        public ObservableCollection<WenslijstItem> Items { get;  } = new();

        public Command verversen { get; init; }
        public Command nieuweitemWensComm { get; init; }
        // public Command<WenslijstItem> OpendetailCom { get; }


        private WenslijstItem? _OpenDetailCommand;
        public WenslijstItem? OpenDetailCommand { get => _OpenDetailCommand; set { _OpenDetailCommand = value; OnWenslijstSelected(value); } }
        private readonly INavigationService _navigationService;


        public WensliijstVieuwModel(WenslijstItemService srv, INavigationService NavigatieService)
        {
            wenslijstsrv = srv;
            _navigationService = NavigatieService;

              verversen = new Command(alleItems);
            nieuweitemWensComm = new Command(async () => await _navigationService.GoToAsync("wenslijst-detail"));
            

            alleItems();
        }

        private async void OnWenslijstSelected(WenslijstItem WenslijstItem)
        {
            var parameters = new Dictionary<string, object>
            {
                ["wenslijstItem"] = WenslijstItem
            };

            await _navigationService.GoToAsync("wenslijst-detail", parameters);
        }

        private void alleItems()
        {
            Items.Clear();
            foreach (var item in wenslijstsrv.GeefAlleWenslijstItem())
                Items.Add(item);
        }

    }
}
