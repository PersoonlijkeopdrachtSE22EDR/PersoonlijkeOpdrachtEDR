using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop2
{
    public class Winkelwagen
    {
        public Account Account
        {
            get;
            set;
        }

        public decimal Prijs
        {
            get;
            set;
        }

        public List<Productregel> Productregels
        {
            get;
            set;
        }

        public Winkelwagen(Account account)
        {
            this.Account = account;
        }

        public void VoegProductToeAanWinkelwagen(Product product, int hoeveelheid)
        {
            if(Productregels == null)
            {
                Productregels = new List<Productregel>();
            }
            Productregel productregel = new Productregel(product, hoeveelheid);
            Productregel.VoegProductregelToe(Account, productregel);
            Productregels.Add(productregel);
            Prijs = BerekenPrijs();
        }

        public void VerwijderProductregel(Productregel productregel)
        {
            //database verwijdering
            Productregels.Remove(productregel);
        }

        public void MaakWinkelwagenleeg()
        {
            Productregel.VerwijderProductregels(Account.Gebruikersnaam);
            Productregels.Clear();
        }

        public decimal BerekenPrijs()
        {
            foreach(Productregel productregel in Productregels)
            {
                Prijs += productregel.Prijs;
            }

            return Prijs;
        }
    }
}