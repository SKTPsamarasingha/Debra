using Debra_client.CustomerService;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Debra_client.aspx.Customer {
    public partial class BuyTicket : System.Web.UI.Page {

        private CustomerServiceSoapClient CustomerService = new CustomerServiceSoapClient();
        Helper helper = new Helper();

        private int EventID, customerID;
        private string eventidString;
        private List<Ticket> ticketList = new List<Ticket>();
        private List<Event> eventsLists = new List<Event>();
        private Ticket ticket = new Ticket();
        Helper heper = new Helper();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                try {
                    EventID = helper.GetURlID(Request.QueryString["EventID"], Request);

                    if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int id)) {
                        this.customerID = id;
                        ViewState["customerID"] = customerID;
                    }

                    var ticketRslt = CustomerService.GetEventTicket(EventID);
                    var eventRslt = CustomerService.GetEventByID(EventID);

                    if (ticketRslt.Count() > 0) helper.renderRptData(rptTickets, ticketRslt.Cast<Object>().ToList());
                    else helper.SendAlert("Sorry! currently no tickets available", this.GetType(), this.ClientScript);
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }
            }
        }

        protected void BtnDecrease_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtSelectedQuantity = (TextBox)item.FindControl("txtQuantity");
            Label txtAmount = (Label)item.FindControl("txtAmount");
            try {
                int selectedQuantity = int.Parse(txtSelectedQuantity.Text);
                int ticketID = int.Parse(btn.CommandArgument);

                EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                var ticketRslt = CustomerService.GetEventTicket(EventID);


                ticket = ticketRslt.First(t => t.TicketID == ticketID);


                if (selectedQuantity > 0) selectedQuantity--;


                int amount = selectedQuantity * ticket.Price;
                txtSelectedQuantity.Text = selectedQuantity.ToString();
                txtAmount.Text = amount.ToString() + " LKR";
                UpdateTotal();
            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }


        }

        protected void BtnIncrease_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtSelectedQuantity = (TextBox)item.FindControl("txtQuantity");
            Label txtAmount = (Label)item.FindControl("txtAmount");
            string message = "";
            try {
                int selectedQuantity = int.Parse(txtSelectedQuantity.Text);
                int ticketID = int.Parse(btn.CommandArgument);

                EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                var ticketRslt = CustomerService.GetEventTicket(EventID);

                ticket = ticketRslt.FirstOrDefault(t => t.TicketID == ticketID);

                if (ticket != null) {
                    if (selectedQuantity < ticket.AvailableQuantity) {
                        selectedQuantity++;
                    } else { message = "Sorry, only " + ticket.AvailableQuantity.ToString() + " tickets are available."; }

                    int amount = selectedQuantity * ticket.Price;
                    txtSelectedQuantity.Text = selectedQuantity.ToString();
                    txtAmount.Text = amount.ToString() + " LKR";
                    UpdateTotal();
                } else {
                    helper.SendAlert("Ticket not found.", this.GetType(), this.ClientScript);

                }





            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }


        }

        private int UpdateTotal() {
            try {
                int total = 0;
                foreach (RepeaterItem item in rptTickets.Items) {
                    Label txtAmount = (Label)item.FindControl("txtAmount");
                    string amountText = txtAmount.Text.Replace("LKR", "").Trim();

                    int amount = int.Parse(amountText);
                    total += amount;
                }


                Label lblTotalAmount = (Label)rptTickets.Controls[rptTickets.Controls.Count - 1].FindControl("txtTotal");
                lblTotalAmount.Text = total.ToString("F2") + " LKR";
                return total;
            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                return -1;
            }

        }

        protected void CreateSaleBtn_Click(object sender, EventArgs e) {
            try {
                string message = "";
                string redirectStr = "";

                if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int id)) {
                    this.customerID = id;
                    ViewState["customerID"] = customerID;
                } else {
                    message = "It looks like your session expired. Try logging in again!";
                    Response.Redirect("~/Web%20forms/Users/UserLogin.aspx");

                }

                foreach (RepeaterItem item in rptTickets.Items) {
                    TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
                    int selectedQuantity = int.Parse(txtQuantity.Text);


                    if (selectedQuantity > 0) {
                        int ticketID = int.Parse(((Button)item.FindControl("btnIncrease")).CommandArgument);

                        EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                        var ticketRslt = CustomerService.GetEventTicket(EventID);

                        ticket = ticketRslt.FirstOrDefault(t => t.TicketID == ticketID);


                        int total = ticket.Price * selectedQuantity;

                        bool result = CustomerService.CreateSale(customerID, ticketID, selectedQuantity, total);

                        message = result ? "Transaction successfully" : "Transaction Faild";
                        redirectStr = result ? "/Web%20forms/Customer/CustomerHome.aspx" : "Request.RawUrl";



                    }

                    heper.SendAlert(message, this.GetType(), this.ClientScript);
                    Response.Redirect(redirectStr);
                }
            } catch (Exception ex) {
                string message = "Unable to sell tickets. Please try again later.";
                helper.SendAlert(message + ex.Message, this.GetType(), this.ClientScript);
            }


        }
    }
}
