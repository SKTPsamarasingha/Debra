<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegister.aspx.cs" Inherits="Debra_client.aspx.User_aspx.EmployeeRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="EmpoyeeRegister_Form" runat="server">
        <div class="form_container">
            <h2>Employee Register</h2>

            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email" required="true"/>
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password" required="true"/>
            </div>

            <div class="form-group">
                <label for="firstName">First name:</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter your first name" required="true"/>
            </div>

            <div class="form-group">
                <label for="lastName">Last name:</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter employee last name" required="true"/>
            </div>

            <div class="form-group">
                <label for="Role">Role</label>
                <asp:TextBox ID="txtRole" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter Role" required="true"/>
            </div>

            <div class="form-group">
                <asp:Button ID="RegisterBtn" runat="server" Text="Employee Register" OnClick="Register_Click" CssClass="form-control" />
            </div>
        </div>
    </form>
</body>
</html>
