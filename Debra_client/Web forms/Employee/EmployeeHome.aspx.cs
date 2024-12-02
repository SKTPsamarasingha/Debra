using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.EmployeeService;


namespace Debra_client.aspx.Employee {
    public partial class EmployeeHome : System.Web.UI.Page {

        EmployeeServiceSoapClient employee_servirce = new EmployeeServiceSoapClient();

        List<Event> newEvents = new List<Event>();
        List<SalesRecord> sales = new List<SalesRecord>();
        Helper helper = new Helper();
        bool reuslt = false;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                var events = employee_servirce.GetNewEvents();

                newEvents = events != null ? events.ToList() : new List<Event>();


                rptNewevents.DataSource = newEvents;
                rptNewevents.DataBind();


            }
        }

        protected void btnAccpet_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            int eventID = int.Parse(((Button)item.FindControl("btnAccept")).CommandArgument);

            TextBox txtCommission = (TextBox)item.FindControl("txtcommission");
            string commissionStr = txtCommission.Text;
            decimal commission;
            bool result = false;

            try {

                if (!decimal.TryParse(commissionStr, out commission)) {
                    helper.SendAlert("Invalid commission input. Please enter a valid number.", this.GetType(), this.ClientScript);

                    return;
                }

                if (eventID > 0) {
                    result = employee_servirce.AccepteEvent(eventID,true, commission);
                }

                if (result) {
                    newEvents = employee_servirce.GetNewEvents().ToList();
                    helper.SendAlert("successfully accpted evenet.", this.GetType(), this.ClientScript);

                    helper.renderRptData(rptNewevents, newEvents.Cast<Object>().ToList());

                    
                } else {
                    helper.SendAlert("Failed to accpted evenet.", this.GetType(), this.ClientScript);

                }

            } catch (Exception ex) {
                helper.SendAlert("Uable to accpet event" + ex.Message, this.GetType(), this.ClientScript);

            }
        }
    }
}