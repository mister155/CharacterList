using CharacterList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharactersListPage : ContentPage
	{
		public CharactersListPage()
		{
			InitializeComponent ();
            BindingContext = new CharacterViewModel();
        }
	}
}