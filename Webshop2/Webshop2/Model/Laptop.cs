using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public class Laptop : Product
    {
        public string Processor
        {
            get;
            private set;
        }

        public string RAM
        {
            get;
            private set;
        }

        public string Resolutie
        {
            get;
            private set;
        }

        public string HardeSchijf
        {
            get;
            private set;
        }

        public string GrafischeKaart
        {
            get;
            private set;
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