//-----------------------------------------------------------------------
// <copyright file="Reactie.database.cs" company="EDR">
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
    /// Deze class wordt gebruikt voor alle Reactie gerelateerde database queries
    /// </summary>
    public partial class Reactie
    {
        public static List<Reactie> GetReactieByArtikelnummer(int artikelnummer)
        {
            List<Reactie> reacties = new List<Reactie>();
            OracleCommand getcmd = new OracleCommand("SELECT EMAILADRES, OPMERKING, DATUMTIJD FROM REACTIE WHERE ARTIKELNUMMER = :artikelnummer");
            getcmd.Parameters.Add("artikelnummer", artikelnummer);
            DataTable dt = Database.GetDataParameters(getcmd);
            foreach(DataRow row in dt.Rows)
            {
                Reactie reactie = new Reactie(row["EMAILADRES"].ToString(), row["OPMERKING"].ToString(), row["DATUMTIJD"].ToString());
                reacties.Add(reactie);
            }
            return reacties;
        }

        public static void PlaatsReactie(Reactie reactie, Product product)
        {
            OracleCommand insertCmd = new OracleCommand("INSERT INTO REACTIE VALUES(:email, :artikelnummer, :opmerking, :datum)");
            insertCmd.Parameters.Add("email", reactie.Account.Gebruikersnaam);
            insertCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            insertCmd.Parameters.Add("opmerking", reactie.Opmerking);
            insertCmd.Parameters.Add("datum", reactie.DatumTijd);
            Database.InsertData(insertCmd);
        }
    }
}