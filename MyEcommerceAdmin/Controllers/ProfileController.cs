using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;

namespace MyEcommerceAdmin.Controllers
{
    public class ProfileController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.admin_Employee.Find(TemData.EmpID));
        }
    }
}