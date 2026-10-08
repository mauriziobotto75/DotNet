<%@ Page Language="C#" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>ExpertUp MVP</title>
    <link href="Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <main class="shell">
            <h1>ExpertUp</h1>
            <p class="intro">Company, employee, and employment-contract records.</p>
            <p class="notice">Administrative record keeping only. This MVP does not calculate payroll or determine legal compliance.</p>
            <nav class="cards">
                <a href="Companies.aspx"><strong>Companies</strong><span>Manage company records</span></a>
                <a href="Employees.aspx"><strong>Employees</strong><span>Manage employee records</span></a>
                <a href="Contracts.aspx"><strong>Contracts</strong><span>Manage contract metadata</span></a>
            </nav>
        </main>
    </form>
</body>
</html>
