 
@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseManagement.aspx.cs" Inherits="GestioneFormazione.DatabaseManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestione Database</title>
    <style>
        .container {
            width: 400px;
            margin: 50px auto;
            border: 2px solid #333;
            padding: 20px;
            font-family: Arial;

background-color: #f9f9f9;
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        .menu-item {
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>GESTIONE DATABASE</h2>
            <asp:RadioButtonList ID="rblSezioni" runat="server" AutoPostBack="true" 

OnSelectedIndexChanged="rblSezioni_SelectedIndexChanged">
                <asp:ListItem>Polo Formativo</asp:ListItem>
                <asp:ListItem>Contatti</asp:ListItem>
                <asp:ListItem>Partners</asp:ListItem>
                <asp:ListItem>Utenti</asp:ListItem>
                <asp:ListItem>Corsi</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </form>
</body>
</html>

