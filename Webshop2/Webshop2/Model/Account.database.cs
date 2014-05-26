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
            DataTable dt = Database.getData("SELECT EMAILADRES as email, WACHTWOORD, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS FROM ACCOUNTS");
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

        public static bool VoegAccountToe(Account account)
        {
            OracleCommand checkCmd = new OracleCommand("SELECT EMAILADRES, WACHTWOORD FROM ACCOUNTS WHERE EMAILADRES = :email");
            checkCmd.Parameters.Add(new OracleParameter("email", account.Gebruikersnaam));
            DataTable dt = Database.getDataParameters(checkCmd);
            if(dt.Rows.Count > 0)
            {
                return false;
            }
            else 
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO ACCOUNTS (EMAILADRES, WACHTWOORD, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS) VALUES(:email, :wachtwoord, :naam, :adres, :telefoonnummer, :woonplaats)");
                cmd.Parameters.Add("email", account.Gebruikersnaam);
                cmd.Parameters.Add("wachtwoord", account.wachtwoord);
                cmd.Parameters.Add("naam", account.Naam);
                cmd.Parameters.Add("adres", account.Adres);
                cmd.Parameters.Add("telefoonnummer", account.Telefoonnummer);
                cmd.Parameters.Add("woonplaats", account.Woonplaats);
                Database.InsertData(cmd);
                return true;
            }

            
        }
    }
}