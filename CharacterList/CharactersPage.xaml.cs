using CharacterList.Model.Sqlite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharachtersPage : ContentPage
	{
		public CharachtersPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LvItems.ItemsSource = await App.LocalDb.GetItems<Character>();
            LvItems.ItemTapped -= LvItems_ItemTapped;
            LvItems.ItemTapped += LvItems_ItemTapped;
        }

        private async void LvItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedClass = (Character)e.Item;
            await Navigation.PushAsync(new CharacterDetailsPage(selectedClass));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCharacterPage());
        }
    }
}