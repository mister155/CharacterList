using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterList.Model.Sqlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClassesPage : ContentPage
	{
		public ClassesPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LvItems.ItemsSource = await App.LocalDb.GetItems<Class>();
            LvItems.ItemTapped -= LvItems_ItemTapped;
            LvItems.ItemTapped += LvItems_ItemTapped;
        }

        private async void LvItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedClass = (Class)e.Item;
            await Navigation.PushAsync(new StudentsPage(selectedClass));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClassPage());
        }
    }
}