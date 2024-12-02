using Debra_service.App_Logic;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Debra_service.Services.Customer {
    /// <summary>
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService {

        [WebMethod]
        public bool CreateSale(int customerid, int ticketid, int quantity, decimal total) {
            bool result = new SalesLogic().CreateSale(customerid, ticketid, quantity, total);
            return result;

        }

        [WebMethod]
        public List<Event> GetEventByStatus(bool status) {
            List<Event> result = new EventLogic().GetEventByStatus(status);
            return result;
        }


        [WebMethod]
        public List<Event> GetEventByID(int eventid) {
            List<Event> result = new EventLogic().GetEventByID(eventid);
            return result;
        }

        [WebMethod]
        public List<Ticket> GetEventTicket(int eventid) {
            List<Ticket> reuslt = new TicketLogic().GetEventTicket(eventid);
            return reuslt;
        }

        [WebMethod]
        public List<Event> GetPurchase(int CustomreID) {
            List<Event> reuslt = new EventLogic().GetPurchase(CustomreID);
            return reuslt;
        }
    }
}
