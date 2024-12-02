using Debra_client.aspx;
using Debra_client.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Customer {
    public partial class CustomerHome : System.Web.UI.Page {
        CustomerServiceSoapClient CustomerService = new CustomerServiceSoapClient();
        List<Event> events = new List<Event>();
        Helper helper = new Helper();
        int CustomerID;
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                if (Request.Cookies["id"] != null && int.TryParse(Request.Cookies["id"].Value, out int id)) {
                    this.CustomerID = id;
                    ViewState["customerID"] = CustomerID;
                }

                var eventsRslt = CustomerService.GetPurchase(CustomerID);
                events = eventsRslt != null ? eventsRslt.ToList() : new List<Event>();

                rptEvents.DataSource = events;
                rptEvents.DataBind();

            }

        }
    }
}