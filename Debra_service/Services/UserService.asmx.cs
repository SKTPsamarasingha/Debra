using Debra_service.App_Logic;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Debra_service.Services {
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService {

        [WebMethod]
        public bool CreateUser(User user) {

            bool result = new UserLogic().CreateUser(user);
            return result;

        }

        [WebMethod]
        public User UserLogin(string email, string password) {

            object result = new UserLogic().UserLogin(email, password);
            if (result != null) return result as User;

            return null;
        }



        //[WebMethod]
        //public bool AddEmpylee(string email, string password, string firstname, string lastname, string role) {

        //    bool result = new UserLogic().AddEmployee(email, password, firstname, lastname, role);
        //    return result;
        //}

        //[WebMethod]
        //public bool AddPartner(string email, string password, string companyName) {
        //    bool result = new UserLogic().AddPartner(email, password, companyName);
        //    return result;
        //}

        //[WebMethod]
        //public bool AddCustomer(string email, string password, string firstname, string lastname, string phone) {
        //    bool result = new UserLogic().AddCustomer(email, password, firstname, lastname, phone);
        //    return result;
        //}
    }
}

