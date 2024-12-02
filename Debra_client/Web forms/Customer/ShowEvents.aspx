<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEvents.aspx.cs" Inherits="Debra_client.aspx.Customer.Events" %>

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

</head>
<body>
    <form id="EventsCards" runat="server">
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
                    <asp:Button ID="UserAccount" runat="server" Text="My Account" OnClick="UserAccount_Click" CssClass="user-account" />

               

                </div>
            </div>

        </header>

        <%--Main--%>
        <main class="main">
            <div class="banner">
                <h1>Let’s Book Your Event</h1>
                <p>Book live events and discover concerts, events, theater and more. </p>
                <div class="input-group">
                    <asp:TextBox runat="server" CssClass="search-bar" ID="txtSrchInput"></asp:TextBox>

                    <asp:LinkButton runat="server" class="search-btn" OnClick="SearchBtn_Click">
        Search
        <i class="fa-solid fa-magnifying-glass"></i>
                    </asp:LinkButton>
                </div>

            </div>

            <h2 class="title">Latest Events </h2>


            <div id="CardContainer" class="now-showing" runat="server"></div>

        </main>

    </form>

</body>
</html>
