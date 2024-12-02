using Debra_service.Models;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace Debra_service.DB_Layer {
    public class TicketDataLogic {


        public bool CreateTicket(Ticket ticket) {
            string query = "INSERT INTO Ticket (EventID, Type, Price, Quantity, Status) VALUES (@EventID, @Type, @Price, @Quantity, @Status);";

            try {
                NpgsqlCommand command = new NpgsqlCommand(query);

                command.Parameters.AddWithValue("@EventID", ticket.EventID);
                command.Parameters.AddWithValue("@Type", ticket.Type);
                command.Parameters.AddWithValue("@Price", ticket.Price);
                command.Parameters.AddWithValue("@Quantity", ticket.Quantity);
                command.Parameters.AddWithValue("@Status", true);


                bool result = new DBHelper().ExecuteQuery(command);

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        public bool UpdateTicket(Ticket ticket) {
            string query = "UPDATE Ticket SET Type = @Type, Price = @Price, Quantity = @Quantity, Status = @Status WHERE TicketID = @TicketID";

            try {
                NpgsqlCommand commd = new NpgsqlCommand(query);

                commd.Parameters.AddWithValue("@Type", ticket.Type);
                commd.Parameters.AddWithValue("@Price", ticket.Price);
                commd.Parameters.AddWithValue("@Quantity", ticket.Quantity);
                commd.Parameters.AddWithValue("@Status", ticket.Status);
                commd.Parameters.AddWithValue("@TicketID", ticket.TicketID);


                bool result = new DBHelper().ExecuteQuery(commd);

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        public bool DeleteTicket(int ticketid) {

            string query = "delete from ticket where ticketid = @ticketid";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@ticketid", ticketid);


                bool result = new DBHelper().ExecuteQuery(commd);
                return result;


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public List<Ticket> GetEventTicket(int eventid) {
            string query = @"SELECT 
    t.TicketID,
    t.EventID,
    t.Type,
    t.Price,
    t.Quantity AS OriginalQuantity,
    COALESCE(t.Quantity - SUM(COALESCE(s.Quantity, 0)), t.Quantity) AS AvailableQuantity,
    t.Status
FROM 
    Ticket t
LEFT JOIN 
    Sales s ON t.TicketID = s.TicketID
WHERE 
    t.EventID = @eventid
GROUP BY 
    t.TicketID, t.EventID, t.Type, t.Price, t.Quantity, t.Status;";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@eventid", eventid);

                NpgsqlDataReader reader = new DBHelper().GetReader(commd);

                return GetTicketList(reader);


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }

        }


        public List<Ticket> GetTicketByID(int ticketid) {
            string query = @"SELECT 
    t.TicketID,
    t.EventID,
    t.Type,
    t.Price,
    t.Quantity AS OriginalQuantity,
    COALESCE(t.Quantity - SUM(COALESCE(s.Quantity, 0)), t.Quantity) AS AvailableQuantity,
    t.Status
FROM 
    Ticket t
LEFT JOIN 
    Sales s ON t.TicketID = s.TicketID
WHERE 
    t.TicketID = @ticketid
GROUP BY 
    t.TicketID, t.EventID, t.Type, t.Price, t.Quantity, t.Status;";

            try {
                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;
                commd.Parameters.AddWithValue("@ticketid", ticketid);

                NpgsqlDataReader reader = new DBHelper().GetReader(commd);
                List<Ticket> result = GetTicketList(reader);
                return result;


            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private List<Ticket> GetTicketList(NpgsqlDataReader reader) {
            if (!reader.HasRows || reader == null) return new List<Ticket>();

            List<Ticket> tickets = new List<Ticket>();

            while (reader.Read()) {

                Ticket ticket = new Ticket {

                    TicketID = reader.GetInt32(0),
                    EventID = reader.GetInt32(1),
                    Type = reader.GetString(2),
                    Price = reader.GetInt32(3),
                    Quantity = reader.GetInt32(4),
                    AvailableQuantity = reader.GetInt32(5),
                    Status = reader.GetBoolean(6),

                };
                tickets.Add(ticket);
            }
            return tickets;
        }
    }
}