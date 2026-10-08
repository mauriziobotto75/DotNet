<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyEdit.aspx.cs" Inherits="ExpertUp.CompanyEditPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Company - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1><asp:Literal ID="PageHeading" runat="server" Text="Add company" /></h1>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
    <div class="form-grid">
        <div class="field"><label for="LegalName">Legal name *</label><asp:TextBox ID="LegalName" runat="server" MaxLength="200" /><asp:RequiredFieldValidator runat="server" ControlToValidate="LegalName" ErrorMessage="Legal name is required." CssClass="validation" /></div>
        <div class="field"><label for="VatNumber">VAT number</label><asp:TextBox ID="VatNumber" runat="server" MaxLength="20" /></div>
        <div class="field"><label for="TaxCode">Tax code</label><asp:TextBox ID="TaxCode" runat="server" MaxLength="20" /></div>
        <div class="field"><label for="Email">Email</label><asp:TextBox ID="Email" runat="server" MaxLength="254" TextMode="Email" /></div>
        <div class="field"><label for="Phone">Phone</label><asp:TextBox ID="Phone" runat="server" MaxLength="40" /></div>
        <div class="field"><label for="Address">Address</label><asp:TextBox ID="Address" runat="server" MaxLength="300" /></div>
    </div>
    <p><asp:Button ID="SaveButton" runat="server" Text="Save company" OnClick="SaveButton_Click" />
    <a class="button secondary" href="Companies.aspx">Cancel</a></p>
</main></form></body></html>
