using Plugin.Connectivity;
using Plugin.Share;
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
            await Navigation.PushAsync(new ClassesPage());
        }

        private async void btnProperties_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ClassesPage());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            if (!CrossConnectivity.IsSupported)
                return;

            if (CrossConnectivity.Current.IsConnected)
            {
                var types = CrossConnectivity.Current.ConnectionTypes;
            }

            if (!CrossShare.IsSupported)
                return;

            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage()
            {
                Title = "Przepis na mięso",
                Text = "Zesraj sie do wiadeła"
            });
        }
    }
}
