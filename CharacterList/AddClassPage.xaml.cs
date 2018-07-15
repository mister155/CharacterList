using CharacterList.Model.Sqlite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClassPage : ContentPage
	{
		public AddClassPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entryName == null || string.IsNullOrWhiteSpace(entryName.Text))
            {
                await DisplayAlert("Error", "Character needs a name", "OK");
                return;
            }

            var className = entryName.Text;

            var newClass = new Class { Name = className };

            await App.LocalDb.SaveItem(newClass);
            await DisplayAlert("Success", "Data has been saved", "OK");
            await Navigation.PopAsync();
        }
    }
}