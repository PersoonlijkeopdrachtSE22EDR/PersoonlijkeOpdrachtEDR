//-----------------------------------------------------------------------
// <copyright file="Film.database.cs" company="EDR">
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
    /// Deze class haalt de gegevens op van een film
    /// </summary>
    public partial class Film : Product
    {
        public static Film GetFilm(Product product)
        {
            Film film;
            OracleCommand getCmd = new OracleCommand("SELECT ARTIKELNUMMER, GENRE, GEGEVENSDRAGER, DUUR FROM FILM WHERE ARTIKELNUMMER = :artikelnummer");
            getCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            DataTable dt = Database.GetDataParameters(getCmd);
            foreach (DataRow row in dt.Rows)
            {
                film = new Film(row["GENRE"].ToString(), row["GEGEVENSDRAGER"].ToString(), row["DUUR"].ToString(), product.Artikelnummer, product.Productnaam, product.Prijs, product.Beschrijving, product.Soort);
                return film;
            }
            return null;
        }
    }
}