using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Ast.Selectors;

namespace OnlineSHProject.Models
{
    public class Attributes
    {
        public Attributes(int v1, string v2, string v3,Products v4)
        {
            Id = v1;
            AttribName = v2;
            AttribDescription = v3;
            product = v4;
        }

        public int Id { get; set; }
        public string AttribName { get; set; }
        public string AttribDescription { get; set; }
        public Products product { get; set; } 
    }

   

    
}