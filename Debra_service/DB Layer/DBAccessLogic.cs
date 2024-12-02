using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
namespace Debra_service.DB_Layer {
    public class DBAccessLogic {
        static readonly string connString = "Host=localhost;Username=postgres;Password=chefThiruna@#$1997;Database=Debra";

        public static NpgsqlConnection GetPGConn() {
            return new NpgsqlConnection(connString);
        }
    }
}