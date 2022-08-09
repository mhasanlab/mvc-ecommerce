using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;

namespace MyEcommerceAdmin.Controllers
{
    public class CustomerController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // CREATE: Customer

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(CustomerVM cvm)
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
                        Gender= cvm.Gender,
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
                    return PartialView("_Success");
                }
            }
            return PartialView("_Error");
        }


        // EDIT: Customer
        public ActionResult Edit(int id)
        {
            Customer cus = db.Customers.Find(id);

            CustomerVM cvm = new CustomerVM
            {
                CustomerID = cus.CustomerID,
                First_Name = cus.First_Name,
                Last_Name = cus.Last_Name,
                UserName = cus.UserName,
                Password = cus.Password,
                Gender = cus.Gender,
                DateofBirth = cus.DateofBirth,
                Country = cus.Country,
                City = cus.City,
                PostalCode = cus.PostalCode,
                Email = cus.Email,
                Phone = cus.Phone,
                Address = cus.Address,
                PicturePath = cus.PicturePath,
                status = cus.status,
                LastLogin = cus.LastLogin,
                Created = cus.Created,
                Notes = cus.Notes

            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult Edit(CustomerVM cvm)
        {

            if (ModelState.IsValid)
            {
                string filePath = cvm.PicturePath;
                if (cvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(cvm.Picture.FileName));
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
                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
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
                    db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return PartialView(cvm);
        }

        // DITELS: Customer

        public ActionResult Details(int id)
        {
            Customer cus = db.Customers.Find(id);

            CustomerVM cvm = new CustomerVM
            {
                CustomerID = cus.CustomerID,
                First_Name = cus.First_Name,
                Last_Name = cus.Last_Name,
                UserName = cus.UserName,
                Password = cus.Password,
                Gender = cus.Gender,
                DateofBirth = cus.DateofBirth,
                Country = cus.Country,
                City = cus.City,
                PostalCode = cus.PostalCode,
                Email = cus.Email,
                Phone = cus.Phone,
                Address = cus.Address,
                PicturePath = cus.PicturePath,
                status = cus.status,
                LastLogin = cus.LastLogin,
                Created = cus.Created,
                Notes = cus.Notes

            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult Details(CustomerVM cvm)
        {

            if (ModelState.IsValid)
            {
                string filePath = cvm.PicturePath;
                if (cvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(cvm.Picture.FileName));
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
                    db.Entry(c).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
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
                    db.Entry(c).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return PartialView(cvm);
        }

        // DELETE: Customer

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Customer customer = db.Customers.Find(id);
            string file_name = customer.PicturePath;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}