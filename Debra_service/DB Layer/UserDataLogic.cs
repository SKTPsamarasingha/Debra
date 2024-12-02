using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Debra_service.Models;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;


namespace Debra_service.DB_Layer {
    public class UserDataLogic {
        public bool CreateUser(User user) {
            UserResult userResult = new UserResult();

            if (user == null) {
               return false;
            }

            try {
                //using (NpgsqlConnection conn = DBAccessLogic.GetPGConn()) {

                    NpgsqlCommand command = new NpgsqlCommand();
                    command.CommandType = CommandType.StoredProcedure;


                    user.Status = true;
                    if (user is Employee) {

                        //Partnter store employee 
                        Employee employee = (Employee)user;
                        command = getEmployeeComd(command, employee);

                    } else if (user is Partner) {

                        //Partnter store Procuderer 
                        Partner partner = (Partner)user;
                        command = getPartnterComd(command, partner);

                    } else if (user is Customer) {

                        //Customer store Procuderer logic
                        Customer customer = (Customer)user;
                        command = getCustomeComd(command, customer);
                    }


                    //conn.Open();
                    //command.Connection = conn;


                    bool result = new DBHelper().ExecuteQuery(command);
                    //conn.Close();
                    return result;
                //}

            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        private NpgsqlCommand getPartnterComd(NpgsqlCommand cmd, Partner partner) {
            if (partner == null) return null;

            cmd.CommandText = "InsertPartner";

            cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, partner.Email);
            cmd.Parameters.AddWithValue("password", NpgsqlTypes.NpgsqlDbType.Varchar, partner.Password);
            cmd.Parameters.AddWithValue("usertype", NpgsqlTypes.NpgsqlDbType.Varchar, "Partner");
            cmd.Parameters.AddWithValue("companyname", NpgsqlTypes.NpgsqlDbType.Varchar, partner.CompanyName);
            cmd.Parameters.AddWithValue("status", NpgsqlTypes.NpgsqlDbType.Boolean, partner.Status);

            return cmd;
        }

        private NpgsqlCommand getEmployeeComd(NpgsqlCommand cmd, Employee employee) {

            if (employee == null) return null;

                                 
            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, employee.Email);
            cmd.Parameters.AddWithValue("password", NpgsqlTypes.NpgsqlDbType.Varchar, employee.Password);
            cmd.Parameters.AddWithValue("usertype", NpgsqlTypes.NpgsqlDbType.Varchar, "Employee");
            cmd.Parameters.AddWithValue("firstname", NpgsqlTypes.NpgsqlDbType.Varchar, employee.FirstName);
            cmd.Parameters.AddWithValue("lastname", NpgsqlTypes.NpgsqlDbType.Varchar, employee.LastName);
            cmd.Parameters.AddWithValue("role", NpgsqlTypes.NpgsqlDbType.Varchar, employee.Role);
            cmd.Parameters.AddWithValue("status", NpgsqlTypes.NpgsqlDbType.Boolean, employee.Status);


            return cmd;
        }

        private NpgsqlCommand getCustomeComd(NpgsqlCommand cmd, Customer customer) {
            if (customer == null) return null;

            cmd.CommandText = "InsertCustomer";
            cmd.Parameters.AddWithValue("email", NpgsqlTypes.NpgsqlDbType.Varchar, customer.Email);
            cmd.Parameters.AddWithValue("password", NpgsqlTypes.NpgsqlDbType.Varchar, customer.Password);
            cmd.Parameters.AddWithValue("usertype", NpgsqlTypes.NpgsqlDbType.Varchar, "Customer");
            cmd.Parameters.AddWithValue("firstname", NpgsqlTypes.NpgsqlDbType.Varchar, customer.Firstname);
            cmd.Parameters.AddWithValue("lastname", NpgsqlTypes.NpgsqlDbType.Varchar, customer.Lastname);
            cmd.Parameters.AddWithValue("phone", NpgsqlTypes.NpgsqlDbType.Varchar, customer.Phone);
            cmd.Parameters.AddWithValue("status", NpgsqlTypes.NpgsqlDbType.Boolean, customer.Status);

            return cmd;
        }


