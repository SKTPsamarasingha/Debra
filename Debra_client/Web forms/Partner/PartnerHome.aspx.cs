using Debra_client.PartnerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.aspx.Partner {
    public partial class PartnerHome : System.Web.UI.Page {

        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();
        Helper helper = new Helper();
        List<SalesRecord> sales = new List<SalesRecord>();
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

                        var salesRslt = Partner_service.GetPartnersSalesByID(partnerID);
                        msg = salesRslt != null ? salesRslt.Count().ToString() + "Sales are Found!" : "No sales record";
                        rptSales.DataSource = salesRslt;
                        rptSales.DataBind();
                    }
                    helper.SendAlert(msg, this.GetType(), this.ClientScript);
                } catch (Exception ex) {

                    helper.SendAlert("Unable to fetch partner data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

                }
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
                case "ShowEventBtn":
                    redirectString = "~/Web%20forms/Partner/Events.aspx";
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


    }
}