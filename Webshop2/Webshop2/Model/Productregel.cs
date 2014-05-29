using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Productregel
    {
        public Product Product
        {
            get;
            set;
        }

        public int Hoeveelheid
        {
            get;
            set;
        }

        public decimal Prijs
        {
            get;
            set;

        }

        public Productregel(Product product, int hoeveelheid)
        {
            this.Product = product;
            this.Hoeveelheid = hoeveelheid;
            this.Prijs = BerekenPrijs(hoeveelheid, product.Prijs);
        }

        public decimal BerekenPrijs(int hoeveelheid, decimal prijs)
        {
            decimal totaalPrijs = hoeveelheid * prijs;
            return totaalPrijs;
        }

        public override string ToString()
        {
            string productregelstring;
            return productregelstring = "Artikelnummer: " + Product.Artikelnummer.ToString() + ", Productnaam: " + Product.Productnaam + ", Prijs: €" + Product.Prijs.ToString() + ", Hoeveelheid: " + Hoeveelheid.ToString() + ", Totaalprijs: " + BerekenPrijs(Hoeveelheid, Product.Prijs).ToString();
        }
    }
}