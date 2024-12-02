using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace Debra_service.Models {
    public class Ticket {
        private int ticketid, eventid, price, quantity, availableQuantity;
        private string type;
        private bool status;


        public int TicketID { get { return ticketid; } set { ticketid = value; } }
        public int EventID { get { return eventid; } set { eventid = value; } }
        public int Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int AvailableQuantity { get { return availableQuantity; } set { availableQuantity = value; } }
        public string Type { get { return type; } set { type = value; } }
        public bool Status { get { return status; } set { status = value; } }

    }
}