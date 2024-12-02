using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;

namespace Debra_service.Models {
    public class Employee: User{

        private int employeeID;
        private string firstName, lastName, role;


        public int EmployeeID { get { return employeeID; } set { employeeID = value; } }

        public string FirstName { get { return firstName; } set { firstName = value; } }

        public string LastName { get { return lastName; } set { lastName = value; } }

        public string Role { get { return role; } set { role = value; } }
    }
}