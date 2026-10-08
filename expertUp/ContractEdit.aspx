<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractEdit.aspx.cs" Inherits="ExpertUp.ContractEditPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Contract - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1><asp:Literal ID="PageHeading" runat="server" Text="Add contract" /></h1>
    <p class="notice">Categories and status are administrative labels, not legal determinations.</p>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
    <div class="form-grid">
        <div class="field"><label for="CompanyList">Company *</label><asp:DropDownList ID="CompanyList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CompanyList_SelectedIndexChanged" /><asp:RequiredFieldValidator runat="server" ControlToValidate="CompanyList" InitialValue="" ErrorMessage="Select a company." CssClass="validation" /></div>
        <div class="field"><label for="EmployeeList">Employee *</label><asp:DropDownList ID="EmployeeList" runat="server" /><asp:RequiredFieldValidator runat="server" ControlToValidate="EmployeeList" InitialValue="" ErrorMessage="Select an employee." CssClass="validation" /></div>
        <div class="field"><label for="ContractCode">Contract code *</label><asp:TextBox ID="ContractCode" runat="server" MaxLength="40" /><asp:RequiredFieldValidator runat="server" ControlToValidate="ContractCode" ErrorMessage="Contract code is required." CssClass="validation" /></div>
        <div class="field"><label for="ContractType">Category *</label><asp:DropDownList ID="ContractType" runat="server"><asp:ListItem Value="">-- Select category --</asp:ListItem><asp:ListItem>Permanent</asp:ListItem><asp:ListItem>Fixed-term</asp:ListItem><asp:ListItem>Part-time</asp:ListItem><asp:ListItem>Other</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator runat="server" ControlToValidate="ContractType" InitialValue="" ErrorMessage="Select a category." CssClass="validation" /></div>
        <div class="field"><label for="StartDate">Start date *</label><asp:TextBox ID="StartDate" runat="server" TextMode="Date" /><asp:RequiredFieldValidator runat="server" ControlToValidate="StartDate" ErrorMessage="Start date is required." CssClass="validation" /></div>
        <div class="field"><label for="EndDate">End date</label><asp:TextBox ID="EndDate" runat="server" TextMode="Date" /></div>
        <div class="field"><label for="WeeklyHours">Weekly hours *</label><asp:TextBox ID="WeeklyHours" runat="server" TextMode="Number" /><asp:RequiredFieldValidator runat="server" ControlToValidate="WeeklyHours" ErrorMessage="Weekly hours are required." CssClass="validation" /><asp:RangeValidator runat="server" ControlToValidate="WeeklyHours" MinimumValue="0.01" MaximumValue="168" Type="Double" ErrorMessage="Weekly hours must be greater than zero and no more than 168." CssClass="validation" /></div>
        <div class="field"><label for="Status">Status *</label><asp:DropDownList ID="Status" runat="server"><asp:ListItem>Draft</asp:ListItem><asp:ListItem>Active</asp:ListItem><asp:ListItem>Ended</asp:ListItem></asp:DropDownList></div>
    </div>
    <p><asp:Button ID="SaveButton" runat="server" Text="Save contract" OnClick="SaveButton_Click" />
    <a class="button secondary" href="Contracts.aspx">Cancel</a></p>
</main></form></body></html>
