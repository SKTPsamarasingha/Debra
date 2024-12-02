using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.Models {
    public class Customer: User {

        private int customerid;
        private string firstname, lastname, phone;
        public int CustomerID { get { return customerid; } set { customerid = value; } }

        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
    }
}