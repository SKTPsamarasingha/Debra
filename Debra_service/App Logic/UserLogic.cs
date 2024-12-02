using Debra_service.DB_Layer;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Debra_service.App_Logic {
    public class UserLogic {

        public bool CreateUser(User user) {
            return new UserDataLogic().CreateUser(user);
        }

        public object UserLogin(string email, string password) {
            return new UserDataLogic().LogUser(email, password);
        }

        public List<User> GetAllUsers(string usertype) {
            return new UserDataLogic().GetAllUsers(usertype);


        }


        public bool SetUserStatus(int userid, bool status) {
            return new UserDataLogic().SetUserStatus(userid, status);
        }

        //public bool AddEmployee(string email, string password, string firstname, string lastname, string role) {

        //    Employee employee = new Employee();
        //    employee.Email = email;
        //    employee.Password = password;
        //    employee.FirstName = firstname;
        //    employee.LastName = lastname;
        //    employee.Role = role;

        //    return new UserDataLogic().CreateUser(employee);
        //}

        //public bool AddPartner(string email, string password, string companyName) {

        //    Partner partner = new Partner();

        //    partner.Email = email;
        //    partner.Password = password;
        //    partner.CompanyName = companyName;
        //    partner.IsActive = false;

        //    return new UserDataLogic().CreateUser(partner);

        //}

        //public bool AddCustomer(string email, string password, string firstname, string lastname, string phone) {
        //    Customer customer = new Customer();

        //    customer.Email = email;
        //    customer.Password = password;
        //    customer.Firstname = firstname;
        //    customer.Lastname = lastname;
        //    customer.Phone = phone;

        //    return new UserDataLogic().CreateUser(customer);


        //}


    }
}