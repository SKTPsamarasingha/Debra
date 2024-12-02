using Debra_service.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.DB_Layer {
    public class DBHelper {

        public bool ExecuteQuery(NpgsqlCommand command) {
            if (command == null) return false;

            try {
                NpgsqlConnection conn = DBAccessLogic.GetPGConn();
                command.Connection = conn;
                conn.Open();

                int result = command.ExecuteNonQuery();
                conn.Close();
                return result > 0;


            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public NpgsqlDataReader GetReader(NpgsqlCommand command) {
            if (command == null) return null;

            try {
                NpgsqlConnection conn = DBAccessLogic.GetPGConn();
                command.Connection = conn;
                conn.Open();

                NpgsqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                return reader;
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}