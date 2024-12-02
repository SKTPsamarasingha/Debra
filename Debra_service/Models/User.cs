using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Debra_service.Models {

    [XmlInclude(typeof(Employee))]
    [XmlInclude(typeof(Customer))]
    [XmlInclude(typeof(Partner))]
    abstract public class User {


        private int userid;
        private string email, password, userType;
        bool status;

        public int Userid { get { return userid; } set { userid = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string Password { get { return password; } set { password = value; } }

        public string UserType { get { return userType; } set { userType = value; } }
        public bool Status { get { return status; } set { status = value; } }

    }
}