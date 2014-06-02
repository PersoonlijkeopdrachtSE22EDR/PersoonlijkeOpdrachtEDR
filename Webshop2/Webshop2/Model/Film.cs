//-----------------------------------------------------------------------
// <copyright file="Film.cs" company="EDR">
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
    /// Film is een subclass van product.
    /// </summary>
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

        public Film(string genre, string gegevensdrager, string duur, int artikelnummer, string productnaam, decimal prijs, string beschrijving, string soort)
            : base(artikelnummer, productnaam, prijs, beschrijving, soort)
        {
            this.Genre = genre;
            this.Gegevensdrager = gegevensdrager;
            this.Duur = duur;
        }
    }
}