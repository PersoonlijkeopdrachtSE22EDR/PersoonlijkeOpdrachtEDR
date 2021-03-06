﻿//-----------------------------------------------------------------------
// <copyright file="Bestellingen.aspx.cs" company="EDR">
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
    public partial class Bestellingen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Account account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                repeaterBestelling.DataSource = account.Bestellingen;
                repeaterBestelling.DataBind();
            }
        }
    }
}