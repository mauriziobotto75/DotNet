<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ruoli.aspx.cs" Inherits="MasterPage.Ruoli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestione Ruoli</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestione Ruoli</h2>
            
            <asp:GridView ID="gvRuoli" runat="server"
                AutoGenerateColumns="false"
                DataKeyNames="RuoloID">\n
                <Columns>
                    <asp:BoundField DataField="Descrizione" HeaderText="Ruolo" />
                    <asp:HyperLinkField Text="Diritti"
                        DataNavigateUrlFields="RuoloID"
                        DataNavigateUrlFormatString="RuoloDiritti.aspx?id={0}" />
                    <asp:HyperLinkField Text="Modifica"
                        DataNavigateUrlFields="RuoloID"
                        DataNavigateUrlFormatString="RuoloEdit.aspx?id={0}" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:HyperLink NavigateUrl="RuoloEdit.aspx" Text="Nuovo Ruolo" runat="server" />
        </div>
    </form>
</body>
</html>