using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Model
{
    public partial class Account
    {
        public static List<Account> GetAccounts()
        {
            List<Account> Accounts = new List<Account>();
            Database.getData("SELECT ") //NOG VERDER MAKEN
            return Accounts;
        }

        public static void VoegAccountToe(Account account)
        {

        }
    }
}