using System;
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
    }
}