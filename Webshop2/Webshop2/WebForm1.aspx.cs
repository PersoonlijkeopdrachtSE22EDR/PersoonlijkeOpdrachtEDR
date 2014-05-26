using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization; //voor te testen
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;


namespace Webshop2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //   // JavaScriptSerializer js = new JavaScriptSerializer();
        //   // Response.Write(js.Serialize(Account.GetAccounts()));
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            Welcome.Text = "Hello, " + Context.User.Identity.Name;
        }

        protected void Signout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Logon.aspx");
        }
    }
}