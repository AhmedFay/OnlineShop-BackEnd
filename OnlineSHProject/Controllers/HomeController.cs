using OnlineSHProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

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

            var c = new ProductsCart()
            {
                Product = products,
            };

            db.Cart.Add(c);
            return View(products);
        }


    }
}