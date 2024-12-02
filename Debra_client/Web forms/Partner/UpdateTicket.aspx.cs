using Debra_client.aspx.Customer;
using Debra_client.aspx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.PartnerService;

namespace Debra_client.Web_forms.Partner {
    public partial class UpdateTicket : System.Web.UI.Page {
        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();


        Helper helper = new Helper();
        Ticket ticket = new Ticket();
        string message;
        int TicketID, EventID;
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                try {
                    EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                    TicketID = helper.GetURlID(Request.QueryString["TicketID"], Request);


                    if (EventID != -1) backLink.HRef = $"/Web%20forms/Partner/Tickets.aspx?EventID={EventID}";

                    var ticketRslt = TicketID != -1 ? Partner_service.GetTicketByID(TicketID) : null;
                    ticket = ticketRslt.Count() > 0 ? ticketRslt.First() : null;

                    if (@ticket != null) {
                        textType.Text = @ticket.Type;
                        textPrice.Text = @ticket.Price.ToString();
                        textQuantity.Text = @ticket.Quantity.ToString();
                        ViewState["TicketID"] = ticket.TicketID; ;
                    }

                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch Ticket data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }
            }
        }

        protected void ticketUpdateBtn_Click(object sender, EventArgs e) {
            string message;
            bool result = false;
            int TicketID, EventID;
            try {
                EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                TicketID = helper.GetURlID(Request.QueryString["TicketID"], Request);


                string type = textType.Text;
                int price = int.Parse(textPrice.Text);
                int quntity = int.Parse(textQuantity.Text);


                if (string.IsNullOrEmpty(type) ||
                      price < 0 || quntity < 0) {
                    message = "Please ensure all fields are filled correctly.";
                } else {
                    result = Partner_service.UpdateTicket(type, price, quntity, true, TicketID);
                    message = result ? "Event update successful!" : "Event update failed!";
                }

                helper.SendAlert(message, this.GetType(), this.ClientScript);

                if (result) Response.Redirect("~/Web%20forms/Partner/Tickets.aspx?EventID=" + EventID);

            } catch (Exception ex) {
                message = "Unable to save updated event. Please try again later.";
                helper.SendAlert(message + ex.Message, this.GetType(), this.ClientScript);

            }
        }

        private int GetPartnerIDFromCookie() {
            if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int partnerID)) {
                return partnerID;
            }
            return -1;
        }



    }
}