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

        public void VoegToeProduct(Product product)
        {
            Wenslijst.VoegToeProduct(Account, product);
            this.Producten.Add(product);
        }

        public void VerwijderProduct(Product product)
        {
            //database
            this.Producten.Remove(product);
        }

        public void MaakWenslijstLeeg()
        {
            Wenslijst.VerwijderProducten(Account.Gebruikersnaam);
            this.Producten.Clear();
        }
    }
}