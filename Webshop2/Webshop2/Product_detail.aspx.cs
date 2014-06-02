using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Webshop2
{
    public partial class Product_detail : System.Web.UI.Page
    {
        Product product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["artikelnummer"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                int artikelnummer = Convert.ToInt32(Session["artikelnummer"]);
                product = Product.GetProductByArtikelnummer(artikelnummer);
                ProductnaamHeader.Text = product.Productnaam;
                LabelArtikelnummer.Text = product.Artikelnummer.ToString();
                LabelProductnaam.Text = product.Productnaam;
                LabelPrijs.Text = product.Prijs.ToString();
                LabelBeschrijving.Text = product.Beschrijving;

                switch(product.Soort)
                {
                    case "LAPTOP":
                        Laptop laptop = Laptop.GetLaptop(product);
                        Label labelProcessor = new Label();
                        Label labelRam = new Label();
                        Label labelResolutie = new Label();
                        Label labelHDD = new Label();
                        Label labelGrafischekaart = new Label();

                        labelProcessor.Text = "Processor: " + laptop.Processor;
                        labelRam.Text = "RAM: " + laptop.RAM + "GB";
                        labelResolutie.Text = "Resolutie: " + laptop.Resolutie;
                        labelHDD.Text = "Harde schijf: " + laptop.HardeSchijf + "GB";
                        labelGrafischekaart.Text = "Grafische kaart: " + laptop.GrafischeKaart;

                        Divlabels.Controls.Add(labelProcessor);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelRam);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelResolutie);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelHDD);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelGrafischekaart);
                        break;

                    case "WASMACHINE":
                        Wasmachine wasmachine = Wasmachine.GetWasmachine(product);
                        Label labelEnergieklasse = new Label();
                        Label labelToerental = new Label();
                        Label labelVulgewicht = new Label();

                        labelEnergieklasse.Text = "Energieklasse: " + wasmachine.Energieklasse;
                        labelToerental.Text = "Toerental: " + wasmachine.Toerental;
                        labelVulgewicht.Text = "Vulgewicht: " + wasmachine.Vulgewicht + " kg.";
                        Divlabels.Controls.Add(labelEnergieklasse);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelToerental);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelVulgewicht);
                        break;

                    case "FILMS_GAMES":
                        Film film = Film.GetFilm(product);

                        Label labelGenre = new Label();
                        Label labelGegevensdrager = new Label();
                        Label labelDuur = new Label();

                        labelGenre.Text = "Genre: " + film.Genre;
                        labelGegevensdrager.Text = "Gegevensdrager: " + film.Gegevensdrager;
                        labelDuur.Text = "Duur: " + film.Duur;

                        Divlabels.Controls.Add(labelGenre);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelGegevensdrager);
                        Divlabels.Controls.Add(new LiteralControl("<br />"));
                        Divlabels.Controls.Add(labelDuur);
                        break;
                }

                List<Reactie> Reacties = product.Reacties;
                if (Reacties.Count != 0)
                {
                    repeaterReactie.DataSource = Reacties;
                    repeaterReactie.DataBind();
                }
                else
                {
                    repeaterReactie.Visible = false;
                    LabelReactieleeg.Text = "Er zijn geen reacties geplaatst bij dit product.";
                }
            }
        }

        protected void ButtonBestel_Click(object sender, EventArgs e)
        {
            Page.Validate("validation1");
            if (Page.IsValid)
            {
                if (Session["gebruikersnaam"] == null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Account account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                    Winkelwagen winkelwagen = new Winkelwagen(account);
                    winkelwagen.VoegToeProduct(product, Convert.ToInt32(TextboxHoeveelheid.Text));
                    Response.Redirect("Winkelwagen.aspx");
                }
            }
        }

        protected void ButtonWenslijst_Click(object sender, EventArgs e)
        {
            if (Session["gebruikersnaam"] == null)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Account account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                Wenslijst wenslijst = new Wenslijst(account);
                wenslijst.VoegToeProduct(product);
                Response.Redirect("Wenslijst.aspx");
            }
        }

        protected void ButtonPlaatsReactie_Click(object sender, EventArgs e)
        {
            Page.Validate("validation2");
            if (Page.IsValid)
            {
                if (Session["gebruikersnaam"] == null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Account account = Account.GetAccountByGebruikersnaam((string)Session["gebruikersnaam"]);
                    Reactie reactie = new Reactie(account.Gebruikersnaam, TextboxPlaatsReactie.Text, DateTime.Today.ToString("dd-MMM-yyyy"));
                    product.PlaatsReactie(reactie);
                    Response.Redirect("Product_detail.aspx");
                }
            }
        }
    }
}