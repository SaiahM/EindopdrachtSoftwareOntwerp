using KerstApp_Eindevaluatie.ViewModels.Kertslijst;

namespace KerstApp_Eindevaluatie.Paginas.kerstlijst;

public partial class KerstlijstPage : ContentPage
{
    public KerstlijstPage(KerstlijstViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}