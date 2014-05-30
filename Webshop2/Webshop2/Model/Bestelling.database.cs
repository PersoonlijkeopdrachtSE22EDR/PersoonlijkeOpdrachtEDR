using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace Webshop2
{
    public partial class Bestelling
    {
        public static List<Bestelling> GetBestellingen(string Gebruikersnaam)
        {
            List<Bestelling> Bestellingen = new List<Bestelling>();
            OracleCommand getCmd = new OracleCommand("SELECT BESTELLINGNR, EMAILADRES, DATUMTIJD FROM BESTELLING WHERE EMAILADRES = :email");
            getCmd.Parameters.Add("email", Gebruikersnaam);
            DataTable dt = Database.getDataParameters(getCmd);
            foreach(DataRow row in dt.Rows)
            {
                Bestelling bestelling = new Bestelling(Convert.ToInt32(row["BESTELLINGNR"]), row["EMAILADRES"].ToString(), row["DATUMTIJD"].ToString());
                Bestellingen.Add(bestelling);
            }

            return Bestellingen;
        }
    }
}