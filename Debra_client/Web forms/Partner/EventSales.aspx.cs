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
    public partial class EventSales : System.Web.UI.Page {
        PartnerServiceSoapClient Partner_service = new PartnerServiceSoapClient();
        Helper helper = new Helper();
        List<SalesRecord> sales = new List<SalesRecord>();

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
                        sales = salesRslt != null ? salesRslt.ToList() : null;
                        msg = sales != null ? sales.Count.ToString() + "Events found" : "NO events found";


                        rptSales.DataSource = sales;
                        rptSales.DataBind();

                    }
                    helper.SendAlert(msg, this.GetType(), this.ClientScript);

                } catch (Exception ex) {

                    helper.SendAlert("Unable to fetch partner data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);

                }
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