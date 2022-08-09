using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;

namespace MyEcommerceAdmin.Controllers
{
    public class SupplierController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // CREATE: Supplier

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier suplr)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(suplr);
                db.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Error");
        }


        // EDIT: Supplier

        public ActionResult Edit(int id)
        {
            Supplier suplr = db.Suppliers.Single(x => x.SupplierID == id);
            if (suplr == null)
            {
                return HttpNotFound();
            }
            return View(suplr);
        }

        [HttpPost]
        public ActionResult Edit(Supplier suplr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suplr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suplr);
        }


        // DETAILS: Supplier

        public ActionResult Details(int id)
        {
            Supplier suplr = db.Suppliers.Find(id);
            if (suplr == null)
            {
                return HttpNotFound();
            }
            return View(suplr);
        }

        // DELETE: Supplier

        public ActionResult Delete(int id)
        {
            Supplier suplr = db.Suppliers.Find(id);
            if (suplr == null)
            {
                return HttpNotFound();
            }
            return View(suplr);
        }

        //Post Delete Confirmed

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier suplr = db.Suppliers.Find(id);
            db.Suppliers.Remove(suplr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}