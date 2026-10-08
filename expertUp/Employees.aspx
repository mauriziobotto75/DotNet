<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employees.aspx.cs" Inherits="ExpertUp.EmployeesPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Employees - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1>Employees</h1>
    <div class="toolbar"><span>Employee records linked to a company</span><a class="button" href="EmployeeEdit.aspx">Add employee</a></div>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:GridView ID="EmployeesGrid" runat="server" AutoGenerateColumns="false" CssClass="grid" OnRowCommand="EmployeesGrid_RowCommand" EmptyDataText="No employees have been added.">
        <Columns>
            <asp:BoundField DataField="LastName" HeaderText="Last name" />
            <asp:BoundField DataField="FirstName" HeaderText="First name" />
            <asp:BoundField DataField="TaxCode" HeaderText="Tax code" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="Actions"><ItemTemplate>
                <a href='<%# "EmployeeEdit.aspx?id=" + Eval("EmployeeId") %>'>Edit</a>
                <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteEmployee" CommandArgument='<%# Eval("EmployeeId") %>' OnClientClick="return confirm('Delete this employee? Employees with contracts cannot be deleted.');" />
            </ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    <a class="back" href="Default.aspx">Home</a>
</main></form></body></html>
