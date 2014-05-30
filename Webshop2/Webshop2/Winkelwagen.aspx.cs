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
        Winkelwagen winkelwagen;
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal prijs = 0;
            if (Session["gebruikersnaam"] != null)
            {
                account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                productregels =  Productregel.GetProductregels(account);
                if(productregels.Count == 0)
                {
                    TableRow RowLeeg = new TableRow();
                    ProductenTabel.Rows.Add(RowLeeg);

                    TableCell CellLeeg = new TableCell();
                    RowLeeg.Cells.Add(CellLeeg);
                    CellLeeg.Text = "Geen producten in winkelwagen";
                }
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
            winkelwagen = new Winkelwagen(account);
            winkelwagen.Productregels = productregels;
            if(winkelwagen.Productregels.Count != 0)
            {
                Bestelling bestelling = Bestelling.VoegToeBestelling(winkelwagen);
                bestelling.PlaatsBestelling(bestelling);
                Response.Redirect("Winkelwagen.aspx");
            }
        }

        protected void LeegWinkelwagen_CLick(object sender, EventArgs e)
        {
            winkelwagen = new Winkelwagen(account);
            winkelwagen.Productregels = productregels;
            winkelwagen.MaakWinkelwagenleeg();
            Response.Redirect("Winkelwagen.aspx");
        }
    }
}