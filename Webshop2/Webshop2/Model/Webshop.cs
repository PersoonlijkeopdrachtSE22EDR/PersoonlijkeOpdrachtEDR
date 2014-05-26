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

        public bool VoegToeAccount(Account account)
        {
            if(Account.VoegAccountToe(account))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account Login(string gebruikersnaam, string wachtwoord)
        {
            Account account = Webshop.CheckLogin(gebruikersnaam, wachtwoord);
            return account;
        }


    }
}