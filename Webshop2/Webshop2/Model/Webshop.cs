using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Model
{
    public class Webshop
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


    }
}