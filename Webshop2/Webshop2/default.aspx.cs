﻿//-----------------------------------------------------------------------
// <copyright file="default.aspx.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Webshop2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = Site1.UpdateTitle("Account");
            Webshop webshop = new Webshop();
            Account account = Account.GetAccountByGebruikersnaam(Context.User.Identity.Name);
            if (account != null)
            {
                LabelRegistreerEmail.Text = account.Gebruikersnaam;
                LabelRegistreerNaam.Text = account.Naam;
                LabelRegistreerAdres.Text = account.Adres;
                LabelRegistreerTelefoonnummer.Text = account.Telefoonnummer;
                LabelRegistreerWoonplaats.Text = account.Woonplaats;
                Session["gebruikersnaam"] = account.Gebruikersnaam;
            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}