using System;
using System.Globalization;
using CharacterList.Model.Sqlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterDetailsPage : ContentPage
    {
        private readonly Character _character;
		public CharacterDetailsPage (Character character)
		{
		    _character = character;
            InitializeComponent ();

		    CharacterName.Detail = _character?.Name;
		    PlaceOfBirth.Detail = _character?.PlaceOfBirth;
		    DateOfBirth.Detail = _character?.DateOfBirth.Date.ToShortDateString();
		    Faction.Detail = _character?.Faction;
		    Race.Detail = _character?.Race;
		    MagicType.Detail = _character?.MagicType;
		    SoulColor.Detail = _character?.SoulColor;
		    Height.Detail = _character?.Height.ToString();
		    HairColor.Detail = _character?.HairColor;
		    EyesColor.Detail = _character?.EyesColor;
		}

	    private async void Button_Clicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new AddItemPage(_character));
	    }
    }
}