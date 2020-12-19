<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="elenco_film.aspx.cs" Inherits="elenco_film" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grid_film" runat="server" Height="175px" Width="372px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grid_film_SelectedIndexChanged">
    </asp:GridView>

</asp:Content>

