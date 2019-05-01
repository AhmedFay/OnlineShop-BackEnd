using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class NotificationVM
    {
        [Required] 
        public string Email { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { set; get; }
    }
}