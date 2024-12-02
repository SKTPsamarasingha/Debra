<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyTicket.aspx.cs" Inherits="Debra_client.aspx.Customer.BuyTicket" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buy Tickets</title>
     <!-- Google fonts -->
    <link href="https://fonts.cdnfonts.com/css/raleway-5" rel="stylesheet" />
    <!-- font awesome -->
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css"
    />
        <link rel="stylesheet" type="text/css" href="../../css/BuyTicket.css" />
</head>
<body>
    <form id="BuyTicket_From" runat="server">
        <div>
            <h2 class="title">Buy Ticket</h2>
            <asp:Repeater ID="rptTickets" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Category</th>
                                <th>Price</th>
                                <th>No. of Tickets</th>
                                <th>Amount</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Type") %></td>
                        <td><%# Eval("Price") %> LKR</td>
                        <td>
                            <asp:Button ID="btnDecrease" runat="server" Text="-" CommandArgument='<%# Eval("TicketID") %>' OnClick="BtnDecrease_Click" CssClass="btn btn-link" />
                            <asp:TextBox ID="txtQuantity" runat="server" Text="0" ReadOnly="true" CssClass="form-control" />
                            <asp:Button ID="btnIncrease" runat="server" Text="+" CommandArgument='<%# Eval("TicketID") %>' OnClick="BtnIncrease_Click" CssClass="btn btn-link" />
                        </td>
                        <td>
                            <asp:Label ID="txtAmount" runat="server" Text="0" />
                        </td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    <tr>
                        <td colspan="3"><b>Total Amount:</b></td>
                        <td>
                            <asp:Label ID="txtTotal" runat="server" Text="0" />
                        </td>
                    </tr>
                    </tbody>
        </table>
                </FooterTemplate>
            </asp:Repeater>

            <div>
                <asp:Button ID="CreateSale" runat="server" Text="Buy Tickets" OnClick="CreateSaleBtn_Click" CssClass="btn buyBtn" />
            </div>
        </div>
    </form>
</body>
</html>
