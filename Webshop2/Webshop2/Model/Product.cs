﻿//-----------------------------------------------------------------------
// <copyright file="Product.cs" company="EDR">
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
    /// Een product in de webshop.
    /// </summary>
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

        /// <summary>
        /// Plaatst een reactie bij het product.
        /// </summary>
        /// <param name="reactie">De reactie die wordt toegevoegd bij dit product.</param>
        public void PlaatsReactie(Reactie reactie)
        {
            Reactie.PlaatsReactie(reactie, this);
        }
    }
}