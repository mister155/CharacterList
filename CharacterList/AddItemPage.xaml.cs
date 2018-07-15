using CharacterList.Model.Sqlite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
        private readonly Character _class;
		public AddItemPage(Character selectedClass)
		{
		    _class = selectedClass;
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EntryItemName == null || string.IsNullOrWhiteSpace(EntryItemName.Text))
            {
                await DisplayAlert("Error", "Item has to have name", "OK");
                return;
            }

            var itemName = EntryItemName?.Text;
            var itemType = EntryItemType.SelectedItem?.ToString();
            var specialTraits = EntrySpecialTraits?.Text;
            var descritpion = EntryDescription?.Text;

            var newStudent = new Item
            {
                ItemName = itemName,
                ItemType = itemType,
                SpecialTraits = specialTraits,
                Description = descritpion,
                CharacterId= _class.Id
            };

            await App.LocalDb.SaveItem(newStudent);
            await DisplayAlert("Success", "Data has been saved", "OK");
            await Navigation.PopAsync();
        }
    }
}