using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    
    public class Review
    {
        public int ReviewID { get; set; }
        // public int EmployeeID { get; set; }
        // public int CustomerID { get; set; }
        public int OrderID { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }


        //Navigation Proporty
        // public Employee Employee { get; set; }
        // public Customer Customer { get; set; }
        //public Order Order { get; set; }
    }
}
