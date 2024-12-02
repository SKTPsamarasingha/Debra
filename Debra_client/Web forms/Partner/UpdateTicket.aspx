<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateTicket.aspx.cs" Inherits="Debra_client.Web_forms.Partner.UpdateTicket" %>

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
        <div id="TicketFeatures" runat="server">
            <div id="form_continer">
                <h2>Update Ticket</h2>

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

                    <asp:Button ID="ticketUpdateBtn" runat="server" CssClass="form-control" Text="Save Chnages" OnClick="ticketUpdateBtn_Click" />
                    <a id="backLink" runat="server" class="form-control backBtn">Back</a>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
