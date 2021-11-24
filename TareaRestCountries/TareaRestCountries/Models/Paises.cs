using System;
using System.Collections.Generic;
using System.Text;

namespace TareaRestCountries.Models
{
    public class Paises
    {

        public class Language
        {
            public string name { get; set; }
        }
        public class Currency
        {
            public string name { get; set; }
        }
        public class Flags
        {
            public string png { get; set; }
        }
        public string name { get; set; }
        public string capital { get; set; }
        public Flags flags { get; set; }
        public string population { get; set; }
        public List<Currency> currencies { get; set; }
        public List<Language> languages { get; set; }

        public IList<double> latlng { get; set; }
    }
}
