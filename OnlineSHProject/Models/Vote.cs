using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int value { get; set; }
        public string Comment { get; set; }
        public Products products { get; set; }
       


    }
}