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
            LblItem.Text = $"Editing: {item.ItemName}" + item.ItemType == "Other" || item.ItemType =="Item" ? "" : item.ItemType;
		    EntryItemName.Text = item.ItemName;
            EntryItemType.SelectedItem = item.ItemType;
		    EntrySpecialTraits.Text = item.SpecialTraits;
		    EntryDescription.Text = item.Description;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _item.ItemName = EntryItemName.Text;
            _item.ItemType = EntryItemType.SelectedItem.ToString();
            _item.SpecialTraits = EntrySpecialTraits.Text;
            _item.Description = EntryDescription.Text;

            await App.LocalDb.SaveItem(_item);
            await DisplayAlert("OK", "Changes has been saved", "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (!await DisplayAlert("Warning", "Do you really want delete?", "YES", "NO")) return;
            await App.LocalDb.DeleteItem(_item);
            await Navigation.PopAsync();
        }
    }
}