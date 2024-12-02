using Debra_service.App_Logic;
using Debra_service.DB_Layer;
using Debra_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Debra_service.Services.Employee {
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService {

        //Empoyee

        [WebMethod]
        public bool AccepteEvent(int eventid, bool isaccepted, decimal cocommission) {
            bool reult = new EventLogic().AccepteEvent(eventid, isaccepted, cocommission);
            return reult;
        }

        [WebMethod]
        public List<Event> GetNewEvents() {
            List<Event> list = new EventLogic().GetNewEvents();
            return list;

        }

        [WebMethod]
        public List<SalesRecord> GetPartnersSalesByID(int partnerid) {
            List<SalesRecord> list = new SalesLogic().GetPartnersSalesByID(partnerid);
            return list;

        }
        [WebMethod]
        public List<SalesRecord> GetAllPartnersSales() {
            List<SalesRecord> list = new SalesLogic().GetAllPartnersSales();
            return list;

        }

        [WebMethod]
        public List<User> GetAllUsers(string usertype) {
            List<User> list = new UserLogic().GetAllUsers(usertype);
            return list;

        }

        [WebMethod]
        public bool SetUserStatus(int userid, bool status) {
            return new UserLogic().SetUserStatus(userid, status);
        }
    }
}
