using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

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

        public void PlaatsBestelling()
        {
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.To.Add(new MailAddress("ericderegter@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}