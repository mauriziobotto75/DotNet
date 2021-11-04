<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GesCalendari.aspx.vb" Inherits="GestioneCorsi.GesCalendari"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>GesCalendari</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="FLOWLAYOUT">
		<form id="Form1" method="post" runat="server">
			<P><asp:label id="Label1" runat="server" Width="352px">GESTIONE CALENDARI</asp:label></P>
			<P><asp:label id="Label2" runat="server" Width="192px">DATA</asp:label><asp:textbox id="txtData" runat="server"></asp:textbox></P>
			<P><asp:label id="Label3" runat="server" Width="192px">ORA INIZIO LEZIONI</asp:label><asp:textbox id="txtOraInizioLezioni" runat="server" Width="140px"></asp:textbox></P>
			<P><asp:label id="Label4" runat="server" Width="192px">  NOME  DOCENTE</asp:label><asp:dropdownlist id="dbDocente" runat="server" Width="120px" AutoPostBack="True"></asp:dropdownlist></P>
			<P><asp:label id="Label5" runat="server" Width="192px"> MATERIA</asp:label><asp:dropdownlist id="dbMateria" runat="server" AutoPostBack="True"></asp:dropdownlist></P>
			<P><asp:label id="Label7" runat="server" Width="192px">ID.  CORSO</asp:label>
				<asp:TextBox id="txtIdCorso" runat="server"></asp:TextBox></P>
			<P><asp:label id="Label8" runat="server" Width="192px">ID. AULA</asp:label><asp:textbox id="txtIdAULA" runat="server" Width="48px"></asp:textbox></P>
			<P><asp:label id="Label6" runat="server" Width="192px">ORA FINE LEZIONI</asp:label><asp:textbox id="txtOraFineLezioni" runat="server"></asp:textbox></P>
			<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:button id="btnAggiungi" runat="server" Width="152px" Height="40px" Text="AGGIUNGI"></asp:button></P>
		</form>
	</body>
</HTML>
