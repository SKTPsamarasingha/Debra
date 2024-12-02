using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace Debra_service.Models {
    public class Event : Partner {
        private int eventid, partnerid;
        private decimal revenu, commission;
        private string eventname, venue, imgeUrl;
        private bool Isaccepted;
        private DateTime EventDateTime;


        public int EventID { get { return eventid; } set { eventid = value; } }

        public int PartnerID { get { return partnerid; } set { partnerid = value; } }
        public decimal Commission { get { return commission; } set { commission = value; } }

        public decimal Revenu { get { return revenu; } set { revenu = value; } }

        public string EventName { get { return eventname; } set { eventname = value; } }
        public string Venue { get { return venue; } set { venue = value; } }
        public string ImageUrl { get { return imgeUrl; } set { imgeUrl = value; } }
        public bool IsAccepted { get { return Isaccepted; } set { Isaccepted = value; } }


        public DateTime DateTime { get { return EventDateTime; } set { EventDateTime = value; } }

    }
}