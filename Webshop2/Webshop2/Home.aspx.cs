//-----------------------------------------------------------------------
// <copyright file="Home.aspx.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop2
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Webshop webshop = new Webshop();
            listviewProducten.DataSource = webshop.Producten;
            listviewProducten.DataBind();
        }

        protected void Product_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            Session["artikelnummer"] = Convert.ToInt32(button.CommandArgument);

            Response.Redirect("Product_detail.aspx");
        }
    }
}