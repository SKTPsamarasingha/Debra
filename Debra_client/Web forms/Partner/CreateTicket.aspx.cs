
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.aspx.Customer;
using Debra_client.PartnerService;

namespace Debra_client.aspx.Partner {
    public partial class CreateTicket : System.Web.UI.Page {

        PartnerServiceSoapClient partner_service = new PartnerServiceSoapClient();


        Helper helper = new Helper();

        List<SalesRecord> sales = new List<SalesRecord>();
        List<Event> events = new List<Event>();
        int PartnerID, EventID;
        string message, eventidString;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {
                    EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                    if (EventID != -1) backLink.HRef = $"/Web%20forms/Partner/Tickets.aspx?EventID={EventID}";
                } catch (Exception ex) {

                    helper.SendAlert("Unable to fetch partner data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

                }

            }
        }



        protected void ticketCreateBtn_Click(object sender, EventArgs e) {
            bool result = false;
            try {
                EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
                string type = textType.Text;
                int price = int.Parse(textPrice.Text);
                int quntity = int.Parse(textQuantity.Text);

                if (EventID == -1) {
                    message = "Please select an event";
                    return;
                }
                helper.SendAlert(EventID.ToString(), this.GetType(), this.ClientScript);

                if (string.IsNullOrEmpty(type) ||
                    price < 0 || quntity < 0) {
                    message = "Please ensure all fields are filled correctly.";
                } else {
                    result = partner_service.CreateTicket(EventID, price, quntity, type, true);
                    message = result ? "Event creation successful!" : "Event creation failed!";
                }

                helper.SendAlert(message, this.GetType(), this.ClientScript);

                if (result) Response.Redirect("~/Web%20forms/Partner/Tickets.aspx?EventID=" + EventID);
            } catch (Exception ex) {
                message = "Unable to save event. Please try again later.";
            }
        }



    }
}