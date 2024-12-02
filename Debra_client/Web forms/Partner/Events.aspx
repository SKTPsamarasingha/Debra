<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Debra_client.Web_forms.Partner.Events" %>

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
    <form id="PartnerHome_Form" class="main" runat="server">
        <%--Coontrole buttons--%>
        <div id="btnContienr" class="Btn-contienr">
            <a href="/Web%20forms/Partner/PartnerHome.aspx" class="asideBtns EventsFeatures">Home</a>
        </div>


        <%--features Continers--%>
        <div id="featuresContainer" runat="server">

            <div id="PendingEvents" runat="server">
                <h2>Events</h2>
                <asp:Repeater ID="pndEvents" runat="server">
                    <HeaderTemplate>

                        <table class="salesTable table-striped">
                            <thead>
                                <tr>
                                    <th>Event Name</th>
                                    <th>Venue</th>
                                    <th>DateTime</th>
                                    <th>Status</th>
                                    <th>
                                        <asp:Button ID="AddEvent" class="btn-add" runat="server" Text="Add New Event" OnClick="Button_Click" />
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Eventname") %></td>
                            <td><%# Eval("Venue") %></td>
                            <td><%# Eval("DateTime") %></td>
                            <td><%# (bool)Eval("IsAccepted") ? "Accepted" : "Pending" %></td>
                            <td>
                                <asp:Image ID="imgEvent" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="event-image" AlternateText="Event Image" />
                            </td>
                            <td>
                                <asp:Button ID="TicketBtn" runat="server" Text="View Tickets" CssClass="btn-ticket" CommandArgument='<%# Eval("EventID") %>' OnClick="TicketBtn_Click" />

                            </td>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-update" CommandArgument='<%# Eval("EventID") %>' OnClick="btnUpdate_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-delete" CommandArgument='<%# Eval("EventID") %>' OnClick="btnDelete_Click" />
                            </td>
                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
         </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>

        </div>
    </form>

</body>
</html>
