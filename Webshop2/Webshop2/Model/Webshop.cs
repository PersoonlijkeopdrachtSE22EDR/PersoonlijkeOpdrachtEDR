//-----------------------------------------------------------------------
// <copyright file="Webshop.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Webshop
    {
        public List<Product> Producten
        {
            get
            {
                return Product.GetProducten();
            }
        }

        public bool VoegToeAccount(Account account)
        {
            if(Account.VoegAccountToe(account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}