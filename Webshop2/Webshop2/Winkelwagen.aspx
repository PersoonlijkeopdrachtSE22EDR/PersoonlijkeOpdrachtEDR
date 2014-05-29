<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Winkelwagen.aspx.cs" Inherits="Webshop2.Winkelwagen1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Winkelwagen</h3>
    <div class="panel panel-default">
        <div class="panel-heading">Panel heading</div>
        <asp:Table runat="server" class="table" ID="ProductenTabel">
            
        </asp:Table>
    </div>
    <form runat="server">
        <asp:Button runat="server" ID="ButtonBestel" OnClick="Bestel_Click" CssClass="btn btn-success" />
    </form>
</asp:Content>
