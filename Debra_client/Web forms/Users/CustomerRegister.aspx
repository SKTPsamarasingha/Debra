<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerRegister.aspx.cs" Inherits="Debra_client.aspx.User_aspx.CustomerRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="CustomerRegister_Form" runat="server">
     <div>
    <h2>Customer Register</h2>
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
        <asp:TextBox ID="textfirstName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter your first name" required="true"/>
    </div>

    <div class="form-group">
        <label for="lastName">Last name:</label>
        <asp:TextBox ID="textLastName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter employee last name" required="true"/>
    </div>

    <div class="form-group">
        <label for="Phone">Pone number</label>
        <asp:TextBox ID="textPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="Enter Phone number" required="true"/>
    </div>
    <div class="form-group">
        <asp:Button ID="E_RegisterBtn" runat="server" Text="Customer Register" OnClick="Register_Click" CssClass="form-control" />
    </div>
</div>
    </form>
</body>
</html>


