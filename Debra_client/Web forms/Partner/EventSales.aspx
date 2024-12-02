<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventSales.aspx.cs" Inherits="Debra_client.Web_forms.Partner.EventSales" %>

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
    <form id="form1" runat="server">
        <div id="SalesFeatures" runat="server">
            <h2>Events Sales</h2>
            <asp:Repeater ID="rptSales" runat="server">
                <HeaderTemplate>

                    <table class="salesTable table-striped">
                        <thead>
                            <tr>
                                <th>Event Name</th>
                                <th>Venue</th>
                                <th>Sold Ticket</th>
                                <th>Total Sale</th>
                                <th>Commission Rate</th>
                                <th>Total Commissione</th>
                                <th>Revenue</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Eventname") %></td>
                        <td><%# Eval("Venue") %></td>
                        <td><%# Eval("TicketsSold") %></td>
                        <td><%# Eval("Totalsales") %></td>
                        <td><%# Eval("Commissionrate")+ "%" %></td>
                        <td><%# Eval("Totalcommission") %></td>
                        <td><%# Eval("Aftercommission") %></td>
                        <tr />
                </ItemTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="3"><b>Total Income :</b></td>
                        <td>
                            <asp:Label ID="txtIncome" runat="server" Text="0" />
                        </td>
                    </tr>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
