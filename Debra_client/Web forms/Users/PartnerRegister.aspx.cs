using Debra_client.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.aspx.User_aspx {
    public partial class PartnerRegister : System.Web.UI.Page {

        UserServiceSoapClient user_service = new UserServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Register_Click(object sender, EventArgs e) {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string companyName = textCompanyName.Text;



            //Object user = user_service.AddPartner(email, password, companyName);
       

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