<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Product_detail.aspx.cs" Inherits="Webshop2.Product_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        <asp:Label runat="server" ID="ProductnaamHeader"></asp:Label>
    </h3>
    Artikelnummer:
    <asp:Label ID="LabelArtikelnummer" runat="server"></asp:Label>
    <br />
    Productnaam:
    <asp:Label ID="LabelProductnaam" runat="server"></asp:Label>
    <br />
    Prijs: €<asp:Label ID="LabelPrijs" runat="server"></asp:Label>
    <br />
    Beschrijving:
    <asp:Label ID="LabelBeschrijving" runat="server"></asp:Label>
    <br />
    <br />
    <form runat="server">
        <div id="Divlabels" runat="server">

        </div>
        <br />
        <asp:TextBox runat="server" ID="TextboxHoeveelheid" Text="1"></asp:TextBox>
        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="ButtonBestel" OnClick="ButtonBestel_Click">Winkelwagen <i class="glyphicon glyphicon-shopping-cart"></i></asp:LinkButton>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            ControlToValidate="TextboxHoeveelheid"
            Display="Dynamic"
            ErrorMessage="Vul het veld in."
            Forecolor="Red"
            ValidationGroup="validation1"
            runat="server" />

        <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
            runat="server" ControlToValidate="TextboxHoeveelheid"
            ErrorMessage="Voer alleen positieve getallen in (tot 100 exemplaren)."
            ForeColor="Red"
            ValidationGroup="validation1"
            Display="Dynamic"
            ValidationExpression="^[1-9]{1,2}$">
        </asp:RegularExpressionValidator>

        <br />
        <br />
        <asp:LinkButton runat="server" ValidationGroup="validation1" CssClass="btn btn-primary" ID="ButtonWenslijst" OnClick="ButtonWenslijst_Click">Wenslijst <i class="glyphicon glyphicon-plus"></i></asp:LinkButton>

        <br />
        <br />
        <h4>Reacties</h4>
        <asp:Label runat="server" ID="LabelReactieleeg"></asp:Label>
        <ul class="list-group">
            <asp:Repeater runat="server" ID="repeaterReactie">
                <ItemTemplate>
                    <li class="list-group-item"><%#Eval("Account.Naam")%> schreef: <%#Eval("Opmerking")%></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <asp:TextBox runat="server" ID="TextboxPlaatsReactie"></asp:TextBox>
        <asp:LinkButton runat="server" ValidationGroup="validation2" ID="ButtonPlaatsreactie" CssClass="btn btn-primary" OnClick="ButtonPlaatsReactie_Click">Reactie <i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
            ControlToValidate="TextboxPlaatsReactie"
            Display="Dynamic"
            ErrorMessage="Schrijf eerst een reactie."
            Forecolor="Red"
            ValidationGroup="validation2"
            runat="server" />

        <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
            runat="server" ControlToValidate="TextboxPlaatsReactie"
            ErrorMessage="Uw reactie moet tussen de 4 en 255 tekens zijn."
            ForeColor="Red"
            ValidationGroup="validation2"
            Display="Dynamic"
            ValidationExpression="^.{4,255}$">
        </asp:RegularExpressionValidator>
    </form>
</asp:Content>
