using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Webshop2
{
    public partial class Wenslijst1 : System.Web.UI.Page
    {
        Account account;
        Wenslijst wenslijst;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                wenslijst = new Wenslijst(account);

                if(wenslijst.Producten.Count == 0)
                {
                    TableRow RowLeeg = new TableRow();
                    TabelWenslijst.Rows.Add(RowLeeg);

                    TableCell CellLeeg = new TableCell();
                    RowLeeg.Cells.Add(CellLeeg);
                    CellLeeg.Text = "Geen producten in Uw wenslijst.";
                }

                foreach(Product product in wenslijst.Producten)
                {
                    TableRow tr = new TableRow();
                    TabelWenslijst.Rows.Add(tr);

                    TableCell tcArtikelnummer = new TableCell();
                    tr.Cells.Add(tcArtikelnummer);
                    tcArtikelnummer.CssClass = "WenslijstCell";
                    tcArtikelnummer.Text = "Artikelnummer: " + product.Artikelnummer.ToString();

                    TableCell tcProductnaam = new TableCell();
                    tr.Cells.Add(tcProductnaam);
                    tcProductnaam.CssClass = "WenslijstCell";
                    tcProductnaam.Text = "Productnaam: " + product.Productnaam;

                    TableCell tcPrijs = new TableCell();
                    tr.Cells.Add(tcPrijs);
                    tcPrijs.CssClass = "WenslijstCell";
                    tcPrijs.Text = "Prijs: €" + product.Prijs.ToString();
                }

            }
        }

        protected void LeegWenslijst_Click(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                wenslijst = new Wenslijst(account);
                wenslijst.MaakWenslijstLeeg();
                Response.Redirect("Wenslijst.aspx");
            }
            

        }
    }
}