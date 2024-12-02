using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.Web_forms.Users {
    public partial class Index : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }
        protected void UserLogin_Click(object sender, EventArgs e) {
            Response.Redirect("~/Web forms/Users/Userlogin.aspx");
        }
    }
}