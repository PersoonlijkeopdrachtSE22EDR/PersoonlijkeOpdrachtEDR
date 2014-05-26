<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webshop2._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <form id="Form1" runat="server">
        <asp:Button ID="Submit1" OnClick="Signout_Click" Text="Sign Out" runat="server" />
    </form>
</asp:Content>
