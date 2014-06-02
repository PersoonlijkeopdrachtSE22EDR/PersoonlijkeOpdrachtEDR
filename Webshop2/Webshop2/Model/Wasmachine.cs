using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Wasmachine : Product
    {
        public string Energieklasse
        {
            get;
            set;
        }

        public string Toerental
        {
            get;
            set;
        }

        public string Vulgewicht 
        {
            get;
            set;
        }

        public Wasmachine(string energieklasse, string toerental, string vulgewicht, int Artikelnummer, string Productnaam, decimal Prijs, string Beschrijving, string Soort)
            : base(Artikelnummer, Productnaam, Prijs, Beschrijving, Soort)
        {
            this.Energieklasse = energieklasse;
            this.Toerental = toerental;
            this.Vulgewicht = vulgewicht;
        }
    }
}