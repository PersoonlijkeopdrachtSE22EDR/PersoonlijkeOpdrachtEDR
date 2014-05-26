using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Webshop
    {
        public List<Account> Accounts
        {
            get
            {
                return Account.GetAccounts();
            }
        }
        public List<Product> Producten
        {
            get
            {
                return Product.GetProducten();
            }
        }

        public void VoegToeAccount(Account account)
        {
            Account.VoegAccountToe(account);
        }

        public Account Login(string gebruikersnaam, string wachtwoord)
        {
            Account account = Webshop.CheckLogin(gebruikersnaam, wachtwoord);
            return Account;
        }


    }
}