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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] != null)
            {
                Account account = Account.GetAccountByGebruikersnaam(Context.User.Identity.Name);
                List<Productregel> productregels =  Productregel.GetProductregels(account);
                foreach (Productregel productregel in productregels)
                {
                    TableRow tr = new TableRow();
                    ProductenTabel.Rows.Add(tr);

                    TableCell tc = new TableCell();
                    tr.Cells.Add(tc);
                    tc.Text = productregel.ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Bestel_Click(object sender, EventArgs e)
        {

        }
    }
}