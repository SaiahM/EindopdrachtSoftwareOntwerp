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

        public ObservableCollection<WenslijstItem> Items { get; } = new();

        public Command verversen { get; }
        public Command nieuweitemWensComm { get; }
        public Command<WenslijstItem> OpendetailCom { get; }
        public WensliijstVieuwModel(WenslijstItemService srv)
        {
            wenslijstsrv = srv;

              verversen = new Command(alleItems);
            nieuweitemWensComm = new Command(async () => await Shell.Current.GoToAsync("wenslijst-detail"));
            OpendetailCom = new Command<WenslijstItem>(async (item) =>
            {
                if (item is null) return;
                await Shell.Current.GoToAsync($"wenslijst-detail?id={item.Id}");
            });

            alleItems();
        }

        private void alleItems()
        {
            Items.Clear();
            foreach (var item in wenslijstsrv.GeefAlleWenslijstItem())
                Items.Add(item);
        }

    }
}
