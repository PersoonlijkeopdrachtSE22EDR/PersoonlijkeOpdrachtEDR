using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Product
    {
        public int Artikelnummer
        {
            get;
            set;
        }

        public string Productnaam
        {
            get;
            set;
        }

        public decimal Prijs
        {
            get;
            set;
        }

        public string Beschrijving
        {
            get;
            set;
        }

        public List<Reactie> Reacties
        {
            get
            {
                return Reactie.GetReactieByArtikelnummer(this.Artikelnummer);
            }
        }

        public string Soort
        {
            get;
            set;
        }

        public Product(int artikelnummer, string productnaam, decimal prijs, string beschrijving)
        {
            this.Artikelnummer = artikelnummer;
            this.Productnaam = productnaam;
            this.Prijs = prijs;
            this.Beschrijving = beschrijving;
        }

        public Product(int artikelnummer, string productnaam, decimal prijs, string beschrijving, string soort)
        {
            this.Artikelnummer = artikelnummer;
            this.Productnaam = productnaam;
            this.Prijs = prijs;
            this.Beschrijving = beschrijving;
            this.Soort = soort;
        }

        public void PlaatsReactie(Reactie reactie)
        {
            Reactie.PlaatsReactie(reactie, this);
        }
    }


}