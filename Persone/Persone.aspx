<asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
        <asp:ImageField DataImageUrlField="IdPersona"
            DataImageUrlFormatString="~/Handlers/Immagine.ashx?id={0}"
            HeaderText="Foto" />
        <asp:HyperLinkField Text="Modifica"
            DataNavigateUrlFields="IdPersona"
            DataNavigateUrlFormatString="PersonaEdit.aspx?id={0}" />
    </Columns>
</asp:GridView>
