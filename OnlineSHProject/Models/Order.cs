using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public Products Product { get; set; }
        public ApplicationUser User { get; set; }

    }
}