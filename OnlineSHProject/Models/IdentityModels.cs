using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace OnlineSHProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        { }


        //[Display(Name = "User Name")]
        //public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstN { get; set; }

        [Display(Name = "Last Name")]
        public string LastN { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        public bool IsAccepted { get; set; }

        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }          
       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<OnlineSHProject.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<OnlineSHProject.Models.ProductsCart> Cart { get; set; }

        public System.Data.Entity.DbSet<OnlineSHProject.Models.ProductsHistory> History { get; set; }

        public System.Data.Entity.DbSet<Notification> Notifications { get; set; }

        public System.Data.Entity.DbSet<OnlineSHProject.Models.Attributes> Attributes { get; set; }

        public System.Data.Entity.DbSet<OnlineSHProject.Models.Vote> Votes { get; set; }

        //public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        // public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        // public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }

        //  public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }
        //  public object ApplicationUser { get; internal set; }

        //public System.Data.Entity.DbSet<OnlineSHProject.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}