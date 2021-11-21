using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareaRestCountries.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaRestCountries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        private string png;
        public string name;
        private string capital;
        private string population;
        private List<Paises.Currency> currencies;
        private List<Paises.Language> languages;
        HttpClient cliente = new HttpClient();

        public DetailsPage(string img, string name, string capital, string poblacion, string moneda, string lengua )
        {

            InitializeComponent();
            NAME.Text = name;
            IMG.Source = new UriImageSource()
            {
                Uri = new Uri(img)
            };
            CAPITAL.Text = "Capital es: "+capital;
            POBLA.Text = "Con una poblacion de: " + poblacion+" habitantes.";
            MONEDA.Text= "Moneda " + moneda;
            LENGUA.Text = "Lenguajes " + lengua;
        }
       
        public DetailsPage(string png, string name, string capital, string population, List<Paises.Currency> currencies, List<Paises.Language> languages)
        {
            this.png = png;
            this.name = name;
            this.capital = capital;
            this.population = population;
            this.currencies = currencies;
            this.languages = languages;
        }
    }
}