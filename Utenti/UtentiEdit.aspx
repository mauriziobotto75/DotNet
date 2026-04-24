<html>
<head>
<title>Gestione Utenti</title>
</head>
<body>
Username:
<asp:TextBox ID="txtUser" runat="server" />

Password:
<asp:TextBox ID="txtPwd" runat="server" />

Ruolo:
<asp:DropDownList ID="ddlRuolo" runat="server" />

Attivo:
<asp:CheckBox ID="chkAttivo" runat="server" />

<br />
<asp:Button ID="btnSalva" runat="server"
    Text="Salva" OnClick="btnSalva_Click" />
</body>
</html>
