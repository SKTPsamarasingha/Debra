using Debra_service.Models;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Debra_service.DB_Layer {
    public class EventDataLogic {

        public bool CreateEvent(Event newEvent) {

            try {
                if (newEvent == null) return false;

                string query = @"
            INSERT INTO Events (PartnerID, EventName, Venue, isAccepted, ImageUrl,DateTime)
            VALUES (@PartnerID, @EventName, @Venue, @isAccepted, @ImageUrl,@DateTime)";

                NpgsqlCommand command = new NpgsqlCommand(query);

                command.Parameters.AddWithValue("@PartnerID", newEvent.PartnerID);
                command.Parameters.AddWithValue("@EventName", newEvent.EventName);
                command.Parameters.AddWithValue("@Venue", newEvent.Venue);
                command.Parameters.AddWithValue("@isAccepted", false);
                command.Parameters.AddWithValue("@ImageUrl", newEvent.ImageUrl);
                command.Parameters.AddWithValue("@DateTime", newEvent.DateTime);


                bool result = new DBHelper().ExecuteQuery(command);

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }


        }



        public List<Event> GetPartnersEvents(int partnerid) {
            string query = "select * from events where partnerid = @partnerid";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@partnerid", partnerid);

                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetEventList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();


            }

        }




        public List<Event> GetEventByID(int eventid) {
            string query = "select * from events where eventid = @eventID";
            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@eventID", eventid);


                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetEventList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();
            }



        }


        public List<Event> GetEventByStatus(bool status) {
            string query = "select * from events where isaccepted = @isaccepted";
            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@isaccepted", @status);


                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetEventList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();
            }
        }




        public bool DeleteEvent(int eventid) {

            string query = "delete from events where eventid = @eventID";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@eventID", eventid);


                bool result = new DBHelper().ExecuteQuery(commd);
                return result;


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateEvent(Event updateEvent) {
            string query = "UPDATE events " +
                           "SET eventname = @eventname, " +
                           "venue = @venue, imageurl = @imageurl, datetime = @datetime " +
                           "WHERE eventid = @eventid;";

            try {

                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;

                commd.Parameters.AddWithValue("@eventid", updateEvent.EventID);
                commd.Parameters.AddWithValue("@eventname", updateEvent.EventName);
                commd.Parameters.AddWithValue("@venue", updateEvent.Venue);
                commd.Parameters.AddWithValue("@imageurl", updateEvent.ImageUrl);
                commd.Parameters.AddWithValue("@datetime", updateEvent.DateTime);

                bool result = new DBHelper().ExecuteQuery(commd);

                return result;
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }



        // Employee logics
        public List<Event> GetAllEvents() {
            string query = " select * from events";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;

                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetEventList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();


            }

        }
        public bool AccepteEvent(Event accepteEvent) {

            string query = "UPDATE events SET isaccepted = @isaccepted, commission = @commission WHERE eventid = @eventid;";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;

                commd.Parameters.AddWithValue("@isaccepted", accepteEvent.IsAccepted);
                commd.Parameters.AddWithValue("@commission", accepteEvent.Commission);
                commd.Parameters.AddWithValue("@eventid", accepteEvent.EventID);


                bool result = new DBHelper().ExecuteQuery(commd);

                return result;
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Event> GetNewEvents() {
            string query = @"SELECT 
    p.PartnerID,
    p.CompanyName,
    e.EventID,
    e.EventName,
    e.Venue,
    e.datetime,
    COALESCE(SUM(t.price * t.quantity), 0) AS RevenueProjections
FROM 
    Events e
JOIN 
    Partner p ON p.PartnerID = e.PartnerID
LEFT JOIN 
    Ticket t ON e.EventID = t.EventID
WHERE 
    e.isaccepted = false
GROUP BY
    p.PartnerID, p.CompanyName, e.EventID, e.EventName, e.Venue, e.datetime
ORDER BY 
    MAX(e.datetime) DESC;
";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;

                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetNewEventList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();


            }
        }

        //Customerr
        public List<Event> GetPurchase(int customerID) {
            string query = @"select 
e.eventname,
e.venue,
e.imageurl,
e.datetime
from
events e 
join
ticket t on  t.eventid = e.eventid
join
sales s on s.ticketid  = t.ticketid
where customerid = @customerID";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@customerID", customerID);


                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                return GetPurchaseEvents(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return new List<Event>();
            }

        }


        private List<Event> GetNewEventList(NpgsqlDataReader reader) {
            if (!reader.HasRows) return new List<Event>();

            List<Event> newEvents = new List<Event>();


            while (reader.Read()) {

                Event ev = new Event {


                    PartnerID = reader.GetInt32(0),
                    CompanyName = reader.GetString(1),
                    EventID = reader.GetInt32(2),
                    EventName = reader.GetString(3),
                    Venue = reader.GetString(4),
                    DateTime = reader.GetDateTime(5),
                    Revenu = reader.GetDecimal(6)

                };
                newEvents.Add(ev);
            }
            return newEvents;
        }
        private List<Event> GetEventList(NpgsqlDataReader reader) {
            if (!reader.HasRows) return new List<Event>();

            List<Event> events = new List<Event>();

            while (reader.Read()) {

                Event ev = new Event {

                    EventID = reader.GetInt32(0),
                    PartnerID = reader.GetInt32(1),
                    EventName = reader.GetString(2),
                    Venue = reader.GetString(3),
                    IsAccepted = reader.GetBoolean(4),
                    ImageUrl = reader.GetString(5),
                    DateTime = reader.GetDateTime(6),
                };
                events.Add(ev);
            }
            return events;
        }

        private List<Event> GetPurchaseEvents(NpgsqlDataReader reader) {
            if (!reader.HasRows) return new List<Event>();

            List<Event> events = new List<Event>();

            while (reader.Read()) {

                Event ev = new Event {

                    EventName = reader.GetString(0),
                    Venue = reader.GetString(1),
                    ImageUrl = reader.GetString(2),
                    DateTime = reader.GetDateTime(3),
                };
                events.Add(ev);
            }
            return events;
        }

    }
}