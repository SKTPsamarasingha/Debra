using Debra_client.aspx;
using Debra_client.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Employee {
    public partial class ManageUsers : System.Web.UI.Page {
        EmployeeServiceSoapClient employee_servirce = new EmployeeServiceSoapClient();

        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                try {
                    changeTable("GetEmployee");
                } catch (Exception ex) {
                    helper.SendAlert("Unable to fetch User data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
                }

            }

        }

        protected void Button_Click(object sender, EventArgs e) {
            Button clickedButton = (Button)sender;
            string buttonId = clickedButton.ID;
            changeTable(buttonId);
        }

        protected void AddEmployee_Click(object sender, EventArgs e) {
            Response.Redirect("/Web%20forms/Employee/CreateEmployee.aspx");
        }
        protected void changeTable(string btnID) {
            try {
                string userType = "";
                Repeater rpt = new Repeater();
                switch (btnID) {
                    case "GetCutomers":
                        userType = "Customer";
                        rpt = rptCustomer;
                        CustomerContainer.Visible = true;
                        PartnersContainer.Visible = false;
                        EmployeeContainer.Visible = false;
                        break;
                    case "GetPartners":
                        userType = "Partner";
                        rpt = rptPartner;
                        CustomerContainer.Visible = false;
                        PartnersContainer.Visible = true;
                        EmployeeContainer.Visible = false;

                        break;
                    case "GetEmployee":
                        userType = "Employee";
                        rpt = rptEmployee;
                        CustomerContainer.Visible = false;
                        PartnersContainer.Visible = false;
                        EmployeeContainer.Visible = true;
                        break;
                }
                var userRslt = employee_servirce.GetAllUsers(userType);
                List<User> list = userRslt != null ? userRslt.ToList() : null;

                rpt.DataSource = list;
                rpt.DataBind();



            } catch (Exception ex) {
                helper.SendAlert("Unable to fetch User data. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }




        protected void BtnActivate_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int userid = int.Parse(btn.CommandArgument);
            string msg = "";
            Button clickedButton = (Button)sender;
            string btnCls = clickedButton.CssClass.Split(' ')[1];

            try {
                bool result = employee_servirce.SetUserStatus(userid, true);
                msg = result ? "Successfully user activated" : "Failed to avtive user";
                helper.SendAlert(msg, this.GetType(), this.ClientScript);
                changeTable(btnCls);
            } catch (Exception ex) {
                helper.SendAlert("Unable to change User status. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }

        protected void BtnDeactivate_Click(object sender, EventArgs e) {
            Button btn = (Button)sender;
            int userid = int.Parse(btn.CommandArgument);
            string msg = "";
            Button clickedButton = (Button)sender;
            string btnCls = clickedButton.CssClass.Split(' ')[1];

            try {
                bool result = employee_servirce.SetUserStatus(userid, false);
                msg = result ? "Successfully user deactivated" : "Failed to deactivated user";
                helper.SendAlert(msg, this.GetType(), this.ClientScript);
                changeTable(btnCls);
            } catch (Exception ex) {
                helper.SendAlert("Unable to change User status. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }
    }
}