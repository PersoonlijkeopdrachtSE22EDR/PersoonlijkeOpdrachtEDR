using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Webshop2
{
    public partial class Webshop
    {
        public static Account CheckLogin(string gebruikersnaam, string wachtwoord)
        {
            DataTable dt = Database.getData("SELECT EMAILADRES, WACHTWOORD FROM ACCOUNTS WHERE EMAILADRES = @email AND WACHTWOORD = @wachtwoord");
            foreach(DataRow row in dt.Rows)
            {
                
            }
        }
    }
}