<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="Debra_client.Web_forms.Employee.Sales" %>

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
    <link rel="stylesheet" type="text/css" href="../../css/EmployeeStyles.css" />
</head>
<body>
    <form id="form1" class="main" runat="server">
        <div id="btnContienr" class="Btn-contienr">
            <a href="/Web%20forms/Employee/EmployeeHome.aspx" class="asideBtns EventsFeatures">Home</a>
            <a href="/Web%20forms/Employee/ManageUsers.aspx" class="asideBtns EventsFeatures">Manage Users</a>
        </div>
        <%-- Sales features Continers--%>
        <div id="SalesFeatures">
            <%-- Search features--%>

            <div class="banner">
                <h2>Partners sales</h2>

                <div class="Empinput-group">
                    <asp:TextBox ID="EmpEventSrchBar" runat="server" placeholder="Company name" class="EmpEventSrch-Bar"></asp:TextBox>

                    <asp:LinkButton ID="EmpEventSrchBtn" runat="server" class="EmpEventSrch-Btn" OnClick="SearchBtn_Click">
                        Search
                     <i class="fa-solid fa-magnifying-glass"></i>

                    </asp:LinkButton>
                </div>


            </div>

            <asp:Repeater ID="rptSales" runat="server">
                <HeaderTemplate>

                    <table class="salesTable table-striped">
                        <thead>
                            <tr>
                                <th>Company Name</th>
                                <th>Event Name</th>
                                <th>Venue</th>
                                <th>Sold Ticket</th>
                                <th>Total Sale</th>
                                <th>Commission Rate</th>
                                <th>Earnings</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Companyname") %></td>
                        <td><%# Eval("Eventname") %></td>
                        <td><%# Eval("Venue") %></td>
                        <td><%# Eval("TicketsSold") %></td>
                        <td><%# Eval("Totalsales") %></td>
                        <td><%# Eval("Commissionrate")+ "%" %></td>
                        <td><%# Eval("Totalcommission") %></td>
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
