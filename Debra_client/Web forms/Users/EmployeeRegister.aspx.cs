using System;
using System.Web.UI;
using Debra_client.UserService;

namespace Debra_client.aspx.User_aspx {
    public partial class EmployeeRegister : System.Web.UI.Page {
        UserServiceSoapClient user_service = new UserServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void Register_Click(object sender, EventArgs e) {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string role = txtRole.Text;

            //Object user = user_service.AddEmpylee(email, password, firstName, lastName, role);

            Response.Write("hello");
           
        }
    }
}
