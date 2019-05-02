using OnlineSHProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineSHProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return View(SearchProducts(searchString));
            }
        }

        public ActionResult Vote(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Vote(Vote v)
        {
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Products> SearchProducts(string T)
        {
            T = T.ToLower();
            var Result = db.Products.Where(
                p => p.ProductName.ToLower().Contains(T) ||
                p.Company.ToLower().Contains(T) ||
                p.Category.ToString().ToLower().Contains(T) ||
                p.Attributes.Any(a => a.AttribName.ToLower().Contains(T))).ToList();

            return Result;

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        [Authorize]
        public ActionResult AddtoCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }

            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);

            var c = new ProductsCart()
            {
                Product = products,
                User = user
            };

            db.Cart.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ShowCart()
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);
            ViewBag.myuser = user;


            var myCarts = db.Cart.Where(c => c.User.Id == userid).Include(u => u.Product).ToList();

            return View(myCarts);
        }

        [Authorize]
        public ActionResult ConfirmOrder()
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);

            var myCarts = db.Cart.Where(c => c.User.Id == userid).ToList();

            foreach (var cart in myCarts)
            {
                var c = new Order()
                {
                    Product = cart.Product,
                    User = user
                };
                db.Orders.Add(c);
            }

            db.SaveChanges();

            return View();
        }


    }
}