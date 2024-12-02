using Debra_client.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra_client.aspx {
    public class Helper {

        public bool renderRptData(Repeater repeater, List<Object> list) {

            if (list == null) {
                return false;
            } else {
                repeater.DataSource = list;
                repeater.DataBind();
                return true;
            }
        }

        public bool ValidateEmail(string email) {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);

        }
        public bool ValidateString(string str) {
            string stringPattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch((string)str, stringPattern) && !string.IsNullOrEmpty(str);

        }

        public bool ValidatePhoneNumber(string phoneNumber) {
            string phonePattern = @"^\+?[0-9]{10,15}$";
            return Regex.IsMatch(phoneNumber, phonePattern) && !string.IsNullOrEmpty(phoneNumber);
        }


        //public bool ValidatePhoneNumber(string phoneNumber) {
        //    string phonePattern = @"^\+?[0-9]{1,3}?[-. ]?\(?[0-9]{1,4}?\)?[-. ]?[0-9]{1,4}[-. ]?[0-9]{1,9}$";
        //    return !string.IsNullOrEmpty(phoneNumber) && Regex.IsMatch(phoneNumber, phonePattern);
        //}

        public bool ValidatePassword(string password) {
            return !string.IsNullOrEmpty(password) &&
             password.Length >= 3 &&
             password.Any(char.IsDigit);
        }

        public void SendAlert(string msg, Type type, ClientScriptManager scrpt) {

            scrpt.RegisterStartupScript(type, "alert", $"alert('{msg}');", true);

        }


      


        public int GetURlID(string urlStr, HttpRequest request ) {
            int id;
            if (!string.IsNullOrEmpty(urlStr)) {
                id = int.Parse(urlStr);
             
                return id;
            }
            return -1;
        }

    }



}