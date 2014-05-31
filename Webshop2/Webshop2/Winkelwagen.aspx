<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Winkelwagen.aspx.cs" Inherits="Webshop2.Winkelwagen1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Winkelwagen</h3>
    <div class="panel panel-default">
        <div class="panel-heading">
            <label>Producten in Uw winkelwagen:</label>
        </div>
        <asp:Table runat="server" class="tabelProducten" ID="ProductenTabel">
        </asp:Table>
        <div class="panel panel-footer">
            <asp:Label CssClass="PanelFooter" runat="server" ID="labelFooter"></asp:Label>
        </div>
    </div>
    <br />


    <form runat="server">
        <asp:Button runat="server" Text="Plaats bestelling" ID="ButtonBestel" OnClick="Bestel_Click" CssClass="btn btn-success" />
        <asp:Button runat="server" Text="Maak winkelwagen leeg" ID="ButtonLeegWinkelwagen" OnClick="LeegWinkelwagen_CLick" CssClass="btn btn-danger" />
    </form>
</asp:Content>
