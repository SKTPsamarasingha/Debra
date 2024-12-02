using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Debra_service.DB_Layer;

namespace Debra_service.App_Logic {
    public class SalesLogic {


        //Customer
        public bool CreateSale(int customerid, int ticketid, int quantity, decimal total) {
            Sales newSale = new Sales();

            newSale.CustomerID = customerid;
            newSale.TicketID = ticketid;
            newSale.Quantity = quantity;
            newSale.Total = total;

            bool result = new SalesDataLogic().CreateSale(newSale);
            return result;
        }

        //Employee
        public List<SalesRecord> GetPartnersSalesByID(int partnerid) {
            List<SalesRecord> sales = new SalesDataLogic().GetPartnersSalesByID(partnerid);
            return sales;
        }

        public List<SalesRecord> GetAllPartnersSales() {
            List<SalesRecord> sales = new SalesDataLogic().GetAllPartnersSales();
            return sales;
        }
        
    }
}