using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using OnlineSHProject.Models;
using System.Net;
using System.Data.Entity;
using System.Threading.Tasks;

namespace OnlineSHProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context;

        public AdminController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var user  = context.Users.ToList();
            return View(user);
        }

        // GET: Products
        public ActionResult IndexProducts()
        {
            return View(context.Products.ToList());
        }

        // GET: Products/Create
        public ActionResult CreateProducts()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProducts([Bind(Include = "Id,ProductName,Price,Amount")] Products products)
        {
            if (ModelState.IsValid)
            {
                //var cost = products.Amount * products.Price;

                //products.Cost = cost;
                context.Products.Add(products);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult EditProducts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = context.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProducts([Bind(Include = "Id,ProductName,Color,Size,Price,Amount,Cost")] Products products)
        {
            if (ModelState.IsValid)
            {
                context.Entry(products).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult DeleteProducts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = context.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = context.Products.Find(id);
            context.Products.Remove(products);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UserManage()
        {
            var users = context.Users.Where(u => !u.IsAccepted).ToList();
            return View(users);
        }

        public ActionResult Details(string id)
        {
            var users = context.Users.Find(id);
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
        //[HttpGet]
        //public ActionResult SendNotification()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<ActionResult> SendNotification(NotificationVM vm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByEmailAsync(vm.Email);
        //        if ( user == null)
        //        {
        //            MadelState.AddModelError("Email", "The Email is incorrect");
        //            return View(vm);
        //        }
        //        user.Notifications.Add(new Notification()
        //        {
        //            Title = vm.Title,
        //            Content = vm.Content,
        //            User = user

        //        });
        //        await db.SvaeChangeAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View (vm);
        //}
    }

}