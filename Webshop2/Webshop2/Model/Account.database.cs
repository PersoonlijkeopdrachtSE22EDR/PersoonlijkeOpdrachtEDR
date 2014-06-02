//-----------------------------------------------------------------------
// <copyright file="Account.database.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Webshop2
{
    public partial class Account
    {
        public static bool VoegAccountToe(Account account)
        {
            OracleCommand checkCmd = new OracleCommand("SELECT EMAILADRES, WACHTWOORD FROM ACCOUNTS WHERE EMAILADRES = :email");
            checkCmd.Parameters.Add(new OracleParameter("email", account.Gebruikersnaam.ToLower()));
            DataTable dt = Database.GetDataParameters(checkCmd);
            if(dt.Rows.Count > 0)
            {
                return false;
            }
            else 
            {
                OracleCommand cmd = new OracleCommand("INSERT INTO ACCOUNTS (EMAILADRES, WACHTWOORD, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS) VALUES(:email, :wachtwoord, :naam, :adres, :telefoonnummer, :woonplaats)");
                cmd.Parameters.Add("email", account.Gebruikersnaam.ToLower());
                cmd.Parameters.Add("wachtwoord", account.wachtwoord);
                cmd.Parameters.Add("naam", account.Naam);
                cmd.Parameters.Add("adres", account.Adres);
                cmd.Parameters.Add("telefoonnummer", account.Telefoonnummer);
                cmd.Parameters.Add("woonplaats", account.Woonplaats);
                Database.InsertData(cmd);
                return true;
            }
        }

        public static Account GetAccountByGebruikersnaam(string gebruikersnaam)
        {
            OracleCommand getCmd = new OracleCommand("SELECT EMAILADRES, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS FROM ACCOUNTS WHERE EMAILADRES = :email");
            getCmd.Parameters.Add(new OracleParameter("email", gebruikersnaam.ToLower()));
            DataTable dt = Database.GetDataParameters(getCmd);
            Account account;
            foreach(DataRow row in dt.Rows)
            {
                account = new Account(row["EMAILADRES"].ToString(), row["NAAM"].ToString(), row["ADRES"].ToString(), row["TELEFOONNUMMER"].ToString(), row["WOONPLAATS"].ToString());
                return account;
            }
            return null;
        }
    }
}