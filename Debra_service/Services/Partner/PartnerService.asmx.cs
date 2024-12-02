using Debra_service.App_Logic;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Debra_service.Services.Partner {
    /// <summary>
    /// Summary description for PartnerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PartnerService : System.Web.Services.WebService {

        //Events services

        [WebMethod]
        public bool CreateEvent(int partnerid, string eventName, string venue, string imageUrl, DateTime dateTime) {
            bool result = new EventLogic().CreateEvent(partnerid, eventName, venue, imageUrl, dateTime);
            return result;
        }

        [WebMethod]
        public List<Event> GetPartnersEvents(int partnerid) {
            List<Event> result = new EventLogic().GetPartnersEvents(partnerid);
            return result;
        }

        [WebMethod]
        public List<Event> GetEventsByID(int eventid) {
            List<Event> result = new EventLogic().GetEventByID(eventid);
            return result;
        }

        [WebMethod]
        public List<Event> GetEventByStatus(bool status) {
            List<Event> result = new EventLogic().GetEventByStatus(status);
            return result;
        }

        [WebMethod]
        public bool DeleteEvent(int eventid) {
            bool result = new EventLogic().DeleteEvent(eventid);
            return result;
        }

        [WebMethod]
        public bool UpadateEvent(int eventid, string eventname, string venue, string imageurl, DateTime dateTime) {
            bool result = new EventLogic().UpdateEvent(eventid, eventname, venue, imageurl, dateTime);
            return result;
        }

        //ticker services

        [WebMethod]
        public bool CreateTicket(int eventid, int price, int quantity, string type, bool statues) {
            bool reuslt = new TicketLogic().CreateTicket(eventid, price, quantity, type, statues);
            return reuslt;
        }

        [WebMethod]
        public bool UpdateTicket(string type, int price, int quantity, bool status, int ticketid) {
            bool reuslt = new TicketLogic().UpdateTicket(type, price, quantity, status, ticketid);
            return reuslt;
        }

        [WebMethod]
        public bool DeleteTicket(int ticketid) {
            bool reuslt = new TicketLogic().DeleteTicket(ticketid);
            return reuslt;
        }

        [WebMethod]
        public List<Ticket> GetTicketByID(int ticketID) {
            List<Ticket> reuslt = new TicketLogic().GetTicketByID(ticketID);
            return reuslt;
        }

        [WebMethod]
        public List<Ticket> GetEventTicket(int eventid) {
            List<Ticket> reuslt = new TicketLogic().GetEventTicket(eventid);
            return reuslt;
        }

        // salses service
        [WebMethod]
        public List<SalesRecord> GetPartnersSalesByID(int partnerid) {
            List<SalesRecord> result = new SalesLogic().GetPartnersSalesByID(partnerid);
            return result;
        }


    }
}
