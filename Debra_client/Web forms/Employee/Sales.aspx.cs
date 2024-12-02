using Debra_client.aspx;
using Debra_client.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Employee {
    public partial class Sales : System.Web.UI.Page {
        EmployeeServiceSoapClient employee_servirce = new EmployeeServiceSoapClient();
        List<Event> newEvents = new List<Event>();
        List<SalesRecord> sales = new List<SalesRecord>();
        Helper helper = new Helper();
        bool reuslt = false;
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                try {

                    var salesRcords = employee_servirce.GetAllPartnersSales();
                    sales = salesRcords != null ? salesRcords.ToList() : new List<SalesRecord>();
                    rptSales.DataSource = sales;
                    rptSales.DataBind();
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch Sales data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }
            }
        }

        protected void SearchBtn_Click(object sender, EventArgs e) {
            try {
                string msg = "";
                string input = EmpEventSrchBar.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(input)) helper.SendAlert("Please enter a company name", this.GetType(), this.ClientScript);
                var salesRcords = employee_servirce.GetAllPartnersSales();

                var matchingSales = salesRcords.Where(sale => sale.Companyname.ToLower().Contains(input)).ToList();

                if (matchingSales.Any()) {
                    sales.Clear();
                    sales.AddRange(matchingSales);
                    msg = $"Found {matchingSales.Count} matching companies.";
                } else {
                    sales = salesRcords.Any() ? salesRcords.ToList() : null;
                    msg = "Cannot find a matching company";
                }


                helper.SendAlert(msg, this.GetType(), this.ClientScript);
                rptSales.DataSource = sales;
                rptSales.DataBind();

            } catch (Exception ex) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Unable to fetch Sales data. Please try again later. Error: {ex.Message}');", true);
            }
        }
    }
}