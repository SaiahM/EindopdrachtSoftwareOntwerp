using KerstApp_Eindevaluatie.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstApp_Eindevaluatie.ViewModels
{
    public class MainPageViewModel : VieuwModel
    {
        public Command OpenWenslijstCo { get; }
        public Command OpenKerstlijstCom { get; }

        public MainPageViewModel()
        {


            OpenWenslijstCo = new Command(async () => await Shell.Current.GoToAsync("wenslijst"));
            OpenKerstlijstCom = new Command(async () => await Shell.Current.GoToAsync("kerstlijst"));

        }
    }
}
