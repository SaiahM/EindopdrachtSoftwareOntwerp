using KerstApp_Eindevaluatie.ViewModels.Wenslijst;

namespace KerstApp_Eindevaluatie.Paginas.Wenslijstpaginass;

public partial class WenslijstDetailPage : ContentPage
{
    public WenslijstDetailPage(WensLijstdetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}