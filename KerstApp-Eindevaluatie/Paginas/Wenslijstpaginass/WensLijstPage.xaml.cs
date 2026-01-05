using KerstApp_Eindevaluatie.ViewModels.Wenslijst;

namespace KerstApp_Eindevaluatie.Paginas.Wenslijstpaginass;

public partial class WensLijstPage : ContentPage
{
    public WensLijstPage(WensliijstVieuwModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}