﻿//-----------------------------------------------------------------------
// <copyright file="Laptop.database.cs" company="EDR">
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
    /// Deze class haalt de gegevens op van een laptop.
    /// </summary>
    public partial class Laptop : Product
    {
        public static Laptop GetLaptop(Product product)
        {
            Laptop laptop;
            OracleCommand getCmd = new OracleCommand("SELECT ARTIKELNUMMER, PROCESSOR, RAM, RESOLUTIE, HARDE_SCHIJF_CAPACITEIT AS HDD, GRAFISCHE_KAART FROM LAPTOP WHERE ARTIKELNUMMER = :artikelnummer");
            getCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            DataTable dt = Database.GetDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                laptop = new Laptop(row["PROCESSOR"].ToString(), row["RAM"].ToString(), row["RESOLUTIE"].ToString(), row["HDD"].ToString(), row["GRAFISCHE_KAART"].ToString(), product.Artikelnummer, product.Productnaam, product.Prijs, product.Beschrijving, product.Soort);
                return laptop;
            }
            return null;
        }
    }
}