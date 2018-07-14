﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClassesPage : ContentPage
	{
		public ClassesPage()
		{
			InitializeComponent ();
            BindingContext = new ClassesViewModel();
        }
	}
}