//-----------------------------------------------------------------------
// <copyright file="Wenslijst.cs" company="EDR">
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
    /// De wenslijst van een account.
    /// </summary>
    public partial class Wenslijst
    {
        public Account Account
        {
            get;
            set;
        }

        public List<Product> Producten
        {
            get
            {
                return Product.GetProductenByEmail(Account.Gebruikersnaam);
            }
        }

        public Wenslijst(Account account)
        {
            this.Account = account;
        }

        /// <summary>
        /// Voegt een product toe aan de wenslijst
        /// </summary>
        /// <param name="product">Het product dat toegevoegd wordt</param>
        public void VoegToeProduct(Product product)
        {
            Wenslijst.VoegToeProduct(Account, product);
            this.Producten.Add(product);
        }

        /// <summary>
        /// Leegt de wenslijst.
        /// </summary>
        public void MaakWenslijstLeeg()
        {
            Wenslijst.VerwijderProducten(Account.Gebruikersnaam);
            this.Producten.Clear();
        }
    }
}