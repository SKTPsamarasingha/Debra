using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Debra_client.UserService;

namespace Debra_client.aspx.User_aspx {
    public partial class CustomerRegister : System.Web.UI.Page {

        UserServiceSoapClient user_service = new UserServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Register_Click(object sender, EventArgs e) {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string firstName = textfirstName.Text;
            string lastName = textLastName.Text;
            string phone = textPhone.Text;

            //Object user = user_service.AddCustomer(email, password, firstName, lastName, phone);

            //if (user != null) {

            //    Response.Write(user.ToString());
            //} else {
            //    {
            //        Response.Write("User not found");
            //    }

            //}
        }
    }
}