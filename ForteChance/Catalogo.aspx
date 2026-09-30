<%@ Page Language="C#" AutoEventWireup="true"
CodeFile="Catalogo.aspx.cs"
Inherits="Catalogo" %>

<asp:Repeater ID="rptCorsi" runat="server">

<ItemTemplate>

<div class="corso">

<%# Eval("Immagine") %> />

<h3>
<%# Eval("Titolo") %>
</h3>

<p>
<%# Eval("Descrizione") %>
</p>

<asp:HyperLink
ID="lnkDettaglio"
runat="server"
NavigateUrl='<%# "Corso.aspx?id=" + Eval("ID_Corso") %>'>

Visualizza

</asp:HyperLink>

</div>

</ItemTemplate>

</asp:Repeater>
