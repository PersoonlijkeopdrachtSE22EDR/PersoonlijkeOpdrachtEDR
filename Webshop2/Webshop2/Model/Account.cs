using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public partial class Account
    {
        public string Gebruikersnaam
        {
            get;
            set;
        }

        private string wachtwoord;

        public string Naam
        {
            get;
            set;
        }

        public string Adres
        {
            get;
            set;
        }

        public string Telefoonnummer
        {
            get;
            set;
        }

        public List<Bestelling> Bestellingen
        {
            get
            {
                return Bestelling.getBestellingen(this.Gebruikersnaam); //parameter nog invullen
            }
        }

        public Winkelwagen Winkelwagen
        {
            get;
            set;
        }

        public Account (string gebruikersnaam, string wachtwoord, string naam, string adres, string telefoonnummer)
    }
}