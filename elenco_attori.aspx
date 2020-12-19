<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="elenco_attori.aspx.cs" Inherits="elenco_attori" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grid_elenco_attori" runat="server" AutoGenerateSelectButton="True"
        OnSelectedIndexChanged="grid_elenco_attori_SelectedIndexChanged">
    </asp:GridView>
</asp:Content>

