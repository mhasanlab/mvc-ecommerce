using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;

namespace MyEcommerceAdmin.Controllers
{
    public class ThankYouController : Controller
    {
        //MyEcommerceDbContext db = new MyEcommerceDbContext();
        // GET: ThankYou
        public ActionResult Index()
        {
            ViewBag.cartBox = null;
            ViewBag.Total = null;
            ViewBag.NoOfItem = null;
            TempShpData.items = null;
            return View("Thankyou");
        }
    }
}