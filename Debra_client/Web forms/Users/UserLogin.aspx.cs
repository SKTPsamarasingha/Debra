using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.aspx;
using Debra_client.UserService;

namespace Debra_client.Web_forms.Users {
    public partial class UserLogin : System.Web.UI.Page {

        UserServiceSoapClient user_service = new UserServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void BtnLogin_Click(object sender, EventArgs e) {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            Helper helper = new Helper();


            User user = user_service.UserLogin(email, password);

            if (user != null) {

                if (user.Status.Equals(true)) {


                    string userType = user.UserType;
                    HttpCookie IdCookie = new HttpCookie("id");
                    string redirectString = "";
                    int id = -1;


                    if (userType.ToLower() == "customer") {
                        Debra_client.UserService.Customer customer = (Debra_client.UserService.Customer)user;
                        id = customer.CustomerID;
                        redirectString = "~/Web%20forms/Customer/ShowEvents.aspx";

                    } else if (userType.ToLower() == "employee") {
                        Debra_client.UserService.Employee employee = (Debra_client.UserService.Employee)user;
                        id = employee.EmployeeID;
                        redirectString = "~/Web%20forms/Employee/EmployeeHome.aspx";

                    } else if (userType.ToLower() == "partner") {

                        Debra_client.UserService.Partner partner = (Debra_client.UserService.Partner)user;
                        id = partner.PartnterID;
                        redirectString = "~/Web%20forms/Partner/PartnerHome.aspx";

                    }


                    IdCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(IdCookie);
                    IdCookie.Value = id.ToString();


                    Response.Redirect(redirectString);

                } else {
                    helper.SendAlert("Sorry you have been blocked" , this.GetType(), this.ClientScript);
                }

            } else {
                helper.SendAlert("Invalid Emial or passowrd", this.GetType(), this.ClientScript);

            }

        }
    }
}