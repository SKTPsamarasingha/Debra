using Debra_service.DB_Layer;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace Debra_service.App_Logic {
    public class TicketLogic {

        public bool CreateTicket(int eventid, int price, int quantity, string type, bool status) {
            Ticket ticket = new Ticket();


            ticket.EventID = eventid;
            ticket.Price = price;
            ticket.Quantity = quantity;
            ticket.Type = type;
            ticket.Status = status;

            bool result = new TicketDataLogic().CreateTicket(ticket);
            return result;
        }
        public bool UpdateTicket(string type, int price, int quantity, bool status, int ticketid) {
            Ticket ticket = new Ticket();

            ticket.Type = type;
            ticket.Price = price;
            ticket.Quantity = quantity;
            ticket.Status = status;
            ticket.TicketID = ticketid;


            bool result = new TicketDataLogic().UpdateTicket(ticket);
            return result;
        }

        public bool DeleteTicket(int ticketid) {
            bool result = new TicketDataLogic().DeleteTicket(ticketid);
            return result;
        }

        public List<Ticket> GetTicketByID(int ticketid) {
            List<Ticket> result = new TicketDataLogic().GetTicketByID(ticketid);
            return result;
        }
        public List<Ticket> GetEventTicket(int eventid) {
            List<Ticket> result = new TicketDataLogic().GetEventTicket(eventid);
            return result;
        }
    }
}

