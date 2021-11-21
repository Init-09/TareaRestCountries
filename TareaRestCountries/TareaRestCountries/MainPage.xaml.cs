using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaRestCountries.Models;
using Xamarin.Forms;

namespace TareaRestCountries
{
    public partial class MainPage : ContentPage
    {
        private string url = "https://restcountries.com/v2/all";
        HttpClient cliente = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            var countries = GetCountry();
            pickercountry.ItemsSource = countries;
        }
        private List<string> GetCountry()
        {
            return new List<string>
            {
                "EU",
                "EFTA",
                "CARICOM",
                "PA",
                "AU",
                "USAN",
                "EEU",
                "AL",
                "ASEAN",
                "CAIS",
                "CEFTA",
                "NAFTA",
                "SAARC"
            };
        }
        protected override async void OnAppearing()
        {
          string contenido = await cliente.GetStringAsync(url);
          IEnumerable<Paises> lista = JsonConvert.DeserializeObject<IEnumerable<Paises>>(contenido);
          ltusuario.ItemsSource = new ObservableCollection<Paises>(lista);
          base.OnAppearing();
        }
        private async void pickercountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickercountry.SelectedIndex == -1)
            {
                _ = DisplayAlert("Country", "Please select", "Ok");
                return;
            }
            string country = pickercountry.SelectedItem as string;
            //_ = DisplayAlert("Country", country + " select ", "Ok");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://restcountries.com/v2/regionalbloc/" + country);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Paises>>(content);

                ltusuario.ItemsSource = resultado;
            }
        }
        private async void ltusuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var paises = e.SelectedItem as Paises;
            await Navigation.PushAsync(new DetailsPage(paises.flags.png, paises.name, paises.capital, paises.population, paises.currencies[0].name, paises.languages[0].name));
        }        
    }
}
