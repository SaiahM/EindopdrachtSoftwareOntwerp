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

        public WenslijstItem Item { get; private set; } = new();

        private string? error;
        public string? Error { get  { return error; } set { error = value; }  }

        public Command opslaanCmm { get; }
        public Command anulleer { get; }

        public WensLijstdetailViewModel(WenslijstItemService service)
        {
            srv = service;

            opslaanCmm = new Command(async () => await opslaan());
            anulleer = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Error = null;

            if (query.TryGetValue("id", out var idObj) && int.TryParse(idObj?.ToString(), out var id))
            {
                Item = srv.GeefWenslijstItemId(id) ?? new WenslijstItem();
            }
            else
            {
                Item = new WenslijstItem();
            }

            OnPropertyChanged(nameof(Item));
        }

        private async 
        Task
opslaan()
        {
            Error = null;

            if (string.IsNullOrWhiteSpace(Item.Titel))
            {
                Error = "Titel is verplicht.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Item.Website))
            {
                Error = "Website is verplicht.";
                return;
            }

            srv.VoegWenslijstItemToe(Item); 
            await Shell.Current.GoToAsync("..");
        }
    }
}
