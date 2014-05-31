<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Wenslijst.aspx.cs" Inherits="Webshop2.Wenslijst1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Wenslijst</h3>
    <form runat="server">
        <div class="panel panel-default">
            <asp:Table runat="server" ID="TabelWenslijst">
            </asp:Table>
        </div>
        <br />
        <asp:Button runat="server" Text="Maak wenslijst leeg" ID="ButtonLeegWenslijst" OnClick="LeegWenslijst_Click" CssClass="btn btn-danger" />
    </form>
</asp:Content>
