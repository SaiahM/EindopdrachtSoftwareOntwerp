using KerstApp_Eindevaluatie.ViewModels.persoonen;

namespace KerstApp_Eindevaluatie.Paginas;

public partial class PersonenePage : ContentPage
{
	public PersonenePage(PersonenViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}