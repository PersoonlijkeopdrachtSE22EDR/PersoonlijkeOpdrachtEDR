//-----------------------------------------------------------------------
// <copyright file="Winkelwagen.cs" company="EDR">
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
    /// De winkelwagen
    /// </summary>
    public class Winkelwagen
    {
        public Account Account
        {
            get;
            set;
        }

        public decimal Prijs
        {
            get;
            set;
        }

        public List<Productregel> Productregels
        {
            get;
            set;
        }

        public Winkelwagen(Account account)
        {
            this.Account = account;
        }

        public Winkelwagen(Account account, List<Productregel> productregels)
        {
            this.Account = account;
            this.Productregels = productregels;
            this.Prijs = this.BerekenPrijs();
        }

        /// <summary>
        /// Voegt een product toe aan de winkelwagen
        /// </summary>
        /// <param name="product">Het product dat toegevoegd wordt</param>
        /// <param name="hoeveelheid">Het aantal producten</param>
        public void VoegToeProduct(Product product, int hoeveelheid)
        {
            if(this.Productregels == null)
            {
                this.Productregels = new List<Productregel>();
            }
            Productregel productregel = new Productregel(product, hoeveelheid);
            Productregel.VoegProductregelToe(Account, productregel);
            this.Productregels.Add(productregel);
        }

        /// <summary>
        /// Leegt de winkelwagen.
        /// </summary>
        public void MaakWinkelwagenleeg()
        {
            Productregel.VerwijderProductregels(Account.Gebruikersnaam);
            this.Productregels.Clear();
        }

        /// <summary>
        /// Berekent de totaalprijs van de winkelwagen.
        /// </summary>
        /// <returns></returns>
        public decimal BerekenPrijs()
        {
            foreach(Productregel productregel in this.Productregels)
            {
                this.Prijs += productregel.Prijs;
            }

            return this.Prijs;
        }
    }
}