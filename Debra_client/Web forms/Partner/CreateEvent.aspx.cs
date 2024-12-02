using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.PartnerService;

namespace Debra_client.aspx.Partner {
    public partial class CrateEvent : System.Web.UI.Page {

        Helper helper = new Helper();
        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();


        int PartnerID;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {
                    if (Request.Cookies["id"] != null) {
                        if (int.TryParse(Request.Cookies["id"].Value, out int partnerID)) {
                            PartnerID = partnerID;

                        }
                    }
                } catch (Exception ex) {

                    helper.SendAlert("Unable to fetch partner data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

                }

            }
        }
        protected void EventCreate_Click(object sender, EventArgs e) {

            string message;
            bool eventCreated = false;
            int PartnerID = GetPartnerIDFromCookie();
            try {

                if (PartnerID == -1) {
                    message = "It looks like your session expired. Try logging in again!";
                    return;
                }
                string name = txteventName.Text.Trim();
                string venu = txtVenue.Text.Trim();
                string url = textimageUrl.Text.Trim();

                string datetime = DateTime.Parse(dateTime.Text).ToString();
                if (string.IsNullOrEmpty(name) ||
                               string.IsNullOrEmpty(venu) ||
                               string.IsNullOrEmpty(url) ||
                               string.IsNullOrEmpty(datetime)) {
                    message = "Please ensure all fields are filled correctly.";
                } else {

                    eventCreated = Partner_service.CreateEvent(PartnerID, name, venu, url, DateTime.Parse(dateTime.Text));
                    message = eventCreated ? "Event creation successful!" : "Event creation failed!";

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
        private int GetPartnerIDFromCookie() {
            if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int partnerID)) {
                return partnerID;
            }
            return -1;
        }


    }
}