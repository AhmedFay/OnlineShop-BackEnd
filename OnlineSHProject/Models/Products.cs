using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast.Selectors;

namespace OnlineSHProject.Models
{
   
    public class Products
    {

        public int Id { get; set; }
        public string ProductName { get; set; }
        //public string Color { get; set; }
        //public string Size { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        //public float Cost { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public int NumVote { get; set; }
        public int SumVote { get; set; }
        public string Company { get; set; }

        public string ProductCode { get; set; }
        public string TAGS { get; set; }
        public List<Attributes> Attributes { get; set; }
        public List<Vote> Vote { get; set; }
        public string ImagePath { get; set; }

        public ApplicationUser ShopOwner { get; set; }

        //= new List<Attributes>
        //{
        //    new Attributes(0,"Size","S,M,L,Xl",this),
        //    new Attributes(1,"Color", "Red, Yellow, Black, White,Brown"),
        //    new Attributes(2,"Ctatagories", "Select Ctatagories, Women, Men, Kids, Accessories, Food"),
        //    new Attributes (3,"Availability","Available, UnAvailable"),
        //};





    }
}