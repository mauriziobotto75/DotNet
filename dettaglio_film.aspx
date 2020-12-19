<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dettaglio_film.aspx.cs" Inherits="dettaglio_film" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Lbltitolo" runat="server" Text="Label" Width="239px"></asp:Label>&nbsp;<br />
    <asp:Label ID="lblanno" runat="server" Text="Label" Width="236px"></asp:Label><br />
    &nbsp;<br />
    <asp:GridView ID="grid_attori" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_attori_SelectedIndexChanged">
    </asp:GridView>
</asp:Content>

