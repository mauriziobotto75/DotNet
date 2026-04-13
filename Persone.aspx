<asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="Cognome" HeaderText="Cognome" />

        <asp:ImageField HeaderText="Foto"
            DataImageUrlField="IdPersona"
            DataImageUrlFormatString="~/MostraFotoPersona.ashx?id={0}" />

        <asp:HyperLinkField Text="Modifica"
            DataNavigateUrlFields="IdPersona"
            DataNavigateUrlFormatString="PersonaEdit.aspx?id={0}" />
    </Columns>
</asp:GridView>
