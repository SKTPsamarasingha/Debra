<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="Debra_client.Web_forms.Users.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Google fonts -->
    <link href="https://fonts.cdnfonts.com/css/raleway-5" rel="stylesheet" />
    <!-- font awesome -->
    <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />
    <link rel="stylesheet" type="text/css" href="../../css/CommonStyles.css" />

</head>
<body>
    <form id="Userlogin_form" runat="server">
      

        <div id="userlogin" runat="server">
            <div id="form_continer">
                <h2>Login</h2>

                <div>
                    <label for="email">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" q TextMode="Email" placeholder="Enter your email" required="true" />
                </div>
                <div>
                    <label for="password">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password" required="true" />
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="BtnLogin_Click" CssClass="form-control" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
