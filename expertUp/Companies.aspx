<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Companies.aspx.cs" Inherits="ExpertUp.CompaniesPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Companies - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1>Companies</h1>
    <div class="toolbar"><span>Company records</span><a class="button" href="CompanyEdit.aspx">Add company</a></div>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:GridView ID="CompaniesGrid" runat="server" AutoGenerateColumns="false" DataKeyNames="CompanyId" CssClass="grid" OnRowCommand="CompaniesGrid_RowCommand" EmptyDataText="No companies have been added.">
        <Columns>
            <asp:BoundField DataField="LegalName" HeaderText="Legal name" />
            <asp:BoundField DataField="VatNumber" HeaderText="VAT number" />
            <asp:BoundField DataField="TaxCode" HeaderText="Tax code" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="Actions"><ItemTemplate>
                <a href='<%# "CompanyEdit.aspx?id=" + Eval("CompanyId") %>'>Edit</a>
                <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteCompany" CommandArgument='<%# Eval("CompanyId") %>' OnClientClick="return confirm('Delete this company? Companies with employees cannot be deleted.');" />
            </ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    <a class="back" href="Default.aspx">Home</a>
</main></form></body></html>
