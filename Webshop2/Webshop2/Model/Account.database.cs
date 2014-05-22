using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Webshop.Model
{
    public partial class Account
    {
        public static List<Account> GetAccounts()
        {
            List<Account> Accounts = new List<Account>();
            DataTable dt = Database.getData("SELECT ");//NOG VERDER MAKEN
            foreach(DataRow row in dt.Rows)
            {

            }
            return Accounts;
        }

        public static void VoegAccountToe(Account account)
        {

        }
    }
}