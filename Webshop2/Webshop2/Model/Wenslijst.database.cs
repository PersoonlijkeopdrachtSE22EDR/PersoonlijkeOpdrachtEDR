//-----------------------------------------------------------------------
// <copyright file="Wenslijst.database.cs" company="EDR">
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
    /// Deze class wordt gebruikt voor alle Account gerelateerde database queries
    /// </summary>
    public partial class Wenslijst
    {
        /// <summary>
        /// Voegt een product toe aan de wenslijst.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="product"></param>
        public static void VoegToeProduct(Account account, Product product)
        {
            OracleCommand insertCmd = new OracleCommand("INSERT INTO WENSLIJST_PRODUCT VALUES(:email, :artikelnummer)");
            insertCmd.Parameters.Add("email", account.Gebruikersnaam);
            insertCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            Database.InsertData(insertCmd);
        }

        /// <summary>
        /// Verwijderd de producten van de wenslijst in de database
        /// </summary>
        /// <param name="gebruikersnaam"></param>
        public static void VerwijderProducten(string gebruikersnaam)
        {
            OracleCommand deleteCmd = new OracleCommand("DELETE FROM WENSLIJST_PRODUCT WHERE EMAILADRES = :email");
            deleteCmd.Parameters.Add("email", gebruikersnaam);
            Database.InsertData(deleteCmd);
        }
    }
}