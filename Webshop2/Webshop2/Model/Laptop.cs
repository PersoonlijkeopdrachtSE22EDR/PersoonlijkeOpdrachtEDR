//-----------------------------------------------------------------------
// <copyright file="Laptop.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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

        public Laptop(string processor, string ram, string resolutie, string hardeschijf, string grafischekaart, int artikelnummer, string productnaam, decimal prijs, string beschrijving, string soort) :base (artikelnummer, productnaam, prijs, beschrijving, soort)
        {
            this.Processor = processor;
            this.RAM = ram;
            this.Resolutie = resolutie;
            this.HardeSchijf = hardeschijf;
            this.GrafischeKaart = grafischekaart;
        }
    }
}