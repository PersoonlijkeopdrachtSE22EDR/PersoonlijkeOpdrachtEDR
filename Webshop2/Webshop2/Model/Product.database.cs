//-----------------------------------------------------------------------
// <copyright file="Product.database.cs" company="EDR">
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
    /// De database class van product.
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Haalt alle producten op uit de database
        /// </summary>
        /// <returns>Returnt een lijst met producten.</returns>
        public static List<Product> GetProducten()
        {
            List<Product> producten = new List<Product>();
            DataTable dt = Database.GetData("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT FROM PRODUCT");
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString());
                producten.Add(product);
            }

            return producten;
        }

        /// <summary>
        /// Haalt een product uit de database op basis van het artikelnummer
        /// </summary>
        /// <param name="artikelnummer">Het artikelnummer waarmee gezocht wordt naar een product in de database.</param>
        /// <returns>Returnt een product</returns>
        public static Product GetProductByArtikelnummer(int artikelnummer)
        {
            OracleCommand getcmd = new OracleCommand("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT FROM PRODUCT WHERE ARTIKELNUMMER = :artikelnummer");
            getcmd.Parameters.Add("artikelnummer", artikelnummer);
            DataTable dt = Database.GetDataParameters(getcmd);
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString(), row["SOORT"].ToString().ToUpper());
                return product;
            }
            return null;
        }

        /// <summary>
        /// Haalt producten op uit de database op basis van het emailadres, deze producten zijn voor de wenslijst.
        /// </summary>
        /// <param name="gebruikersnaam">De gebruikersnaam waarop gezocht wordt.</param>
        /// <returns></returns>
        public static List<Product> GetProductenByEmail(string gebruikersnaam)
        {
            List<Product> producten = new List<Product>();
            OracleCommand getCmd = new OracleCommand("SELECT ARTIKELNUMMER, PRODUCTNAAM, PRIJS, BESCHRIJVING, SOORT FROM PRODUCT WHERE ARTIKELNUMMER IN (SELECT ARTIKELNUMMER FROM wenslijst_product WHERE EMAILADRES = :email)");
            getCmd.Parameters.Add("email", gebruikersnaam);
            DataTable dt = Database.GetDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                Product product = new Product(Convert.ToInt32(row["ARTIKELNUMMER"]), row["PRODUCTNAAM"].ToString(), Convert.ToDecimal(row["PRIJS"]), row["BESCHRIJVING"].ToString());
                producten.Add(product);
            }

            return producten;
        }
    }
}