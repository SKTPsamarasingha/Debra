using Debra_client.aspx;
using Debra_client.EmployeeService;
using Debra_client.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Employee {
    public partial class CreateEmployee : System.Web.UI.Page {
        UserServiceSoapClient user_service = new UserServiceSoapClient();
        Helper helper = new Helper();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void RegisterEmp_Click(object sender, EventArgs e) {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string role = txtRole.Text.Trim();

            string message = "";

            try {
                Debra_client.UserService.Employee emp = new UserService.Employee();

                emp.Email = helper.ValidateEmail(email) ? email : "";
                emp.Password = helper.ValidatePassword(password) ? password : "";
                emp.FirstName = helper.ValidateString(firstName) ? firstName : "";
                emp.LastName = helper.ValidateString(lastName) ? lastName : ""; ;
                emp.Role = helper.ValidateString(role) ? role : ""; ;

                if (string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(firstName) ||
                    string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(role)) {
                    message = "Please ensure all fields are filled correctly.";
                } else {
                    bool empCretRslt = user_service.CreateUser(emp);
                    message = "Employee registered successfully";
                    helper.SendAlert(message, this.GetType(), this.ClientScript);
                    Response.Redirect("/Web%20forms/Employee/ManageUsers.aspx");
                }


            } catch (Exception ex) {
                helper.SendAlert("Unable to create empolyee. Please try again later." + ex.Message, this.GetType(), this.ClientScript);
            }
        }

    }
}