<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Webshop2.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Home pagina test</h3>
    <asp:ListView runat="server" ID="listviewProducten">
        <ItemTemplate>
            <div class="details">
                <div class="data-container">
                    <ul>
                        <li>
                            <label>
                                Artikelnummer:</label>
                            <%#Eval("Artikelnummer")%>
                        </li>
                        <li>
                            <label>
                                Productnaam:</label>
                            <%#Eval("Productnaam")%>
                        </li>
                        <li>
                            <label>
                                Prijs:</label>
                            <%#Eval("Prijs")%>
                        </li>
                        <li>
                            <label>
                                Beschrijving:</label>
                            <%#Eval("Beschrijving")%>
                        </li>
                    </ul>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
