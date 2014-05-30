using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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

        public string Woonplaats
        {
            get;
            set;
        }

        public List<Bestelling> Bestellingen
        {
            get
            {
                return Bestelling.GetBestellingen(this.Gebruikersnaam);
            }
        }

        public Winkelwagen Winkelwagen
        {
            get;
            set;
        }

        public Account (string gebruikersnaam, string wachtwoord, string naam, string adres, string telefoonnummer, string woonplaats)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
            this.Naam = naam;
            this.Adres = adres;
            this.Telefoonnummer = telefoonnummer;
            this.Woonplaats = woonplaats;
        }

        public Account (string gebruikersnaam, string naam, string adres, string telefoonnummer, string woonplaats)
        {
            this.Gebruikersnaam = gebruikersnaam;
            this.Naam = naam;
            this.Adres = adres;
            this.Telefoonnummer = telefoonnummer;
            this.Woonplaats = woonplaats;
        }

    }
}