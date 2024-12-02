<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="Debra_client.Web_forms.Partner.Tickets" %>

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
    <form id="form1" class="main" runat="server">
        <%--Coontrole buttons--%>
        <div id="btnContienr" class="Btn-contienr">
            <a href="/Web%20forms/Partner/PartnerHome.aspx" class="asideBtns EventsFeatures">Home</a>
            <a href="/Web%20forms/Partner/Events.aspx" class="asideBtns TicketFeatures">Events</a>
        </div>
        <div class="ticket-container">
            <h2>Tickets</h2>
            <asp:Repeater ID="rptTickets" runat="server">
                <HeaderTemplate>

                    <table class="salesTable table-striped">
                        <thead>
                            <tr>
                                <th>Type</th>
                                <th>Price</th>
                                <th>Quantity</th>
                                <th>Available Amount</th>

                                <th>Status</th>
                                <th>
                                    <asp:Button ID="AddTicket" class="btn-add" runat="server" Text="Add New Ticket" CommandArgument='<%#Eval("TicketID")%>' OnClick="AddTicket_Click" />
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Type") %></td>
                        <td><%# Eval("Price") %></td>
                        <td><%# Eval("Quantity") %></td>
                        <td><%# Eval("AvailableQuantity") %></td>
                        <td><%# (bool)Eval("status") ? "Active" : "Deactive" %></td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-update" CommandArgument='<%#Eval("TicketID")%>' OnClick="btnUpdateTicket_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-delete" CommandArgument='<%#Eval("TicketID")%>' OnClick="btnDeleteTicket_Click" />
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
