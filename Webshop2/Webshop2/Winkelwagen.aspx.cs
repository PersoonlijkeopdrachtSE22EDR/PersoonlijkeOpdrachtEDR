//-----------------------------------------------------------------------
// <copyright file="Winkelwagen.aspx.cs" company="EDR">
//     Copyright (c) Eric de Regter. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Webshop2
{
    public partial class Winkelwagen1 : System.Web.UI.Page
    {
        List<Productregel> productregels;
        Account account;
        Winkelwagen winkelwagen;
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal prijs = 0;

            if (Session["gebruikersnaam"] != null)
            {
                account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                productregels =  Productregel.GetProductregels(account);

                if(productregels.Count == 0)
                {
                    TableRow rowLeeg = new TableRow();
                    ProductenTabel.Rows.Add(rowLeeg);

                    TableCell cellLeeg = new TableCell();
                    rowLeeg.Cells.Add(cellLeeg);
                    cellLeeg.Text = "Geen producten in winkelwagen";
                }

                foreach (Productregel productregel in productregels)
                {
                    TableRow tr = new TableRow();
                    ProductenTabel.Rows.Add(tr);

                    TableCell tcArtikelnummer = new TableCell();
                    tr.Cells.Add(tcArtikelnummer);
                    tcArtikelnummer.CssClass = "WinkelwagenCell";
                    tcArtikelnummer.Text = "Artikelnummer:" + productregel.Product.Artikelnummer.ToString();

                    TableCell tcProductnaam = new TableCell();
                    tr.Cells.Add(tcProductnaam);
                    tcProductnaam.CssClass = "WinkelwagenCell";
                    tcProductnaam.Text = "Productnaam: " + productregel.Product.Productnaam;

                    TableCell tcPrijs = new TableCell();
                    tr.Cells.Add(tcPrijs);
                    tcPrijs.CssClass = "WinkelwagenCell";
                    tcPrijs.Text = "Prijs: €" + productregel.Product.Prijs.ToString();

                    TableCell tcHoeveelheid = new TableCell();
                    tr.Cells.Add(tcHoeveelheid);
                    tcHoeveelheid.CssClass = "WinkelwagenCell";
                    tcHoeveelheid.Text = "Hoeveelheid: " + productregel.Hoeveelheid.ToString();

                    TableCell tcPrijsTotaal = new TableCell();
                    tcPrijsTotaal.CssClass = "WinkelwagenCell";
                    tcPrijsTotaal.Text = "Totaal: €" + productregel.Prijs.ToString();
                    prijs += productregel.Prijs;
                }

                labelFooter.Text = "Totaalprijs: €" + prijs.ToString();
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }

        protected void Bestel_Click(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                winkelwagen = new Winkelwagen(account, productregels);
                if (winkelwagen.Productregels.Count != 0)
                {
                    Bestelling bestelling = Bestelling.VoegToeBestelling(winkelwagen);
                    bestelling.PlaatsBestelling(bestelling);
                    Response.Redirect("Winkelwagen.aspx");
                }
            }
        }

        protected void LeegWinkelwagen_Click(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                winkelwagen = new Winkelwagen(account, productregels);
                winkelwagen.MaakWinkelwagenleeg();
                Response.Redirect("Winkelwagen.aspx");
            }
        }
    }
}