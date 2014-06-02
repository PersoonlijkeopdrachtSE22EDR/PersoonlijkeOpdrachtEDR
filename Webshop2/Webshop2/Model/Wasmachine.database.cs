﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Webshop2
{
    public partial class Wasmachine
    {
        public static Wasmachine GetWasmachine(Product product)
        {
            Wasmachine wasmachine;
            OracleCommand getCmd = new OracleCommand("SELECT ARTIKELNUMMER, ENERGIEKLASSE, TOERENTAL, VULGEWICHT FROM WASMACHINE WHERE ARTIKELNUMMER = :artikelnummer");
            getCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            DataTable dt = Database.getDataParameters(getCmd);
            foreach (DataRow row in dt.Rows)
            {
                wasmachine = new Wasmachine(row["ENERGIEKLASSE"].ToString(), row["TOERENTAL"].ToString(), row["VULGEWICHT"].ToString(), product.Artikelnummer, product.Productnaam, product.Prijs, product.Beschrijving, product.Soort);
                return wasmachine;
            }
            return null;
        }
    }
}