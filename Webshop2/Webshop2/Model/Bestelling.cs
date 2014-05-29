using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

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

        public void PlaatsBestelling(string email, Product product)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("webshopEDR@gmail.com", "webshop1");
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Uw bestelling bij EDR Webshop";
            mail.IsBodyHtml = true;
            string body = "<h3>Bedankt voor het plaatsen van een bestelling bij EDR Webshop.</h3><br /><p>Productdetails</p><p><ul><li>Artikelnummer: " + product.Artikelnummer.ToString() + "</li><li>Productnaam: " + product.Productnaam + "</li><li>Prijs: €" + product.Prijs.ToString() + "</li><li>Beschrijving: " + product.Beschrijving + "</li></ul></p> ";
            mail.Body = body;
            

            //Setting From , To and CC
            mail.From = new MailAddress("webshopEDR@gmail.com", "Webshop EDR");
            mail.To.Add(new MailAddress(email));

            SmtpServer.Send(mail);
        }
    }
}