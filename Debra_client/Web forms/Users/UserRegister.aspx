<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="Debra_client.Web_forms.Users.UserRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Register</title>
     <!-- Google fonts -->
    <link href="https://fonts.cdnfonts.com/css/raleway-5" rel="stylesheet" />
    <!-- font awesome -->
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css"
    />
    <link rel="stylesheet" type="text/css" href="../../css/CommonStyles.css" />
</head>
<body>
    <form id="Register_form" runat="server">
        <div id="form_continer">

            <div id="buttonContainer" runat="server">
                <asp:Button ID="PartnerFormBtn" runat="server" Text=" Register As Partner" OnClick="PartnerForm_Click" CssClass="form-control regiBtn" />
                <asp:Button ID="CustomerFormBtn" runat="server" Text=" Register As Customer" OnClick="CustomerForm_Click" CssClass="form-control regiBtn" />
            </div>

            <%--Partner form--%>

            <div id="Partner_Form" runat="server">
                <h2>Partner Register</h2>
                <div class="form-group">
                    <label for="email">Email:</label>
                    <asp:TextBox ID="txtPEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter your email" />
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <asp:TextBox ID="txtPPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your Password" />
                </div>

                <div class="form-group">
                    <label for="companyName">Company name:</label>
                    <asp:TextBox ID="textCompanyName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter your Company Name" />
                </div>
            </div>

            <%--Customer form--%>

            <div id="Customer_Form" runat="server">
                <h2>Customer Register</h2>
                <div class="form-group">
                    <label for="email">Email:</label>
                    <asp:TextBox ID="txtCEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder=" email" />
                </div>
                <div class="form-group">
                    <label for="password">Password:</label>
                    <asp:TextBox ID="txtCPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="password" />
                </div>

                <div class="form-group">
                    <label for="firstName">First name:</label>
                    <asp:TextBox ID="textfirstName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="First name" />
                </div>

                <div class="form-group">
                    <label for="lastName">Last name:</label>
                    <asp:TextBox ID="textLastName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Last name" />
                </div>

                <div class="form-group">
                    <label for="Phone">Pone number</label>
                    <asp:TextBox ID="textPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="Phone" />
                </div>
 
            </div>

            <div class="form-group">
                <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="Register_Click" CssClass="form-control" />
                <asp:Button ID="BackBtn"  runat="server" Text="Back" OnClick="BackBtn_Click" CssClass="form-control" />
            </div>
        </div>
    </form>
</body>
</html>
