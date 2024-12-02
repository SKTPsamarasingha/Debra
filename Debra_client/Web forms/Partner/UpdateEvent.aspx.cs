using Debra_client.aspx;
using Debra_client.PartnerService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Partner {
    public partial class WebForm1 : System.Web.UI.Page {

        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();
        Helper helper = new Helper();
        Event @event = new Event();
        int EventID;
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                try {
                    EventID = helper.GetURlID(Request.QueryString["EventID"], Request);

                    var eventsRslt = Partner_service.GetEventsByID(EventID);
                    @event = eventsRslt.Count() > 0 ? eventsRslt.First() : null;

                    if (@event != null) {
                        txteventName.Text = @event.EventName;
                        txtVenue.Text = @event.Venue;
                        textimageUrl.Text = @event.ImageUrl;
                        dateTime.Text = @event.DateTime.ToString("yyyy-MM-ddTHH:mm");

                    }
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch Event data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }

            }
        }
        protected void EventUpdate_Click(object sender, EventArgs e) {
            string message;
            bool eventCreated = false;
            EventID = helper.GetURlID(Request.QueryString["EventID"], Request);
            try {
                string name = txteventName.Text.Trim();
                string venue = txtVenue.Text.Trim();
                string url = textimageUrl.Text.Trim();
                DateTime eventDateTime;

                if (string.IsNullOrEmpty(name) ||
                               string.IsNullOrEmpty(venue) ||
                               string.IsNullOrEmpty(url) ||
                              !DateTime.TryParse(dateTime.Text, out eventDateTime)) {
                    message = "Please ensure all fields are filled correctly.";
                } else {
                    eventCreated = Partner_service.UpadateEvent(EventID, name, venue, url, eventDateTime);
                    message = eventCreated ? "Event Updated successful!" : "Event Update failed!";
                }

                helper.SendAlert(message, this.GetType(), this.ClientScript);
                if (eventCreated) {
                    Response.Redirect("~/Web%20forms/Partner/Events.aspx");
                }
            } catch (Exception ex) {
                message = "Unable to save event. Please try again later.";
                helper.SendAlert(message + ex.Message, this.GetType(), this.ClientScript);

            }

        }
    }



 
}
