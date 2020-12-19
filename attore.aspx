<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="attore.aspx.cs" Inherits="attore" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label><asp:Label ID="lblCognome"
        runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="lblData" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="grid_film" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_film_SelectedIndexChanged">
    </asp:GridView>
</asp:Content>

