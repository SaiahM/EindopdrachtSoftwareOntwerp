using KerstApp_Eindevaluatie.ViewModels.Kertslijst;

namespace KerstApp_Eindevaluatie.Paginas.kerstlijst;

public partial class KerstlijstDetailPage : ContentPage
{
    public KerstlijstDetailPage(KerstlijstDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}