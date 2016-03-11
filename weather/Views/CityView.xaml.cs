using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace weather
{
	public partial class CityView : ContentPage
	{
		//HttpClient client;

		public CityView ()
		{
			//client = new HttpClient ();
			BindingContext = new GetWeatherViewModel ();
			InitializeComponent ();

			//button.Clicked += OnGetWeatherClicked;
		}

		public async void OnGetWeatherClicked(object sender, EventArgs e)
		{
			//http://api.openweathermap.org/data/2.5/weather?q=RiodeJaneiro&APPID={b30c1e0510b2400bd50eb1dea1b025cb}

		}
	}
}

