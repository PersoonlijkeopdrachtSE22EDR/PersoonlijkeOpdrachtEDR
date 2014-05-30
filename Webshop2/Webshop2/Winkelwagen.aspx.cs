using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop2
{
    public partial class Winkelwagen1 : System.Web.UI.Page
    {
        List<Productregel> productregels;
        Account account;
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal prijs = 0;
            if (Session["gebruikersnaam"] != null)
            {
                account = Account.GetAccountByGebruikersnaam(Context.User.Identity.Name);
                productregels =  Productregel.GetProductregels(account);
                foreach (Productregel productregel in productregels)
                {
                    TableRow tr = new TableRow();
                    ProductenTabel.Rows.Add(tr);

                    TableCell tc = new TableCell();
                    tr.Cells.Add(tc);
                    tc.Text = productregel.ToString();
                    prijs += productregel.Prijs;
                }
                labelFooter.Text = "Totaalprijs: €" + prijs.ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Bestel_Click(object sender, EventArgs e)
        {
           // Bestelling bestelling = new Bestelling(1, (string)Session["gebruikersnaam"].ToString(), DateTime.Today.ToString());
            Winkelwagen winkelwagen = new Winkelwagen(account);
            winkelwagen.Productregels = productregels;
            Bestelling bestelling = Bestelling.VoegToeBestelling(winkelwagen);
        }
    }
}