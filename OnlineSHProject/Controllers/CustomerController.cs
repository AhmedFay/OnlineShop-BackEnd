using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSHProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult ShoppingCart()
        {
            return View();
        }

    }
}