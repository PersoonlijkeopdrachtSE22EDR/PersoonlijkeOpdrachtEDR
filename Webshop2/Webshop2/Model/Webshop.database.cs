//-----------------------------------------------------------------------
// <copyright file="Webshop.database.cs" company="EDR">
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
    /// <summary>
    /// De database class die zorgt voor alle database gerelateerde acties voor Webshop
    /// </summary>
    public partial class Webshop
    {
        /// <summary>
        /// Deze methode checkt of de gebruiker geregistreerd staat in de database.
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        /// <param name="wachtwoord"></param>
        /// <returns></returns>
        public static Account CheckLogin(string gebruikersnaam, string wachtwoord)
        {
            OracleCommand cmd = new OracleCommand("SELECT EMAILADRES, WACHTWOORD, NAAM, ADRES, TELEFOONNUMMER, WOONPLAATS FROM ACCOUNTS WHERE EMAILADRES = :email AND WACHTWOORD = :wachtwoord");
            cmd.Parameters.Add(new OracleParameter("email", gebruikersnaam.ToLower()));
            cmd.Parameters.Add(new OracleParameter("wachtwoord", wachtwoord));
            DataTable dt = Database.GetDataParameters(cmd);

            foreach(DataRow row in dt.Rows)
            {
                string email = row["EMAILADRES"].ToString();
                string returnwachtwoord = row["WACHTWOORD"].ToString();
                string naam = row["NAAM"].ToString();
                string adres = row["ADRES"].ToString();
                string telefoonnummer = row["TELEFOONNUMMER"].ToString();
                string woonplaats = row["WOONPLAATS"].ToString();
                Account account = new Account(email, returnwachtwoord, naam, adres, telefoonnummer, woonplaats);
                return account;
            }
            return null;

        }
    }
}