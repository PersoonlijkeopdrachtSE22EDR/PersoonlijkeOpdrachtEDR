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
    }
}