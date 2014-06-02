//-----------------------------------------------------------------------
// <copyright file="Wasmachine.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    /// <summary>
    /// Wasmachine is een subclass van Product.
    /// </summary>
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

        public Wasmachine(string energieklasse, string toerental, string vulgewicht, int artikelnummer, string productnaam, decimal prijs, string beschrijving, string soort)
            : base(artikelnummer, productnaam, prijs, beschrijving, soort)
        {
            this.Energieklasse = energieklasse;
            this.Toerental = toerental;
            this.Vulgewicht = vulgewicht;
        }
    }
}