using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Webshop2
{
    public partial class Bestelling
    {
        public static List<Bestelling> GetBestellingen(string Gebruikersnaam)
        {
            List<Bestelling> Bestellingen = new List<Bestelling>();
            foreach(DataRow row in Database.getData("SELECT BESTELLINGNR, EMAILADRES, DATUMTIJD").Rows)
            {
                Bestelling bestelling = new Bestelling(Convert.ToInt32(row["BESTELLINGNR"]), row["EMAILADRES"].ToString(), row["DATUMTIJD"].ToString());
                Bestellingen.Add(bestelling);
            }

            return Bestellingen;
        }
    }
}