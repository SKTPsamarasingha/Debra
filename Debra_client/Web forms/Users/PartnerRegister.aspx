<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartnerRegister.aspx.cs" Inherits="Debra_client.aspx.User_aspx.PartnerRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="PartnerRegiste_Form" runat="server">
        <div>
            <h2>Partner Register</h2>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email" required="true"/>
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your Password" required="true"/>
            </div>

            <div class="form-group">
                <label for="companyName">Company name:</label>
                <asp:TextBox ID="textCompanyName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter your Company Name" required="true"/>
            </div>

            <div class="form-group">
                <asp:Button ID="P_RegisterBtn" runat="server" Text="Partner Register" OnClick="Register_Click" CssClass="form-control" />
            </div>
        </div>
    </form>
</body>
</html>
