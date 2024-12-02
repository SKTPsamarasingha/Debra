<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartnerHome.aspx.cs" Inherits="Debra_client.aspx.Partner.PartnerHome" %>

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
            <a href="/Web%20forms/Partner/Events.aspx" class="asideBtns EventsFeatures">Events</a>
        </div>


        <%--features Continers--%>
        <div id="featuresContainer" runat="server">
            <%-- Sales features Continers--%>
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
                </asp:Repeater>
            </div>


            <%-- Event features Continers--%>
            <%--    <div id="EventsFeatures" runat="server">

                <div id="form_continer">
                    <div class="form-group">
                        <h2>Create Event</h2>

                        <label for="eventName">Event name:</label>
                        <asp:TextBox ID="txteventName" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="Enter event name" required="true" />
                    </div>
                    <div>
                        <label for="venue">Event Venue:</label>
                        <asp:TextBox ID="txtVenue" runat="server" TextMode="SingleLine" placeholder="Enter venue" required="true" />
                    </div>

                    <div>
                        <label for="imageUrl">Image Url:</label>
                        <asp:TextBox ID="textimageUrl" runat="server" TextMode="SingleLine" placeholder="Enter image Url" required="true" />
                    </div>
                    <div class="date-time-container">
                        <label for="dateTime">Select date and time:</label>
                        <asp:TextBox ID="dateTime" runat="server" TextMode="DateTimeLocal" required="true" CssClass="form-control" />
                    </div>

                    <div>
                        <asp:Button ID="EventCreateBtn" runat="server" CssClass="form-control" Text="Create Event" OnClick="EventCreate_Click" />

                    </div>
                </div>
            </div>--%>


            <%-- Ticket features Continers--%>
            <%--<div id="TicketFeatures" runat="server">
                <div id="form_continer">
                    <h2>Create Ticket</h2>


                    <div class="form-group">
                        <label for="evnetDropdown">Select Event:</label>
                        <asp:DropDownList ID="evnetDropdown" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                    </div>


                    <div>
                        <label for="type">Ticket Type:</label>
                        <asp:TextBox ID="textType" runat="server" CssClass="form-control" TextMode="SingleLine" placeholder="VIP,balcony etc.." required="true" />
                    </div>

                    <div>
                        <label for="price">Ticket Price:</label>
                        <asp:TextBox ID="textPrice" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter ticket price" required="true" />
                    </div>

                    <div>
                        <label for="quantity">Ticket quantity:</label>
                        <asp:TextBox ID="textQuantity" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter ticket quantity" required="true" />
                    </div>

                    <div>

                        <asp:Button ID="ticketCreateBtn" runat="server" CssClass="form-control" Text="Create ticket" OnClick="ticketCreateBtn_Click" />

                    </div>

                </div>
            </div>--%>


            <%--            <div id="PendingEvents" runat="server">
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
                                        <asp:Button ID="AddEvent" class="btn-add" runat="server" Text="Add New Event" OnClick="Button_Click" /></td>
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
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-delete" CommandArgument='<%# Eval("EventID") %>' OnClick="btnDelete_Click" /></td>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-update" CommandArgument='<%# Eval("EventID") %>' OnClick="btnUpdate_Click" /></td>

                            <tr />
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
         </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>--%>
        </div>
    </form>

</body>
</html>
