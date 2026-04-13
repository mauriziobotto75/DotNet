<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alunni.aspx.cs" Inherits="Alunni" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestione Alunni</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Gestione Alunni</h2>
        <asp:GridView ID="GridViewAlunni" runat="server" AutoGenerateColumns="False" DataKeyNames="IdAlunno"
            OnRowEditing="GridViewAlunni_RowEditing"
            OnRowUpdating="GridViewAlunni_RowUpdating"
            OnRowCancelingEdit="GridViewAlunni_RowCancelingEdit"
            OnRowDeleting="GridViewAlunni_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IdAlunno" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Cognome" HeaderText="Cognome" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <h3>Aggiungi nuovo alunno</h3>
        Nome: <asp:TextBox ID="txtNome" runat="server" />
        Cognome: <asp:TextBox ID="txtCognome" runat="server" />
        <asp:Button ID="btnAggiungi" runat="server" Text="Aggiungi" OnClick="btnAggiungi_Click" />
    </form>
</body>
</html>
