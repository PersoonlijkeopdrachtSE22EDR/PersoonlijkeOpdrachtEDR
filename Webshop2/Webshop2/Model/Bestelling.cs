//-----------------------------------------------------------------------
// <copyright file="Bestelling.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Data;

namespace Webshop2
{
    /// <summary>
    /// De bestelling die een account plaatst.
    /// </summary>
    public partial class Bestelling
    {
        public int BestellingNr
        {
            get;
            set;
        }

        public Winkelwagen Winkelwagen
        {
            get;
            set;
        }

        public string Datum
        {
            get;
            set;
        }

        public Account Account
        {
            get;
            set;
        }

        public string Gebruikersnaam
        {
            get;
            set;
        }

        public Bestelling(int bestellingNr, Winkelwagen winkelwagen, string datum)
        {
            this.BestellingNr = bestellingNr;
            this.Winkelwagen = winkelwagen;
            this.Datum = datum;
        }

        public Bestelling(int bestellingNr, Account account, string datum)
        {
            this.BestellingNr = bestellingNr;
            this.Account = account;
            this.Datum = datum;
        }

        public Bestelling(int bestellingNr, string gebruikersnaam, string datum)
        {
            this.BestellingNr = bestellingNr;
            this.Gebruikersnaam = gebruikersnaam;
            this.Datum = datum;
        }

        /// <summary>
        /// Plaatst de bestelling een stuurt een bevestigingsmail
        /// </summary>
        /// <param name="bestelling">De bestelling die geplaatst wordt</param>
        public void PlaatsBestelling(Bestelling bestelling)
        {
            if (bestelling.Winkelwagen.Productregels.Count != 0)
            {
                if (Bestelling.VoegToeBestelling(bestelling))
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("webshopEDR@gmail.com", "webshop1");
                    SmtpServer.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Uw bestelling bij EDR Webshop";
                    mail.IsBodyHtml = true;
                    string bodyHeader = "<h3>Bedankt voor het plaatsen van een bestelling bij EDR Webshop.</h3><br /><p>Productdetails</p><p><ul>";
                    string body = string.Empty;
                    string bodyFooter = "</ul> <br /> Totaalprijs: €" + bestelling.Winkelwagen.Prijs;
                    foreach (Productregel pr in bestelling.Winkelwagen.Productregels)
                    {
                        string product = "<li>" + pr.ToString() + "</li><br />";
                        body += product;
                    }
                    string bericht = bodyHeader + body + bodyFooter;
                    mail.Body = bericht;

                    //Setting From , To and CC
                    mail.From = new MailAddress("webshopEDR@gmail.com", "Webshop EDR");
                    mail.To.Add(new MailAddress(bestelling.Winkelwagen.Account.Gebruikersnaam));

                    SmtpServer.Send(mail);

                    Winkelwagen.MaakWinkelwagenleeg();
                }
            }
        }

        /// <summary>
        /// Zet de winkelwagen om in een bestelling
        /// </summary>
        /// <param name="winkelwagen">De winkelwagen die omgezet wordt in de bestelling</param>
        /// <returns></returns>
        public static Bestelling VoegToeBestelling(Winkelwagen winkelwagen)
        {
            int artikelnummer = 0;
            artikelnummer = Bestelling.GetBestellingNr();
            Bestelling bestelling = new Bestelling(artikelnummer, winkelwagen,  DateTime.Today.ToString("dd-MMM-yyyy"));
            return bestelling;
        }
    }
}