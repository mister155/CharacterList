using CharacterList.Model.Sqlite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        private readonly Character _character;
		public ItemsPage(Character selectedCharacter)
		{
            _character = selectedCharacter;
			InitializeComponent ();

		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LvItems.ItemsSource = await App.LocalDb.GetItemsByClassId(_character.ID);
            LvItems.ItemTapped -= LvItems_ItemTapped;
            LvItems.ItemTapped += LvItems_ItemTapped;
        }

        private async void LvItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Item)e.Item;
            await Navigation.PushAsync(new EditItemPage(item));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage(_character));
        }
    }
}