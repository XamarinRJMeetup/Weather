using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using PropertyChanged;

namespace weather
{
	[ImplementPropertyChanged]
	public class GetWeatherViewModel : BaseViewModel
	{
		//HttpClient client;

		private string wind;
		private string city;
		private string text;
		private string currentCityName;

		public string CurrentCityName {
			get {
				return currentCityName;
			}
			set {
				if (currentCityName != value) {
					currentCityName = value;
					Notify("CurrentCityName");
					//ExecuteLoadContasCommand ();
				}
			}
		}

		public ObservableCollection<Example> listWind { get; set; }


		//public ObservableCollection<RootObject> ListCities { get; set; }

		public ICommand SearchCommand { get; set; }


		public GetWeatherViewModel ()
		{
			listWind  = new ObservableCollection<Example>();
			this.SearchCommand = new Command (GetDataAsync);
		
			//ListCities = new ObservableCollection<RootObject>();
			//GetDataAsync ();

		}
			
		public async void GetDataAsync ()
		{
			// RestUrl = api.openweathermap.org/data/2.5/weather?q=

			var client = new HttpClient ();

			//string uriPar = $"{Constants.RestUrl}/RiodeJaneiro&APPID={Constants.APIWeatherKey}";

			string uriPar = $"{Constants.RestUrl}/{currentCityName}&APPID={Constants.APIWeatherKey}";
		
			var uri = new Uri (uriPar);

			//	var uri = new Uri (string.Format (Constants.RestUrl , string.Empty));
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				var items = JsonConvert.DeserializeObject <RootObject> (content);

				wind = (items.wind.speed * 3.6).ToString ()  ; // Transform in Km/h
				city = items.name;
				text = $"({city} - {wind} km/h)";

				Example ex = new Example (){
					speed = text
				};

				listWind.Add (ex);
			}

		}
	}
}

