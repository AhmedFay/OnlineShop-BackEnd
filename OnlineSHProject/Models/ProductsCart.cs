using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class ProductsCart
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public Products Product { get; set; }
        public ApplicationUser User { get; set; }    
    }
}