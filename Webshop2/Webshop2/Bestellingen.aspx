<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bestellingen.aspx.cs" Inherits="Webshop2.Bestellingen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="list-group">
        <asp:Repeater runat="server" ID="repeaterBestelling">
            <HeaderTemplate>
                <li class="list-group-item"><%#Eval("BestellingNr")%>, <%#Eval("Datum")%></li>
            </HeaderTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
