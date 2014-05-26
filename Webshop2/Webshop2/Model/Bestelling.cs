using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Bestelling
    {
        public int BestellingNr
        {
            get;
            set;
        }

        public string Emailadres
        {
            get;
            set;
        }

        public string Datum
        {
            get;
            set;
        }

        public Bestelling(int bestellingNr, string emailadres, string datum)
        {
            this.BestellingNr = bestellingNr;
            this.Emailadres = emailadres;
            this.Datum = datum;
        }
    }
}