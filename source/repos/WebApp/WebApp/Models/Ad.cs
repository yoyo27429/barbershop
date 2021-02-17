using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Ad
    {
        public int AdID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImgPath { get; set; }
    }
}
