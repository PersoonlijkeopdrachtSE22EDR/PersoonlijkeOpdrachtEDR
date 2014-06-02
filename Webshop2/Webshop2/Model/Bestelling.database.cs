//-----------------------------------------------------------------------
// <copyright file="Bestelling.database.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Webshop2
{
    /// <summary>
    /// Deze class wordt gebruikt voor alle bestelling gerelateerde queries.
    /// </summary>
    public partial class Bestelling
    {
        /// <summary>
        /// Haalt de bestellingen op, op basis van de meegekregen gebruikersnaam.
        /// </summary>
        /// <param name="gebruikersnaam">De gebruikersnaam waarvan alle bestellingen opgehaald moeten worden.</param>
        /// <returns>Returnt een lijst met bestellingen.</returns>
        public static List<Bestelling> GetBestellingen(string gebruikersnaam)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();
            OracleCommand getCmd = new OracleCommand("SELECT BESTELLINGNR, EMAILADRES, DATUMTIJD FROM BESTELLING WHERE EMAILADRES = :email ORDER BY BESTELLINGNR DESC");
            getCmd.Parameters.Add("email", gebruikersnaam);
            DataTable dt = Database.GetDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                DateTime datum = Convert.ToDateTime(row["DATUMTIJD"]);
                Bestelling bestelling = new Bestelling(Convert.ToInt32(row["BESTELLINGNR"]), row["EMAILADRES"].ToString(), datum.ToString("dd-MM-yyyy"));
                bestellingen.Add(bestelling);
            }

            return bestellingen;
        }

        /// <summary>
        /// Maakt een nieuw bestellingsnummer op basis van het maximale bestaande bestellingsnummer.
        /// </summary>
        /// <returns>Het nieuwe unieke bestellingsnummer.</returns>
        public static int GetBestellingNr()
        {
            int bestellingnr = 0;
            DataTable dt = Database.GetData("SELECT MAX(BESTELLINGNR) as maxNummer FROM BESTELLING");
            foreach (DataRow row in dt.Rows)
            {
                if(DBNull.Value.Equals(row["maxNummer"]))
                {
                    bestellingnr = 0;
                }
                else
                {
                    bestellingnr = Convert.ToInt32(row["maxNummer"]);
                }
                bestellingnr += 1;
            }
            return bestellingnr;
        }

        /// <summary>
        /// Voegt een bestelling toe aan de database
        /// </summary>
        /// <param name="bestelling">De bestelling die toegevoegd moet worden.</param>
        /// <returns>Returnt een bool om te laten weten of het gelukt is.</returns>
        public static bool VoegToeBestelling(Bestelling bestelling)
        {
            bool isGelukt = false;
            OracleCommand cmdBestelling = new OracleCommand("INSERT INTO BESTELLING VALUES(:bestellingnr, :email, :datum)");
            cmdBestelling.Parameters.Add("bestellingnr", bestelling.BestellingNr);
            cmdBestelling.Parameters.Add("email", bestelling.Winkelwagen.Account.Gebruikersnaam);
            cmdBestelling.Parameters.Add("datum", bestelling.Datum);
            Database.InsertData(cmdBestelling);

            foreach(Productregel productregel in bestelling.Winkelwagen.Productregels)
            {
                OracleCommand cmdBestellingProduct = new OracleCommand("INSERT INTO BESTELLING_PRODUCT VALUES(:bestellingnr, :artikelnummer, :aantal)");
                cmdBestellingProduct.Parameters.Add("bestellingnr", bestelling.BestellingNr);
                cmdBestellingProduct.Parameters.Add("artikelnummer", productregel.Product.Artikelnummer);
                cmdBestellingProduct.Parameters.Add("aantal", productregel.Hoeveelheid);
                Database.InsertData(cmdBestellingProduct);
                isGelukt = true;
            }
            return isGelukt;            
        }
    }
}