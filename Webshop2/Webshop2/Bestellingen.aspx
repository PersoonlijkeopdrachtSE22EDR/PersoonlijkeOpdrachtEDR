<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bestellingen.aspx.cs" Inherits="Webshop2.Bestellingen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
        <h3>Bestelling die door U geplaatst zijn</h3>
        <asp:Label runat="server" ID="LabelReactieleeg"></asp:Label>
        <ul class="list-group">
            <asp:Repeater runat="server" ID="repeaterBestelling">
                <ItemTemplate>
                    <li class="list-group-item"> Bestellingnummer: <%#Eval("BestellingNr")%>, besteld op <%#Eval("Datum")%></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </form>
</asp:Content>
