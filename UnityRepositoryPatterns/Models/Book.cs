using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityRepositoryPatterns.Models
{
    public class Book
    {
        public long BookID { get; set; }
        public string BookName { get; set; }
        public string Descrption { get; set; }
        public decimal Price { get; set; }
        public long AutherID { get; set; }
        public long TagID { get; set; }
        public string test { get; set; }
        public string AddNew { get; set; }
    }
}