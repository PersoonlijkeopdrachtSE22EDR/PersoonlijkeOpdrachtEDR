using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Webshop2;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Collections.Generic;

namespace UnitTestProjectSE22
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        [TestMethod]
        public void VoegAccountToe()
        {
            Account account = new Account("gebruikersnaam", "wachtwoord", "naam", "adres", "telnummer", "woonplaats");
            Account.VoegAccountToe(account);

            Account Acc = Account.GetAccountByGebruikersnaam("gebruikersnaam");
            Assert.AreEqual("naam", Acc.Naam, "Naam komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("adres", Acc.Adres, "Adres komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("telnummer", Acc.Telefoonnummer, "Telefoonnummer komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("woonplaats", Acc.Woonplaats, "Woonplaats komt niet overeen met wat is toegevoegd.");
            Assert.AreEqual("gebruikersnaam", Acc.Gebruikersnaam, "Gebruikersnaam komt niet overeen met wat is toegevoegd.");
        }

        [TestMethod]
        public void VoegProductToe()
        {
            Product product = Product.GetProductByArtikelnummer(9);
            Account account = Account.GetAccountByGebruikersnaam("ericderegter@gmail.com");
            Winkelwagen winkelwagen = new Winkelwagen(account);
            winkelwagen.VoegToeProduct(product, 3);

            List<Productregel> productregels = Productregel.GetProductregels(account);
            foreach(Productregel pr in productregels)
            {
                Assert.AreEqual(9, pr.Product.Artikelnummer);
                Assert.AreEqual(3, pr.Hoeveelheid);
                Assert.AreEqual("Macbook", pr.Product.Productnaam);
            }
        }

        [TestMethod]
        public void VoegReactieToe()
        {
            Reactie reactie = new Reactie("ericderegter@gmail.com", "Het werkt!", DateTime.Today.ToString("dd-MMM-yyyy"));
            Product product = Product.GetProductByArtikelnummer(11);
            product.PlaatsReactie(reactie);

            foreach(Reactie r in product.Reacties)
            {
                Assert.AreEqual("Het werkt!", r.Opmerking);
                Assert.AreEqual("ericderegter@gmail.com", r.Gebruikersnaam);
            }
        }
    }
}
