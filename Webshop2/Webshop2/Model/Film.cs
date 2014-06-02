using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Film : Product
    {
        public string Genre
        {
            get;
            set;
        }

        public string Gegevensdrager
        {
            get;
            set;
        }

        public string Duur
        {
            get;
            set;
        }

        public Film(string genre, string gegevensdrager, string duur, int Artikelnummer, string Productnaam, decimal Prijs, string Beschrijving, string Soort)
            : base(Artikelnummer, Productnaam, Prijs, Beschrijving, Soort)
        {
            this.Genre = genre;
            this.Gegevensdrager = gegevensdrager;
            this.Duur = duur;
        }
    }
}