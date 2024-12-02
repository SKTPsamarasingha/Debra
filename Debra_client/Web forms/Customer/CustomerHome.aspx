<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="Debra_client.Web_forms.Customer.CustomerHome" %>

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
    <link rel="stylesheet" type="text/css" href="../../css/CommonStyles.css" />

</head>
<body>
    <header class="nav-bar">

        <!-- logo container -->
        <div class="logo-container">
            <a href="#">Debra |</a>
        </div>

        <div class="btnLinks-contianer">
            <!-- nav links -->
            <ul class="nav-list">
                <li><a href="/Web%20forms/Customer/ShowEvents.aspx">HOME</a></li>
                <li><a href="#">TICKETS</a></li>
                <li><a href="#">EVENTS</a></li>
                <li><a href="#">THEATER</a></li>

            </ul>
            <!-- login and register container -->

        </div>

    </header>
    <form id="form1" runat="server">
        <div id="purchaseEvents" class="purchaseEvents" runat="server">
            <h2>Purchase Events</h2>
            <asp:Repeater ID="rptEvents" runat="server">
                <HeaderTemplate>

                    <table class="salesTable table-striped">
                        <thead>
                            <tr>
                                <th>Event Name</th>
                                <th>Venue</th>
                                <th>DateTime</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Eventname") %></td>
                        <td><%# Eval("Venue") %></td>
                        <td><%# Eval("DateTime") %></td>
                        <td>
                            <asp:Image ID="imgEvent" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="event-image" AlternateText="Event Image" />
                        </td>

                        <tr />
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
   </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
