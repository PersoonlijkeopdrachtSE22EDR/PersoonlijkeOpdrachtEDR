<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Webshop2.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Producten</h3>
    <form runat="server" >
        <asp:ListView runat="server" ID="listviewProducten" GroupItemCount="3" >
            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            <table border="1">
                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <GroupTemplate>
                <tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </tr>
            </GroupTemplate>


            <ItemTemplate>
                <td>
                    <h4><%#Eval("Productnaam")%></h4>
                    <br />
                    <label>
                        Artikelnummer:</label>
                    <%#Eval("Artikelnummer")%>
                    <br />
                    <label>
                        Productnaam:</label>
                    <%#Eval("Productnaam")%>
                    <br />
                    <label>
                        Prijs:</label> €
                    <%#Eval("Prijs")%>

                    <br />
                    <label>
                        Beschrijving:</label>
                    <%#Eval("Beschrijving")%>
                    <br />
                    <br />
                    <asp:LinkButton runat="server" Style="margin-left:38%" CssClass="btn btn-primary" Text="Bekijk" OnClick="Product_Click" CommandArgument='<%#Eval("Artikelnummer")%>'></asp:LinkButton>
                </td>
            </ItemTemplate>
        </asp:ListView>
    </form>
</asp:Content>
