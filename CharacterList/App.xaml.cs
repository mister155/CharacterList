using CharacterList.Data;
using CharacterList.Services.Interfaces;
using Xamarin.Forms;

namespace CharacterList
{
    public partial class App : Application
	{
        private static LocalDb _localDb;

        public static LocalDb LocalDb
        {
            get
            {
                if (_localDb == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var filename = fileHelper.GetLocalFilePath("app.db3");
                    _localDb = new LocalDb(filename);
                }

                return _localDb;
            }
        }

		public App ()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
