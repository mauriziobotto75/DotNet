<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeEdit.aspx.cs" Inherits="ExpertUp.EmployeeEditPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Employee - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1><asp:Literal ID="PageHeading" runat="server" Text="Add employee" /></h1>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
    <div class="form-grid">
        <div class="field"><label for="CompanyList">Company *</label><asp:DropDownList ID="CompanyList" runat="server" /><asp:RequiredFieldValidator runat="server" ControlToValidate="CompanyList" InitialValue="" ErrorMessage="Select a company." CssClass="validation" /></div>
        <div class="field"><label for="TaxCode">Tax code *</label><asp:TextBox ID="TaxCode" runat="server" MaxLength="20" /><asp:RequiredFieldValidator runat="server" ControlToValidate="TaxCode" ErrorMessage="Tax code is required." CssClass="validation" /></div>
        <div class="field"><label for="FirstName">First name *</label><asp:TextBox ID="FirstName" runat="server" MaxLength="100" /><asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName" ErrorMessage="First name is required." CssClass="validation" /></div>
        <div class="field"><label for="LastName">Last name *</label><asp:TextBox ID="LastName" runat="server" MaxLength="100" /><asp:RequiredFieldValidator runat="server" ControlToValidate="LastName" ErrorMessage="Last name is required." CssClass="validation" /></div>
        <div class="field"><label for="Email">Email</label><asp:TextBox ID="Email" runat="server" MaxLength="254" TextMode="Email" /></div>
        <div class="field"><label for="Phone">Phone</label><asp:TextBox ID="Phone" runat="server" MaxLength="40" /></div>
    </div>
    <p><asp:Button ID="SaveButton" runat="server" Text="Save employee" OnClick="SaveButton_Click" />
    <a class="button secondary" href="Employees.aspx">Cancel</a></p>
</main></form></body></html>
