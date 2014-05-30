using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop2
{
    public partial class Bestellingen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Bestelling> Bestellingen = Bestelling.GetBestellingen((string)Session["gebruikersnaam"].ToString());

            repeaterBestelling.DataSource = Bestellingen;
            repeaterBestelling.DataBind();
        }
    }
}