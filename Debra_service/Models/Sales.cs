using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.Models {
    public class Sales {
       private int salesid, customerid, ticketid, quantity;
       private decimal total;


        public int SalesID { get { return salesid; } set { salesid = value; } }
        public int CustomerID { get {   return customerid; } set {  customerid = value; } }
        public int TicketID { get { return ticketid; } set {    ticketid = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal Total { get { return total; } set { total = value; } }       
    }
}