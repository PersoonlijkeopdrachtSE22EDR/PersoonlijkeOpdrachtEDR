<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Product_detail.aspx.cs" Inherits="Webshop2.Product_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        <asp:Label runat="server" ID="ProductnaamHeader"></asp:Label>
    </h3>
    Artikelnummer:
    <asp:Label ID="LabelArtikelnummer" runat="server"></asp:Label>
    <br />
    Productnaam:
    <asp:Label ID="LabelProductnaam" runat="server"></asp:Label>
    <br />
    Prijs: €<asp:Label ID="LabelPrijs" runat="server"></asp:Label>
    <br />
    Beschrijving:
    <asp:Label ID="LabelBeschrijving" runat="server"></asp:Label>
    <br />
    <br />
    <form runat="server">
        <asp:TextBox runat="server" ID="TextboxHoeveelheid" Text="1"></asp:TextBox>
        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="ButtonBestel" OnClick="ButtonBestel_Click">Winkelwagen <i class="glyphicon glyphicon-shopping-cart"></i></asp:LinkButton>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            ControlToValidate="TextboxHoeveelheid"
            Display="Dynamic"
            ErrorMessage="Vul het veld in."
            ValidationGroup="validation1"
            runat="server" />

        <asp:CompareValidator ID="CompareValidatorGetal" runat="server"
            ErrorMessage="Voer een getal in."
            ControlToValidate="TextboxHoeveelheid" Type="Integer"
            ForeColor="Red"
            Display="Dynamic"
            Operator="DataTypeCheck"
            ValidationGroup="validation1">
        </asp:CompareValidator>
        <br />
        <asp:CompareValidator ID="CompareValidatorGroterdan" runat="server"
            Operator="GreaterThan" ValueToCompare="0"
            ControlToValidate="TextboxHoeveelheid" ForeColor="Red" ErrorMessage="Voer een positief getal in."
            Type="Integer"
            Display="Dynamic"
            ValidationGroup="validation1">
        </asp:CompareValidator>
        <br />
        <asp:CompareValidator ID="CompareValidatorKleinerdan" runat="server"
            Operator="LessThan" ValueToCompare="101"
            ControlToValidate="TextboxHoeveelheid" ForeColor="Red" ErrorMessage="U mag niet meer dan 100 van dezelfde producten bestellen."
            Type="Integer"
            Display="Dynamic"
            ValidationGroup="validation1">
        </asp:CompareValidator>
        
        <br />
        <br />
        <asp:LinkButton runat="server" ValidationGroup="validation1" CssClass="btn btn-primary" ID="ButtonWenslijst" OnClick="ButtonWenslijst_Click">Wenslijst <i class="glyphicon glyphicon-plus"></i></asp:LinkButton>

        <br />
        <br />
        <h4>Reacties</h4>
        <asp:Label runat="server" ID="LabelReactieleeg"></asp:Label>
        <ul class="list-group">
            <asp:Repeater runat="server" ID="repeaterReactie">
                <ItemTemplate>
                    <li class="list-group-item"> <%#Eval("Account.Naam")%> schreef: <%#Eval("Opmerking")%></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>

        <asp:TextBox runat="server" ID="TextboxPlaatsReactie"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server"
            Operator="LessThan" ValueToCompare="256"
            ControlToValidate="TextboxPlaatsReactie" ForeColor="Red" ErrorMessage="Uw reactie mag niet groter zijn dan 255 tekens."
            Type="Integer"
            Display="Dynamic">
        </asp:CompareValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    ControlToValidate="TextboxPlaatsReactie"
                    Display="Dynamic"
                    ErrorMessage="Schrijf eerst een reactie."
                    ValidationGroup="validation2"
                    runat="server" />
        <asp:LinkButton runat="server" ValidationGroup="validation2" ID="ButtonPlaatsreactie" CssClass="btn btn-primary" OnClick="ButtonPlaatsReactie_Click">Reactie <i class="glyphicon glyphicon-plus"></i></asp:LinkButton>
    </form>
</asp:Content>
