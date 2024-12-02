using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.Models {
    public class Partner : User {
        private int partnerid;
        private string companyName;



        public int PartnterID { get { return partnerid; } set { partnerid = value; } }

        public string CompanyName { get { return companyName; } set { companyName = value; } }

    }
}