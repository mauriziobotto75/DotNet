<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GestionePrelieviConsegna.aspx.vb" Inherits="GestioneBiblioteca.GestionePrelieviConsegna"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>GestionePrelieviConsegna</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:label id="Label1" runat="server" Width="328px">GESTIONE PRELIEVI CONSEGNE LIBRI</asp:label></P>
			<P>&nbsp;</P>
			<P><asp:label id="Label2" runat="server" Width="168px">NOME </asp:label><asp:textbox id="txtNome" runat="server"></asp:textbox></P>
			<P><asp:label id="Label3" runat="server" Width="168px">COGNOME</asp:label><asp:textbox id="txtCognome" runat="server"></asp:textbox></P>
			<P><asp:label id="txtIndirizzo" runat="server" Width="168px">INDIRIZZO</asp:label><asp:textbox id="txtIndirizzoUtente" runat="server"></asp:textbox></P>
			<P><asp:label id="Label7" runat="server" Width="168px">N. TES. BIBLIOTECA</asp:label><asp:textbox id="txtTesseraBiblioteca" runat="server"></asp:textbox></P>
			<P><asp:label id="Label5" runat="server" Width="168px">NOME LIBRO</asp:label><asp:textbox id="txtNomeLibro" runat="server" Width="96px"></asp:textbox></P>
			<P><asp:label id="Label6" runat="server" Width="168px">DISPONIBILITA'</asp:label><asp:checkbox id="chkDisponibilita" runat="server"></asp:checkbox></P>
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="cmdPrelievo" runat="server" Width="168px" CommandName="cmdPrelievo" Height="40px"
					Text="PRELIEVO"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="cmdConsegna" runat="server" Width="168px" CommandName="cmdPrelievo" Height="40px"
					Text="CONSEGNA"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
		</form>
	</body>
</HTML>
