<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Webshop2._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Accountgegevens</h3>
        <%--Registreer Email adres--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelEmailRegistreer">E-mailadres:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:label ID="LabelRegistreerEmail" runat="server" />
            </div>
        </div>
        <%--Einde registreer email adres--%>
        <br />
        <%--registreer Password--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelWachtRegistreer">Wachtwoord:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Label ID="LabelRegistreerWachtwoord" Text="******" runat="server" />
            </div>
        </div>
        <%--Einde registreer password--%>
        <br />
        <%--Registreer naam--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelNaam">Naam:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Label ID="LabelRegistreerNaam" runat="server" />
            </div>
        </div>
        <%--Einde registreer naam--%>
        <br />

        <%--Registreer adres--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelAdres">Adres:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Label ID="LabelRegistreerAdres" runat="server" />
            </div>
        </div>
        <%--Einde registreer adres--%>
        <br />

        <%--Registreer Telefoonnummer--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelTelefoonnummer">Telefoonnummer:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Label ID="LabelRegistreerTelefoonnummer" runat="server" />
            </div>
        </div>
        <%--Einde registreer Telefoonnummer--%>
        <br />

        <%--Registreer Woonplaats--%>
        <div class="row class1">
            <div class="col-md-2">
                <div class="control-group row-fluid form-inline">
                    <asp:Label runat="server" ID="LabelWoonplaats">Woonplaats:</asp:Label>
                </div>
            </div>
            <div class="col-md-2">
                <asp:Label ID="LabelRegistreerWoonplaats" runat="server" />
            </div>
        </div>
        <%--Einde registreer Woonplaats--%>
</asp:Content>
