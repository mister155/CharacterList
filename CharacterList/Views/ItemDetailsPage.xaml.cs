
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailsPage : ContentPage
	{
		public ItemDetailsPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.ItemDetailsViewModel();
		}
	}
}