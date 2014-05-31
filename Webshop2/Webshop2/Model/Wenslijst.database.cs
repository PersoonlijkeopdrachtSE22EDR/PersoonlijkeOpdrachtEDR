using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Webshop2
{
    public partial class Wenslijst
    {
        public static void VoegToeProduct(Account account, Product product)
        {
            OracleCommand insertCmd = new OracleCommand("INSERT INTO WENSLIJST_PRODUCT VALUES(:email, :artikelnummer)");
            insertCmd.Parameters.Add("email", account.Gebruikersnaam);
            insertCmd.Parameters.Add("artikelnummer", product.Artikelnummer);
            Database.InsertData(insertCmd);
        }

        public static void VerwijderProducten(string gebruikersnaam)
        {
            OracleCommand deleteCmd = new OracleCommand("DELETE FROM WENSLIJST_PRODUCT WHERE EMAILADRES = :email");
            deleteCmd.Parameters.Add("email", gebruikersnaam);
            Database.InsertData(deleteCmd);
        }
    }
}