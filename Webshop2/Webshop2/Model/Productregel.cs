using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public class Productregel
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

        public Productregel()
        {
        }

        public void VoegToeProduct(Product product)
        {
            this.Product = product;
        }

        public decimal BerekenPrijs(int hoeveelheid, decimal prijs)
        {
            decimal totaalPrijs = hoeveelheid * prijs;
            return totaalPrijs;
        }
    }
}