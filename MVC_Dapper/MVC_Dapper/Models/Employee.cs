using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Dapper.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Posititon { get; set; }
        public int Employee_Age { get; set; }
        public int Employee_Salary { get; set; }
    }
}
