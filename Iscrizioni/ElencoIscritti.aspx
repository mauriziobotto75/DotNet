<html>
  <head>
  <title> ELENCO ISCRITTI PER CORSO</title>
  </head>
  <body>
  <form name = "ElencoIscritti">
  <asp:GridView ID="gvCorsi" runat="server" AutoGenerateColumns="False"
    CssClass="table" DataKeyNames="id">
    <Columns>
        <asp:BoundField DataField="titolo" HeaderText="Titolo corso" />
        <asp:BoundField DataField="durata_ore" HeaderText="Ore" />
        <asp:BoundField DataField="Data_inizio_iscrizioni" HeaderText="Inizio iscrizioni" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="Data_fine_iscrizioni" HeaderText="Fine iscrizioni" DataFormatString="{0:dd/MM/yyyy}" />

        <asp:HyperLinkField
            Text="Modifica"
            DataNavigateUrlFields="id"
            DataNavigateUrlFormatString="CorsoEdit.aspx?id={0}" />

        <asp:HyperLinkField
            Text="Iscrizioni"
            DataNavigateUrlFields="id"
            DataNavigateUrlFormatString="IscrizioniCorso.aspx?id={0}" />
    </Columns>
</asp:GridView>
</form>
</body>
</html>
