<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GesCorsi.aspx.vb" Inherits="GestioneCorsi.GesCorsi"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>GesCorsi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
			<P><asp:label id="Label8" runat="server" Width="568px">                                             GESTIONE CORSI</asp:label></P>
			<P>&nbsp;</P>
			<P><asp:label id="Label1" runat="server" Width="248px">NOME CORSO</asp:label><asp:textbox id="txtNomeCorso" runat="server" Width="224px"></asp:textbox>
				<asp:RangeValidator id="RangeValidator6" runat="server" Width="192px" ErrorMessage="RangeValidator"
					ControlToValidate="txtNomeCorso">Devi inserire un nome</asp:RangeValidator></P>
			<P>&nbsp;</P>
			<P><asp:label id="Label3" runat="server" Width="248px">DESCRIZIONE CORSO</asp:label><asp:textbox id="txtDescrizioneCorso" runat="server" Width="224px"></asp:textbox>
				<asp:RangeValidator id="RangeValidator5" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtDescrizioneCorso">Devi inserire un carattere</asp:RangeValidator></P>
			<P>&nbsp;</P>
			<P><asp:label id="Label4" runat="server" Width="248px">NUMERO POSTI</asp:label><asp:textbox id="txtNumeroPosti" runat="server" Width="96px"></asp:textbox>&nbsp;
				<asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="RangeValidator" Type="Integer"
					MinimumValue="1" MaximumValue="20" ControlToValidate="txtNumeroPosti">Devo inserire un numero</asp:RangeValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
			<P><asp:label id="Label5" runat="server" Width="248px">NUMERO PROFESSORI</asp:label><asp:textbox id="txtNumeroProfessori" runat="server" Width="48px"></asp:textbox>
				<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="RangeValidator" MinimumValue="1"
					MaximumValue="10" ControlToValidate="txtCostoCorso">Devi Inserire un intero</asp:RangeValidator></P>
			<P>&nbsp;</P>
			<P><asp:label id="Label6" runat="server" Width="248px">COSTO CORSO</asp:label><asp:textbox id="txtCostoCorso" runat="server"></asp:textbox>
				<asp:RangeValidator id="RangeValidator3" runat="server" ErrorMessage="RangeValidator" ControlToValidate="txtCostoCorso"
					Visible="False">Devi inserire un numero</asp:RangeValidator></P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<P><asp:label id="Label7" runat="server" Width="248px">IDENTIFICATIVO MATERIALI</asp:label><asp:textbox id="txtIdMateriale" runat="server" Width="48px"></asp:textbox>
				<asp:RangeValidator id="RangeValidator4" runat="server" ErrorMessage="RangeValidator" MaximumValue="100"
					MinimumValue="1" Type="Integer" ControlToValidate="txtIdMateriale">Inserire un valore numerico</asp:RangeValidator></P>
			<P>
				<asp:ValidationSummary id="ValidationSummary4" runat="server" Height="28px"></asp:ValidationSummary></P>
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="btnAggiungi" runat="server" Width="160px" Height="32px" Text="AGGIUNGI CORSO"></asp:button></P>
		</form>
	</body>
</HTML>
