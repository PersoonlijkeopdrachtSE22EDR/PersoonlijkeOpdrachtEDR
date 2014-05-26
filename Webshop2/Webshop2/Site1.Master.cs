using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Webshop2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private static string title = "Webshop -";
        public static string UpdateTitle(string toBeAddedTitle)
        {
            return title + " " + toBeAddedTitle;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogUit(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

    }
}