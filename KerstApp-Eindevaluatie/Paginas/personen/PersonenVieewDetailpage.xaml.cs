using KerstApp_Eindevaluatie.ViewModels.persoonen;

namespace KerstApp_Eindevaluatie.Paginas.personen;

public partial class PersonenVieewDetailpage : ContentPage
{
	public PersonenVieewDetailpage(PersonenDetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    
}