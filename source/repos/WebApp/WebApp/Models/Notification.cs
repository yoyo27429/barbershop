using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CustomerID { get; set; }

        //Navigation Property
        public Customer Customer { get; set; }

    }
}
