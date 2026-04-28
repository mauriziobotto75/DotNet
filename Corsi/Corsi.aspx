<html>
<head>
<title> INSERIMENTO CORSI</title>
</head>
<body>
<form name="InsCorsi.aspx.cs">
<asp:TextBox ID="txtTitolo" runat="server" />
<asp:TextBox ID="txtDescrizione" runat="server" TextMode="MultiLine" />

<asp:TextBox ID="txtDurataOre" runat="server" />
<asp:TextBox ID="txtPoloId" runat="server" />

<asp:TextBox ID="txtRegioni" runat="server" />
<asp:TextBox ID="txtTipologiaScuola" runat="server" />
<asp:TextBox ID="txtMacroArgomento" runat="server" />
<asp:TextBox ID="txtDestinatari" runat="server" />

<asp:TextBox ID="txtAreaDigCompEdu" runat="server" />
<asp:TextBox ID="txtLivelloIngresso" runat="server" />

<asp:TextBox ID="txtProgramma" runat="server" TextMode="MultiLine" />
<asp:TextBox ID="txtFormatori" runat="server" />

<asp:TextBox ID="txtDataInizioIscr" runat="server" />
<asp:TextBox ID="txtDataFineIscr" runat="server" />

<asp:Button ID="btnSalva" runat="server"
    Text="Salva corso"
    OnClick="btnSalva_Click" />
</form>
</body>
</html>
