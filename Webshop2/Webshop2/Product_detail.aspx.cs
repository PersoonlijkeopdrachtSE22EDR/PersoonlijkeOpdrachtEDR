using System;
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
                Bestelling bestelling = new Bestelling(1, (string)Session["gebruikersnaam"].ToString(), DateTime.Today.ToString());
                bestelling.PlaatsBestelling((string)Session["gebruikersnaam"].ToString(), product);
            }
        }
    }
}