using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineSHProject.Models;

namespace OnlineSHProject.Controllers
{
    // [Authorize (Roles = "Admin, ShopOwner")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Products.ToList());
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

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Price,Amount,Category,Availability,ProductCode, Description, ExpireDate")] Products products, HttpPostedFileBase img)
        {

            if (!ImageIsValid(img))
            {
                ModelState.AddModelError("img", "Please Choose an image file and png extension");
            }

            if (ModelState.IsValid)
            {
                var ext = Path.GetExtension(img.FileName);
                var path = Server.MapPath($"~/Images/{products.ProductName}{ext}");
                img.SaveAs(path);

                var userid = User.Identity.GetUserId();
                var user = db.Users.Find(userid);

                products.ShopOwner = user;
                products.Date = DateTime.Now;
                products.ImagePath = path;
                db.Products.Add(products);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(products);
        }

        public ActionResult Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Price,Amount,Category,Availability,ProductCode, Description, ExpireDate")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowOrders()
        {
            var userid = User.Identity.GetUserId();
            var user = db.Users.Find(userid);


            var myOrder = db.Orders.Where(o => o.Product.ShopOwner.Id == userid).ToList();

            return View(myOrder);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool ImageIsValid(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength <= 0)
            {
                return false;
            }

            //if (file.ContentLength > 1 * 1024 * 1024)
            //{
            //    return false;
            //}

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png);
                }
            }
            catch { }
            return false;
        }

    }
}
