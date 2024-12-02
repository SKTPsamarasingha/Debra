﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="Debra_client.aspx.Partner.CrateEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <form id="CrateEvent_Form" runat="server">
        <div id="EventsFeatures" runat="server">

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
                    <a href="/Web%20forms/Partner/Events.aspx" class="form-control backBtn">Back</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


