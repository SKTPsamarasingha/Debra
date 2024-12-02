<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeHome.aspx.cs" Inherits="Debra_client.aspx.Employee.EmployeeHome" %>

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
    <form id="EmployeeHome_Form" class="main" runat="server">
        <%--Coontrole buttons--%>
        <div id="btnContienr" class="Btn-contienr">
            <a href="/Web%20forms/Employee/Sales.aspx" class="asideBtns EventsFeatures">Sales</a>
            <a href="/Web%20forms/Employee/ManageUsers.aspx" class="asideBtns EventsFeatures">Manage Users</a>
        </div>

        <%--features Continers--%>

        <div id="featuresContainer">

            <%-- Event features Continers--%>
            <div id="EventsFeatures">
                <h2>New events</h2>
                <asp:Repeater ID="rptNewevents" runat="server">
                    <HeaderTemplate>

                        <table class="salesTable table-striped">
                            <thead>
                                <tr>
                                    <th>Company Name</th>
                                    <th>Event Name</th>
                                    <th>Venue</th>
                                    <th>Date</th>
                                    <th>Revenue</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Companyname") %></td>
                            <td><%# Eval("Eventname") %></td>
                            <td><%# Eval("Venue") %></td>
                            <td><%# Eval("DateTime") %></td>
                            <td><%# Eval("Revenu")%></td>

                            <td>
                                <asp:TextBox ID="txtcommission" runat="server" Text="0" CssClass="form-control" /></td>
                            <td>
                                <asp:Button ID="btnAccept" runat="server" Text="Accpet" CommandArgument='<%# Eval("EventID") %>' OnClick="btnAccpet_Click" /></td>



                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        <tr>
                            <%-- <td colspan="3"><b>Total commission :</b></td>
            <td>
                <asp:Label ID="txtcommission" runat="server" Text="0" />
            </td>--%>
                        </tr>
                        </tbody>
        </table>
                    </FooterTemplate>
                </asp:Repeater>

            </div>


            <%-- Ticket features Continers--%>
            <div id="TicketFeatures"></div>




        </div>
    </form>
</body>
</html>
