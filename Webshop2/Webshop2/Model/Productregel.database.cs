//-----------------------------------------------------------------------
// <copyright file="Productregel.database.cs" company="EDR">
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
    /// De database class die zorgt voor alle database gerelateerde acties voor productregel
    /// </summary>
    public partial class Productregel
    {
        /// <summary>
        /// Voegt een productregel toe aan de database
        /// </summary>
        /// <param name="account"></param>
        /// <param name="productregel"></param>
        public static void VoegProductregelToe(Account account, Productregel productregel)
        {
            bool nieuw = true;
            OracleCommand checkCmd = new OracleCommand("SELECT EMAILADRES, ARTIKELNUMMER FROM WINKELWAGEN WHERE EMAILADRES = :email AND ARTIKELNUMMER = :artikelnummer");
            checkCmd.Parameters.Add("email", account.Gebruikersnaam);
            checkCmd.Parameters.Add("artikelnummer", productregel.Product.Artikelnummer);
            DataTable dt = Database.GetDataParameters(checkCmd);
            foreach (DataRow row in dt.Rows)
            {
                if (account.Gebruikersnaam == row["EMAILADRES"].ToString() && productregel.Product.Artikelnummer == Convert.ToInt32(row["ARTIKELNUMMER"]))
                {
                    nieuw = false;
                    OracleCommand updateCmd = new OracleCommand("UPDATE WINKELWAGEN SET HOEVEELHEID = :hoeveelheid WHERE ARTIKELNUMMER = :artikelnummer AND EMAILADRES = :email");
                    updateCmd.Parameters.Add("hoeveelheid", productregel.Hoeveelheid);
                    updateCmd.Parameters.Add("artikelnummer", productregel.Product.Artikelnummer);
                    updateCmd.Parameters.Add("email", account.Gebruikersnaam);
                    Database.InsertData(updateCmd);
                }
            }

            if (nieuw)
            {
                OracleCommand insertCmd = new OracleCommand("INSERT INTO WINKELWAGEN VALUES(:gebruikersnaam, :artikelnummer, :hoeveelheid)");
                insertCmd.Parameters.Add("email", account.Gebruikersnaam);
                insertCmd.Parameters.Add("artikelnummer", productregel.Product.Artikelnummer);
                insertCmd.Parameters.Add("hoeveelheid", productregel.Hoeveelheid);
                Database.InsertData(insertCmd);
            }
            
        }

        /// <summary>
        /// Haalt alle productregels op uit de database op basis van het account (voor de winkelwagen)
        /// </summary>
        /// <param name="account">Het account waarop gezocht wordt.</param>
        /// <returns>Returnt een lijst met productregels.</returns>
        public static List<Productregel> GetProductregels(Account account)
        {
            List<Productregel> productregels = new List<Productregel>();
            OracleCommand checkCmd = new OracleCommand("SELECT ARTIKELNUMMER, EMAILADRES, HOEVEELHEID FROM WINKELWAGEN WHERE EMAILADRES = :email");
            checkCmd.Parameters.Add("email", account.Gebruikersnaam);
            DataTable dt = Database.GetDataParameters(checkCmd);
            foreach(DataRow row in dt.Rows)
            {
                int artikelnummer = Convert.ToInt32(row["ARTIKELNUMMER"]);
                Product product = Product.GetProductByArtikelnummer(artikelnummer);
                Productregel productregel = new Productregel(product, Convert.ToInt32(row["HOEVEELHEID"]));
                productregels.Add(productregel);
            }
            return productregels;
        }

        /// <summary>
        /// Verwijdert de productregels van de gebruiker op basis van de gebruikersnaam.
        /// </summary>
        /// <param name="gebruikersnaam">Gebruikersnaam van een account</param>
        public static void VerwijderProductregels(string gebruikersnaam)
        {
            OracleCommand verwijderCmd = new OracleCommand("DELETE FROM WINKELWAGEN WHERE EMAILADRES = :email");
            verwijderCmd.Parameters.Add("email", gebruikersnaam);
            Database.InsertData(verwijderCmd);
        }
    }
}