using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OrderService
    {
        public int OrderServiceID { get; set; }
        public int OrderID { get; set; }
        public int ServiceID { get; set; }

        //Navigation Properties
        public Order Order { get; set; }
        public Service Service { get; set; }

    }
}
