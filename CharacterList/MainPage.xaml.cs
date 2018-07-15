using System;
using Xamarin.Forms;

namespace CharacterList
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharachtersPage());
        }

        private async void btnProperties_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.CharactersListPage());
        }
    }
}
