<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="inserisci_attore.aspx.cs" Inherits="inserisci_attore" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="nome"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="cognome"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="data di nascita"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox4" runat="server" Height="36px"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="note"></asp:Label>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="inserisci" />
</asp:Content>

