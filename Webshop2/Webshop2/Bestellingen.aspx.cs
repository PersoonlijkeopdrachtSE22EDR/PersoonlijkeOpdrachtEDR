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
                List<Bestelling> bestellingen = Bestelling.GetBestellingen((string)Session["gebruikersnaam"]);
                repeaterBestelling.DataSource = bestellingen;
                repeaterBestelling.DataBind();
            }
        }
    }
}