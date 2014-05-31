using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Webshop2
{
    public partial class Reactie
    {
        public static List<Reactie> GetReactieByArtikelnummer(int artikelnummer)
        {
            List<Reactie> Reacties = new List<Reactie>();
            OracleCommand Getcmd = new OracleCommand("SELECT EMAILADRES, OPMERKING, DATUMTIJD FROM REACTIE WHERE ARTIKELNUMMER = :artikelnummer");
            Getcmd.Parameters.Add("artikelnummer", artikelnummer);
            DataTable dt = Database.getDataParameters(Getcmd);
            foreach(DataRow row in dt.Rows)
            {
                Reactie reactie = new Reactie(row["EMAILADRES"].ToString(), row["OPMERKING"].ToString(), row["DATUMTIJD"].ToString());
                Reacties.Add(reactie);
            }
            return Reacties;
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