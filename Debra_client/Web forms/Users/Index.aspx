<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Debra_client.Web_forms.Users.Index" %>

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
    <link rel="stylesheet" type="text/css" href="../../css/CustomerStyle.css" />
    <link rel="stylesheet" type="text/css" href="../../css/index.css" />


</head>
<body>
    <form id="form1" runat="server">
        <header class="nav-bar">

            <!-- logo container -->
            <div class="logo-container">
                <a href="#">Debra |</a>
            </div>

            <div class="btnLinks-contianer">
                <!-- nav links -->
                <ul class="nav-list">
                    <li><a href="#">HOME</a></li>
                    <li><a href="#">TICKETS</a></li>
                    <li><a href="#">EVENTS</a></li>
                    <li><a href="#">THEATER</a></li>
                </ul>
                <!-- login and register container -->
                <div class="login-container">
                    <asp:Button ID="UserLogin" runat="server" Text="User login" OnClick="UserLogin_Click" CssClass="user-account" />


                </div>
            </div>

        </header>
        <header class="about-us">

            <div class="img-contianer">
                <img src="https://www.ticketsministry.com/_next/static/media/about-logo.9b1a0c4f.svg" />
            </div>
            <div class="content">
                <h1><span>Who</span> we are?</h1>
                <p>We believe experiences are best enjoyed live and they can change lives. So we are building a platform for fans to get the best out of Live Events in the smoothest way possible.</p>
                <p>Debra is one of the fast-growing ticket marketplaces that includes events of music, sport, art, theatre, and more. It is capable to accommodate events of all types, sizes, and complexities with the state-of-the-art technology.</p>
                <a href="/Web%20forms/Users/UserRegister.aspx" class="register">Join with us</a>

            </div>


        </header>
    </form>
</body>
</html>
