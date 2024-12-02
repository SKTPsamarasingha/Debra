using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.Models {
    public class SalesRecord {
        int eventid, titcketsold, commission, partnerid;
        string eventname, venue,companyname;
        decimal totalsales, commissionrate, totalcommission, aftercommission;

        public int EventID { get { return eventid; } set { eventid = value; } }

        public int TicketsSold { get { return titcketsold; } set { titcketsold = value; } }

        public int Commission { get { return commission; } set { commission = value; } }
        public int Partnerid { get { return partnerid; } set { partnerid = value; } }


        public string Eventname { get { return eventname; } set { eventname = value; } }

        public string Venue { get { return venue; } set { venue = value; } }
        public string Companyname { get { return companyname; } set { companyname = value; } }


        public decimal Totalsales { get { return totalsales; } set { totalsales = value; } }

        public decimal Commissionrate { get { return commissionrate; } set { commissionrate = value; } }
        public decimal Totalcommission { get { return totalcommission; } set { totalcommission = value; } }

        public decimal Aftercommission { get { return aftercommission; } set { aftercommission = value; } }

    }

}




