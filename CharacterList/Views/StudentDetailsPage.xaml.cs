﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentDetailsPage : ContentPage
	{
		public StudentDetailsPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.StudentDetailsViewModel();
		}
	}
}