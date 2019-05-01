using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class ProductsHistory
    {
        public int Id { get; set;}

        public Products PurchasedProduct { get; set; }
        public ApplicationUser Purchaser { get; set; }

        public DateTime PurchaseDate { get; set; }
        public int Count { get; set; }

    }
}