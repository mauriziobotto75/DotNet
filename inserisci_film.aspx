<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inserisci_film.aspx.cs" Inherits="inserisci_film" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="txttitolo" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Label" Width="67px"></asp:Label><br />
    <asp:TextBox ID="txtanno" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Label" Width="67px"></asp:Label><br />
    <br />
    <asp:ListBox ID="list_attori" runat="server" Height="89px" Width="194px" SelectionMode="Multiple"></asp:ListBox><br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>

