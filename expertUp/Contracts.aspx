<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contracts.aspx.cs" Inherits="ExpertUp.ContractsPage" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Contracts - ExpertUp</title><link href="Content/site.css" rel="stylesheet" /></head>
<body><form id="form1" runat="server"><main class="shell">
    <h1>Employment contracts</h1>
    <div class="toolbar"><span>Contract metadata only; no legal interpretation is performed.</span><a class="button" href="ContractEdit.aspx">Add contract</a></div>
    <asp:Label ID="ErrorMessage" runat="server" CssClass="error" EnableViewState="false" />
    <asp:GridView ID="ContractsGrid" runat="server" AutoGenerateColumns="false" CssClass="grid" OnRowCommand="ContractsGrid_RowCommand" EmptyDataText="No contracts have been added.">
        <Columns>
            <asp:BoundField DataField="ContractCode" HeaderText="Code" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company" />
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee" />
            <asp:BoundField DataField="ContractType" HeaderText="Category" />
            <asp:BoundField DataField="StartDate" HeaderText="Start" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="EndDate" HeaderText="End" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="WeeklyHours" HeaderText="Hours/week" DataFormatString="{0:0.##}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField HeaderText="Actions"><ItemTemplate>
                <a href='<%# "ContractEdit.aspx?id=" + Eval("ContractId") %>'>Edit</a>
                <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteContract" CommandArgument='<%# Eval("ContractId") %>' OnClientClick="return confirm('Delete this contract?');" />
            </ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    <a class="back" href="Default.aspx">Home</a>
</main></form></body></html>
