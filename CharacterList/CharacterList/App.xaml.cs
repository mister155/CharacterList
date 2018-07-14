﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testing.Data;
using Testing.Services.Interfaces;
using Xamarin.Forms;

namespace Testing
{
	public partial class App : Application
	{
        private static LocalDB localDB;

        public static LocalDB LocalDB
        {
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var filename = fileHelper.GetLocalFilePath("app.db3");
                    localDB = new LocalDB(filename);
                }

                return localDB;
            }
        }

		public App ()
		{
			InitializeComponent();
            MainPage = new NavigationPage(new Testing.MainPage());
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
