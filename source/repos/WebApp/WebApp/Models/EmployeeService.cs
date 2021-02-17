using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class EmployeeService
    {
        public int EmployeeServiceID { get; set; }
        public int EmployeeID { get; set; }
        public int ServiceID { get; set; }

        //Navigation Properties
        public Employee Employee { get; set; }
        public Service Service { get; set; }

    }
}
