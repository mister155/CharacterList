using CharacterList.Model.Sqlite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditItemPage : ContentPage
	{
        private readonly Item _item;
		public EditItemPage (Item item)
		{
            _item = item;
			InitializeComponent ();
            LblItem.Text = $"Editing: {item.ItemName} {item.ItemType}";
            EntryItemType.Text = item.ItemType;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var itemType = EntryItemType.Text;

            _item.ItemType = itemType;

            await App.LocalDb.SaveItem(_item);
            await DisplayAlert("OK", "Changes has been saved", "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Do you really want delete?", "YES", "NO"))
            {
                await App.LocalDb.DeleteItem(_item);
                await Navigation.PopAsync();
            }
        }
    }
}