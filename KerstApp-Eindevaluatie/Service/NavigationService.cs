using KerstApp_Eindevaluatie.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerstApp_Eindevaluatie.Service
{
    public class NavigationService : INavigationService
    {
        public Task GoBackAsync()
        {
           return  Shell.Current.Navigation.PopAsync();
        }

        public Task GoToAsync(string route, IDictionary<string, object>? parameters = null)
        {
            if (parameters is null)
                return Shell.Current.GoToAsync(route);

            return Shell.Current.GoToAsync(route, parameters);
        }
    }
}
