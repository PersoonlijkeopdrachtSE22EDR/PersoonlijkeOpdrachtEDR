using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Webshop2
{
    public partial class Productregel
    {
        public static void VoegProductregelToe(Account account, Productregel productregel)
        {
            bool nieuw = true;
            OracleCommand checkCmd = new OracleCommand("SELECT EMAILADRES, ARTIKELNUMMER FROM WINKELWAGEN WHERE EMAILADRES = :email AND ARTIKELNUMMER = :artikelnummer");
            checkCmd.Parameters.Add("email", account.Gebruikersnaam);
            checkCmd.Parameters.Add("artikelnummer", productregel.Product.Artikelnummer);
            DataTable dt = Database.getDataParameters(checkCmd);
            foreach (DataRow row in dt.Rows)
            {
                if (account.Gebruikersnaam == row["EMAILADRES"].ToString() && productregel.Product.Artikelnummer == Convert.ToInt32(row["ARTIKELNUMMER"]))
                {
                    nieuw = false;
                    OracleCommand updateCmd = new OracleCommand("UPDATE WINKELWAGEN SET HOEVEELHEID = :hoeveelheid WHERE ARTIKELNUMMER = :artikelnummer AND EMAILADRES = :email");
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

        public static List<Productregel> GetProductregels(Account account)
        {
            List<Productregel> Productregels = new List<Productregel>();
            OracleCommand checkCmd = new OracleCommand("SELECT ARTIKELNUMMER, EMAILADRES, HOEVEELHEID FROM WINKELWAGEN WHERE EMAILADRES = :email");
            checkCmd.Parameters.Add("email", account.Gebruikersnaam);
            DataTable dt = Database.getDataParameters(checkCmd);
            foreach(DataRow row in dt.Rows)
            {
                int artikelnummer = Convert.ToInt32(row["ARTIKELNUMMER"]);
                Product product = Product.GetProductByArtikelnummer(artikelnummer);
                Productregel productregel = new Productregel(product, Convert.ToInt32(row["HOEVEELHEID"]));
                Productregels.Add(productregel);
            }
            return Productregels;
        }
    }
}