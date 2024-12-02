using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using Debra_service.App_Logic;
using Debra_service.Models;
using Npgsql;

namespace Debra_service.DB_Layer {
    public class SalesDataLogic {

        //Customer
        public bool CreateSale(Sales newSale) {
            string query = "INSERT INTO Sales (CustomerID, TicketID, Quantity, Total) VALUES (@CustomerID, @TicketID, @Quantity, @Total);";


            try {
                NpgsqlCommand command = new NpgsqlCommand(query);

                command.Parameters.AddWithValue("@CustomerID", newSale.CustomerID);
                command.Parameters.AddWithValue("@TicketID", newSale.TicketID);
                command.Parameters.AddWithValue("@Quantity", newSale.Quantity);
                command.Parameters.AddWithValue("@Total", newSale.Total);

                bool result = new DBHelper().ExecuteQuery(command);

                return result;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        //Employee
        public List<SalesRecord> GetAllPartnersSales() {
            string query = @"SELECT 
    p.PartnerID,
    p.CompanyName,
    e.EventID,
    e.EventName,
    e.Venue,
    SUM(s.Quantity) AS TicketsSold,
    SUM(s.total) AS TotalSales,
    e.Commission AS CommissionRate,
    ROUND(SUM(s.total * e.Commission)/100) AS TotalCommission,
    ROUND(SUM(s.total - (s.total * e.Commission)/100)) AS AfterCommission
FROM 
    Events e
JOIN 
    Ticket t ON e.EventID = t.EventID
JOIN 
    Sales s ON t.TicketID = s.TicketID
JOIN 
    Partner p ON p.PartnerID = e.PartnerID
GROUP BY
    p.PartnerID, p.CompanyName, e.EventID, e.EventName, e.Venue, e.Commission
ORDER BY 
    MAX(e.datetime) DESC;";

            try {
                NpgsqlCommand command = new NpgsqlCommand(query);



                NpgsqlDataReader reader = new DBHelper().GetReader(command);

                return GetAllPartnerSalesList(reader);


            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        //Partner
        public List<SalesRecord> GetPartnersSalesByID(int partnerid) {
            string query = @"SELECT
e.EventID AS EventID,
    e.EventName AS EventName,
    e.Venue AS Venue,
    e.Commission AS CommissionRate,
    SUM(s.Quantity) AS TicketsSold,
    SUM(s.total) AS TotalSales,
     ROUND(SUM(s.total * e.Commission)/100) AS TotalCommission,
    ROUND(SUM(s.total - (s.total * e.Commission)/100)) AS AfterCommission
FROM 
    Events e
JOIN 
    Ticket t ON e.EventID = t.EventID
JOIN 
    Sales s ON t.TicketID = s.TicketID
WHERE 
    e.PartnerID = @partnerid
GROUP BY 
    e.EventID, e.EventName, e.Venue, e.Commission
ORDER BY 
    MAX(e.datetime) DESC";


            try {
                NpgsqlCommand command = new NpgsqlCommand(query);
                command.Parameters.AddWithValue("@partnerid", partnerid);


                NpgsqlDataReader reader = new DBHelper().GetReader(command);

                return GetPartnerSalesList(reader);


            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }


        public List<SalesRecord> GetPartnerSalesList(NpgsqlDataReader reader) {
            if (reader == null || !reader.HasRows) return null;
            List<SalesRecord> salesList = new List<SalesRecord>();

            try {
                while (reader.Read()) {
                    SalesRecord sale = new SalesRecord {

                        EventID = reader.GetInt32(reader.GetOrdinal("EventID")),
                        TicketsSold = reader.GetInt32(reader.GetOrdinal("TicketsSold")),
                        Eventname = reader.GetString(reader.GetOrdinal("eventname")),

                        Venue = reader.GetString(reader.GetOrdinal("Venue")),
                        Totalsales = reader.GetDecimal(reader.GetOrdinal("Totalsales")),
                        Commissionrate = reader.GetDecimal(reader.GetOrdinal("Commissionrate")),
                        Totalcommission = reader.GetDecimal(reader.GetOrdinal("Totalcommission")),
                        Aftercommission = reader.GetDecimal(reader.GetOrdinal("aftercommission")),
                    };



                    salesList.Add(sale);
                }
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred while reading sales data: {ex.Message}");
                throw;
            } finally {
                reader.Close();
            }

            return salesList;
        }

        public List<SalesRecord> GetAllPartnerSalesList(NpgsqlDataReader reader) {
            if (reader == null || !reader.HasRows) return null;
            List<SalesRecord> salesList = new List<SalesRecord>();

            try {
                while (reader.Read()) {
                    SalesRecord sale = new SalesRecord {

                        Companyname = reader.GetString(reader.GetOrdinal("companyname")),
                        Partnerid = reader.GetInt32(reader.GetOrdinal("PartnerID")),

                        EventID = reader.GetInt32(reader.GetOrdinal("EventID")),
                        TicketsSold = reader.GetInt32(reader.GetOrdinal("TicketsSold")),
                        Eventname = reader.GetString(reader.GetOrdinal("eventname")),

                        Venue = reader.GetString(reader.GetOrdinal("Venue")),
                        Totalsales = reader.GetDecimal(reader.GetOrdinal("Totalsales")),
                        Commissionrate = reader.GetDecimal(reader.GetOrdinal("Commissionrate")),
                        Totalcommission = reader.GetDecimal(reader.GetOrdinal("Totalcommission")),
                    };

                    salesList.Add(sale);
                }
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred while reading sales data: {ex.Message}");
                throw;
            } finally {
                reader.Close();
            }

            return salesList;
        }

    }
}