        public bool SetUserStatus(int userid, bool status) {
            string query = @"UPDATE users
                             SET status = @status
                             WHERE userid = @userid;";

            try {

                NpgsqlCommand commd = new NpgsqlCommand();
                commd.CommandText = query;

                commd.Parameters.AddWithValue("@userid", userid);
                commd.Parameters.AddWithValue("@status", status);


                bool result = new DBHelper().ExecuteQuery(commd);

                return result;
            } catch (Exception ex) {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public User LogUser(string email, string password) {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return null;

            try {
                using (NpgsqlConnection conn = DBAccessLogic.GetPGConn()) {
                    string sqlQuery = "SELECT * FROM users WHERE email = @email AND password = @password";

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, conn)) {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);

                        User user = null;
                        NpgsqlDataReader reader = new DBHelper().GetReader(command);

                        if (reader.Read()) {
                            string userType = reader.GetString(3).ToLower();


                            if (userType == "customer") {
                                user = new Customer();
                                user.Userid = reader.GetInt32(0);
                                user = getCustomer(user);

                            } else if (userType == "employee") {
                                user = new Employee();
                                user.Userid = reader.GetInt32(0);

                            } else if (userType == "partner") {
                                user = new Partner();
                                user.Userid = reader.GetInt32(0);
                                user = getPartner(user);
                            }

                            if (user != null) {
                                user.Email = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.UserType = userType;
                                user.Status = reader.GetBoolean(4);

                                conn.Close();
                                return user;
                            } else {
                                Console.WriteLine($"Unknown user type: {userType}");
                                return null;
                            }

                        } else {
                            return null;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        private Partner getPartner(User user) {
            string sqlQuery = "SELECT * FROM partner WHERE userid = @userid";
            NpgsqlConnection conn = DBAccessLogic.GetPGConn();

            try {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, conn)) {
                    command.Parameters.AddWithValue("@userid", user.Userid);

                    NpgsqlDataReader reader = new DBHelper().GetReader(command);

                    Partner partner = (Partner)user;
                    if (reader.HasRows && reader.Read()) {
                        partner.PartnterID = reader.GetInt32(0);
                        partner.CompanyName = reader.GetString(2);
                        return partner;
                    } else {
                        return null;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            } finally {
                conn.Close();
            }
        }

        private Customer getCustomer(User user) {
            string sqlQuery = "SELECT * FROM customer WHERE userid = @userid";
            NpgsqlConnection conn = DBAccessLogic.GetPGConn();

            try {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, conn)) {
                    command.Parameters.AddWithValue("@userid", user.Userid);

                    NpgsqlDataReader reader = new DBHelper().GetReader(command);

                    Customer customer = (Customer)user;
                    if (reader.HasRows && reader.Read()) {
                        customer.CustomerID = reader.GetInt32(0);
                        customer.Firstname = reader.GetString(2);
                        customer.Lastname = reader.GetString(3);
                        customer.Phone = reader.GetString(3);


                        return customer;
                    } else {
                        return null;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            } finally {
                conn.Close();
            }
        }

        public List<User> GetAllUsers(string usertype) {
            string userAttr = "", joinConn = "", groupBy = "";
            string query = "";
            try {
                switch (usertype) {
                    case "Partner":
                        userAttr = groupBy = "p.partnerid, p.companyname";
                        joinConn = "partner p ON u.userid = p.userid";
                        break;
                    case "Employee":
                        userAttr = groupBy = "e.employeeid, e.firstname, e.lastname, e.role";
                        joinConn = "employee e ON u.userid = e.userid";
                        break;
                    case "Customer":
                        userAttr = groupBy = "c.customerid, c.firstname, c.lastname, c.phone";
                        joinConn = "customer c ON u.userid = c.userid";
                        break;
                    default:
                        throw new ArgumentException("Invalid usertype", nameof(usertype));
                }

                query = $@"SELECT u.userid, u.email, u.password, u.usertype, u.status, {userAttr} 
                   FROM users u 
                   INNER JOIN {joinConn} 
                   GROUP BY u.userid, u.email, u.password, u.usertype, u.status, {groupBy}";

                using (var conn = DBAccessLogic.GetPGConn()) {
                    conn.Open();
                    using (var command = new NpgsqlCommand(query, conn))
                    using (var reader = command.ExecuteReader()) {
                        return GetAllUsersList(reader, usertype);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error in GetAllUsers: {ex.Message}");
                throw;
            }
        }

        private List<User> GetAllUsersList(NpgsqlDataReader reader, string usertype) {
            if (reader == null || !reader.HasRows) return new List<User>();

            var users = new List<User>();
            while (reader.Read()) {
                User user = null;
                switch (usertype) {
                    case "Partner":
                        user = new Partner {
                            Userid = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            UserType = reader.GetString(3),
                            Status = reader.GetBoolean(4),
                            PartnterID = reader.GetInt32(5),
                            CompanyName = reader.GetString(6)
                        };
                        break;
                    case "Employee":
                        user = new Employee {
                            Userid = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            UserType = reader.GetString(3),
                            Status = reader.GetBoolean(4),
                            EmployeeID = reader.GetInt32(5),
                            FirstName = reader.GetString(6),
                            LastName = reader.GetString(7),
                            Role = reader.GetString(8)
                        };
                        break;
                    case "Customer":
                        user = new Customer {
                            Userid = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            UserType = reader.GetString(3),
                            Status = reader.GetBoolean(4),
                            CustomerID = reader.GetInt32(5),
                            Firstname = reader.GetString(6),
                            Lastname = reader.GetString(7),
                            Phone = reader.GetString(8)
                        };
                        break;
                }
                if (user != null) {
                    users.Add(user);
                }
            }
            return users;
        }

    }
}
















