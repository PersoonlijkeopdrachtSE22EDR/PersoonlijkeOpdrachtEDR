﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop2
{
    public partial class Product_detail : System.Web.UI.Page
    {
        Product product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["artikelnummer"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                int artikelnummer = Convert.ToInt32(Session["artikelnummer"]);
                product = Product.GetProductByArtikelnummer(artikelnummer);
                ProductnaamHeader.Text = product.Productnaam;
                LabelArtikelnummer.Text = product.Artikelnummer.ToString();
                LabelProductnaam.Text = product.Productnaam;
                LabelPrijs.Text = product.Prijs.ToString();
                LabelBeschrijving.Text = product.Beschrijving;

                List<Reactie> Reacties = Reactie.GetReactieByArtikelnummer(artikelnummer);
                if (Reacties.Count != 0)
                {
                    repeaterReactie.DataSource = Reacties;
                    repeaterReactie.DataBind();
                }
                else
                {
                    repeaterReactie.Visible = false;
                    LabelReactieleeg.Text = "Er zijn geen reacties geplaatst bij dit product.";
                }
            }
        }

        protected void ButtonBestel_Click(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Account account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                Winkelwagen winkelwagen = new Winkelwagen(account);
                winkelwagen.VoegProductToeAanWinkelwagen(product, Convert.ToInt32(TextboxHoeveelheid.Text));
                Response.Redirect("Winkelwagen.aspx");
               
            }
        }

        protected void ButtonWenslijst_Click(object sender, EventArgs e)
        {
            
        }
    }
}