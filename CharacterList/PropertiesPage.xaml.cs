using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterList.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PropertiesPage : ContentPage
	{
		public PropertiesPage ()
		{
			InitializeComponent ();
            if (Properties.AppProperties.ContainsKey("webUrl"))
                lblProp.Text = Properties.AppProperties["webUrl"].ToString();
		}
	}
}