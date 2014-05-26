using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Webshop2
{
    public partial class Account
    {
        public static List<Account> GetAccounts()
        {
            List<Account> Accounts = new List<Account>();
            DataTable dt = Database.getData("SELECT EMAILADRES as email, WACHTWOORD, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS FROM ACCOUNTS");//NOG VERDER MAKEN
            foreach(DataRow row in dt.Rows)
            {
                string email = row["email"].ToString();
                string wachtwoord = row["WACHTWOORD"].ToString();
                string naam = row["NAAM"].ToString();
                string adres = row["ADRES"].ToString();
                string telefoonnummer = row["TELEFOONNUMMER"].ToString();
                string woonplaats = row["WOONPLAATS"].ToString();

                Account account = new Account(email, wachtwoord, naam, adres, telefoonnummer, woonplaats);
                Accounts.Add(account);
            }
            return Accounts;
        }

        public static void VoegAccountToe(Account account)
        {

        }
    }
}