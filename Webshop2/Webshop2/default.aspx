<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webshop2._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Using Forms Authentication</h3>
    <asp:Label ID="Welcome" runat="server" />
    <form id="Form1" runat="server">
        <asp:Button ID="Submit1" OnClick="Signout_Click" Text="Sign Out" runat="server" />

        <%--Registreer Email adres--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelEmailRegistreer">E-mailadres:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerEmail" runat="server" />
            </div>
        </div>
        <%--Einde registreer email adres--%>
        <br />
        <%--registreer Password--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelRegistreer">Wachtwoord:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerWachtwoord" TextMode="Password" runat="server" />
            </div>
        </div>
        <%--Einde registreer password--%>
        <br />
        <%--Registreer naam--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelRegistreerNaam">Naam:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerNaam" runat="server" />
            </div>
        </div>
        <%--Einde registreer naam--%>
        <br />

        <%--Registreer adres--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelRegistreerAdres">Adres:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerAdres" runat="server" />
            </div>
        </div>
        <%--Einde registreer adres--%>
        <br />

        <%--Registreer Telefoonnummer--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="Label3">Telefoonnummer:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerTelefoonnummer" runat="server" />
            </div>
        </div>
        <%--Einde registreer Telefoonnummer--%>
        <br />

        <%--Registreer Woonplaats--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="Label4">Woonplaats:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBoxRegistreerWoonplaats" runat="server" />
            </div>
        </div>
        <%--Einde registreer Woonplaats--%>
    </form>
</asp:Content>
