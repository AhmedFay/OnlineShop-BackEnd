﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSHProject.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SenderName { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        [Required]
        public ApplicationUser User { get; set; }
    }
}