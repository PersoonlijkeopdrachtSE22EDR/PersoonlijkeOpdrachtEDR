using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Reactie
    {
        public string Gebruikersnaam
        {
            get;
            set;
        }
        public Account Account
        {
            get
            {
                return Account.GetAccountByGebruikersnaam(this.Gebruikersnaam);
            }
        }

        public string Opmerking
        {
            get;
            set;
        }

        public string DatumTijd
        {
            get;
            set;
        }

        public Reactie(string gebruikersnaam, string opmerking, string datumTijd)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.Opmerking = opmerking;
            this.DatumTijd = datumTijd;
        }
    }
}