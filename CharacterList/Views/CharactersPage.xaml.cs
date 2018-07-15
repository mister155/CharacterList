using CharacterList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharactersPage : ContentPage
	{
		public CharactersPage()
		{
			InitializeComponent ();
            BindingContext = new CharacterViewModel();
        }
	}
}