using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Laptop : Product
    {
        public string Processor
        {
            get;
            private set;
        }

        public string RAM
        {
            get;
            set;
        }

        public string Resolutie
        {
            get;
            set;
        }

        public string HardeSchijf
        {
            get;
            set;
        }

        public string GrafischeKaart
        {
            get;
            set;
        }

        public Laptop(string processor, string ram, string resolutie, string hardeschijf, string grafischekaart, int Artikelnummer, string Productnaam, decimal Prijs, string Beschrijving, string Soort) :base (Artikelnummer, Productnaam, Prijs, Beschrijving, Soort)
        {
            this.Processor = processor;
            this.RAM = ram;
            this.Resolutie = resolutie;
            this.HardeSchijf = hardeschijf;
            this.GrafischeKaart = grafischekaart;
        }
    }
}