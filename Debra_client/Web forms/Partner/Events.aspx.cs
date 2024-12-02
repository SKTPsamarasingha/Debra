using Debra_client.aspx;
using Debra_client.PartnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Partner {
    public partial class Events : System.Web.UI.Page {
        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();
        Helper helper = new Helper();

        List<Event> events = new List<Event>();
        protected void Page_Load(object sender, EventArgs e) {
            string msg;
            if (!IsPostBack) {
                try {
                    int partnerID = GetPartnerIDFromCookie();

                    if (partnerID == -1) {
                        msg = "It looks like your session expired. Try logging in again!";
                        return;
                    } else {

                        var eventsRslt = Partner_service.GetPartnersEvents(partnerID);


                        events = eventsRslt != null ? eventsRslt.ToList() : null;

                        msg = events.Count > 0 ? events.Count + " Events Found" : "no events";

                        pndEvents.DataSource = events;
                        pndEvents.DataBind();

                    }

                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch partner data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int eventID = int.Parse(btn.CommandArgument);
            string message = "";
            try {

                bool result = Partner_service.DeleteEvent(eventID);
                message = result ? "Event Delete successfully" : "Sorry Faild to Delete Event";
                helper.SendAlert(message, this.GetType(), this.ClientScript);
                Response.Redirect(Request.RawUrl);

            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch delete event. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }

        }

        protected void Button_Click(object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            string buttonId = clickedButton.ID;
            changeView(buttonId);
        }

        protected void changeView(string btnID) {
            string redirectString = "";

            switch (btnID) {
                case "AddEvent":
                    redirectString = "~/Web%20forms/Partner/CreateEvent.aspx";
                    break;
            }
            Response.Redirect(redirectString);
        }



        private int GetPartnerIDFromCookie() {
            if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int partnerID)) {
                return partnerID;
            }
            return -1;
        }


        protected void btnUpdate_Click(object sender, EventArgs e) {
            Button btnUpdate = (Button)sender;
            int EventID = Convert.ToInt32(btnUpdate.CommandArgument);
            Response.Redirect("UpdateEvent.aspx?EventID=" + EventID);
        }


        protected void TicketBtn_Click(object sender, EventArgs e) {
            Button btnUpdate = (Button)sender;
            int EventID = Convert.ToInt32(btnUpdate.CommandArgument);
            Response.Redirect("Tickets.aspx?EventID=" + EventID);
        }

    }
}