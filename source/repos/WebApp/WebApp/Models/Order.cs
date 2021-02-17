using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Choose Date")]
        public DateTime BookDate { get; set; }
        [Display(Name = "Choose Time")]
        public string BookTime { get; set; }
        public string Status { get; set; }

        //Navigation Properties
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public Review Review { get; set; }
        public ICollection<OrderService> OrderServices { get; set; }

    }
}
