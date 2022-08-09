using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
using System.Data;
using System.IO;

namespace MyEcommerceAdmin.Controllers
{
    public class AccountController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();

        // GET: Account
        public ActionResult Index()
        {
            this.GetDefaultData();

            var usr = db.Customers.Find(TempShpData.UserID);
            return View(usr);

        }


        //REGISTER CUSTOMER
        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(cust);
                db.SaveChanges();

                Session["username"] = cust.UserName;
                TempShpData.UserID = GetUser(cust.UserName).CustomerID;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        //LOG IN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formColl)
        {
            string usrName = formColl["UserName"];
            string Pass = formColl["Password"];

            if (ModelState.IsValid)
            {
                var cust = (from m in db.Customers
                            where (m.UserName == usrName && m.Password == Pass)
                            select m).SingleOrDefault();

                if (cust != null)
                {
                    TempShpData.UserID = cust.CustomerID;
                    Session["username"] = cust.UserName;
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        //LOG OUT
        public ActionResult Logout()
        {
            Session["username"] = null;
            TempShpData.UserID = 0;
            TempShpData.items = null;
            return RedirectToAction("Index", "Home");
        }



        public Customer GetUser(string _usrName)
        {
            var cust = (from c in db.Customers
                        where c.UserName == _usrName
                        select c).FirstOrDefault();
            return cust;
        }

        //UPDATE CUSTOMER DATA
        [HttpPost]
        public ActionResult Update(Customer cust)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                Session["username"] = cust.UserName;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // CREATE: Customer

        public ActionResult RegisterCustomer()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RegisterCustomer(CustomerVM cvm)
        {

            if (ModelState.IsValid)
            {
                if (cvm.Picture != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(cvm.Picture.FileName));
                    cvm.Picture.SaveAs(Server.MapPath(filePath));

                    Customer c = new Customer
                    {
                        CustomerID = cvm.CustomerID,
                        First_Name = cvm.First_Name,
                        Last_Name = cvm.Last_Name,
                        UserName = cvm.UserName,
                        Password = cvm.Password,
                        Gender = cvm.Gender,
                        DateofBirth = cvm.DateofBirth,
                        Country = cvm.Country,
                        City = cvm.City,
                        PostalCode = cvm.PostalCode,
                        Email = cvm.Email,
                        Phone = cvm.Phone,
                        Address = cvm.Address,
                        PicturePath = filePath,
                        status = cvm.status,
                        LastLogin = cvm.LastLogin,
                        Created = cvm.Created,
                        Notes = cvm.Notes
                    };
                    db.Customers.Add(c);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            return PartialView("_Error");
        }



    }
}