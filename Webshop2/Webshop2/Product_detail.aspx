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
        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="ButtonBestel" OnClick="ButtonBestel_Click">Voeg Toe <i class="glyphicon glyphicon-shopping-cart"></i></asp:LinkButton>
        <asp:TextBox runat="server" ID="TextboxHoeveelheid" Text="1"></asp:TextBox>
        
        <br />
        <br />
        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="ButtonWenslijst" OnClick="ButtonWenslijst_Click">Voeg Toe aan wenslijst <i class="glyphicon glyphicon-plus"></i></asp:LinkButton>

        <br />
        <br />
        <h4>Reacties</h4>
        <asp:Label runat="server" ID="LabelReactieleeg"></asp:Label>
        <ul class="list-group">
            <asp:Repeater runat="server" ID="repeaterReactie">
                <ItemTemplate>
                    <li class="list-group-item"> <%#Eval("Account.Naam")%> schreef: <%#Eval("Opmerking")%></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </form>
</asp:Content>
