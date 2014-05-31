﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data;

namespace Webshop2
{
    public partial class Product
    {
        public static List<Product> GetProducten()
        {
            List<Product> Producten = new List<Product>();
            DataTable dt = Database.getData("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT FROM PRODUCT");
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString());
                Producten.Add(product);
            }

            return Producten;
        }

        public static Product GetProductByArtikelnummer(int artikelnummer)
        {
            OracleCommand Getcmd = new OracleCommand("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT FROM PRODUCT WHERE ARTIKELNUMMER = :artikelnummer");
            Getcmd.Parameters.Add("artikelnummer", artikelnummer);
            DataTable dt = Database.getDataParameters(Getcmd);
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString());
                return product;
            }
            return null;
        }

        public static List<Product> GetProductenByEmail(string gebruikersnaam)
        {
            List<Product> Producten = new List<Product>();
            OracleCommand getCmd = new OracleCommand("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT  FROM PRODUCT WHERE ARTIKELNUMMER IN (SELECT ARTIKELNUMMER FROM wenslijst_product WHERE EMAILADRES = :email)");
            getCmd.Parameters.Add("email", gebruikersnaam);
            DataTable dt = Database.getDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString());
                Producten.Add(product);
            }

            return Producten;
        }
    }
}