using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Webshop2
{
    public partial class Bestelling
    {
        public static List<Bestelling> GetBestellingen(string Gebruikersnaam)
        {
            List<Bestelling> Bestellingen = new List<Bestelling>();
            OracleCommand getCmd = new OracleCommand("SELECT BESTELLINGNR, EMAILADRES, DATUMTIJD FROM BESTELLING WHERE EMAILADRES = :email ORDER BY BESTELLINGNR DESC");
            getCmd.Parameters.Add("email", Gebruikersnaam);
            DataTable dt = Database.getDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                DateTime datum = Convert.ToDateTime(row["DATUMTIJD"]);
                Bestelling bestelling = new Bestelling(Convert.ToInt32(row["BESTELLINGNR"]), row["EMAILADRES"].ToString(), datum.ToString("dd-MM-yyyy"));
                Bestellingen.Add(bestelling);
            }

            return Bestellingen;
        }

        public static int GetBestellingNr()
        {
            int bestellingnr = 0;
            DataTable dt = Database.getData("SELECT MAX(BESTELLINGNR) as maxNummer FROM BESTELLING");
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