using CharacterList.Model.Sqlite;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCharacterPage : ContentPage
    {
		public AddCharacterPage ()
		{
			InitializeComponent ();
		    EntryBirthDate.MinimumDate = DateTime.MinValue;
		    EntryBirthDate.MaximumDate = DateTime.MaxValue;
		    EntryBirthDate.Date = DateTime.Now;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EntryName == null || string.IsNullOrWhiteSpace(EntryName.Text))
            {
                await DisplayAlert("Error", "Character needs a name", "OK");
                return;
            }

            int.TryParse(EntryHeight.Text, out var height);

            var magicType = EntryMagicType?.Text;
            var soulColor = EntrySoulColor?.Text;


            var newCharacter = new Character
            {
                Name = EntryName?.Text,
                PlaceOfBirth = EntryBirthPlace?.Text,
                DateOfBirth = EntryBirthDate.Date.Date,
                Faction = EntryFaction?.Text,
                Race = EntryRace?.Text,
                MagicType = magicType == null ? "None" : EntryMagicType.Text,
                SoulColor = soulColor == null ? "White" : EntrySoulColor.Text,
                Height = height,
                HairColor = EntryHairColor?.Text,
                EyesColor = EntryEyesColor?.Text
            };

            await App.LocalDb.SaveItem(newCharacter);
            await DisplayAlert("Success", "Data has been saved", "OK");
            await Navigation.PopAsync();
        }
    }
}