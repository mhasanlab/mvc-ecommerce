using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
namespace MyEcommerceAdmin.Controllers
{
    
    public class EmployeeController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.admin_Employee.ToList());
        }

        // CREATE: Employee


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(EmployeeVM evm)
        {

            if (ModelState.IsValid)
            {
                if (evm.Picture !=null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(evm.Picture.FileName));
                    evm.Picture.SaveAs(Server.MapPath(filePath));

                    admin_Employee e = new admin_Employee
                    {
                        EmpID = evm.EmpID,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        DateofBirth = evm.DateofBirth,
                        Gender = evm.Gender,
                        Email = evm.Email,
                        Address = evm.Address,
                        Phone = evm.Phone,
                        PicturePath = filePath
                    };
                    db.admin_Employee.Add(e);
                    db.SaveChanges();
                    return PartialView("_Success");
                }
            }
            return PartialView("_Error");
        }

        // EDIT: Employee

        public ActionResult Edit(int id)
        {
            admin_Employee emp = db.admin_Employee.Find(id);

            EmployeeVM evm = new EmployeeVM
            {
                EmpID = emp.EmpID,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                DateofBirth = emp.DateofBirth,
                Gender = emp.Gender,
                Email = emp.Email,
                Address = emp.Address,
                Phone = emp.Phone,
                PicturePath = emp.PicturePath

            };
            return View(evm);
        }

        [HttpPost]

        public ActionResult Edit(EmployeeVM evm)
        {

            if (ModelState.IsValid)
            {
                string filePath = evm.PicturePath;
                if (evm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(evm.Picture.FileName));
                    evm.Picture.SaveAs(Server.MapPath(filePath));

                    admin_Employee e = new admin_Employee
                    {
                        EmpID = evm.EmpID,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        DateofBirth = evm.DateofBirth,
                        Gender = evm.Gender,
                        Email = evm.Email,
                        Address = evm.Address,
                        Phone = evm.Phone,
                        PicturePath = filePath
                    };
                    db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    admin_Employee e = new admin_Employee
                    {
                        EmpID = evm.EmpID,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        DateofBirth = evm.DateofBirth,
                        Gender = evm.Gender,
                        Email = evm.Email,
                        Address = evm.Address,
                        Phone = evm.Phone,
                        PicturePath = filePath
                    };
                    db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return PartialView(evm);
        }



        // VIEW: Employee Details

        public ActionResult Info(int id)
        {
            admin_Employee emp = db.admin_Employee.Find(id);

            EmployeeVM evm = new EmployeeVM
            {
                EmpID = emp.EmpID,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                DateofBirth = emp.DateofBirth,
                Gender = emp.Gender,
                Email = emp.Email,
                Address = emp.Address,
                Phone = emp.Phone,
                PicturePath = emp.PicturePath

            };
            return View(evm);
        }

        [HttpPost]

        public ActionResult Info(EmployeeVM evm)
        {

            if (ModelState.IsValid)
            {
                string filePath = evm.PicturePath;
                if (evm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(evm.Picture.FileName));
                    evm.Picture.SaveAs(Server.MapPath(filePath));

                    admin_Employee e = new admin_Employee
                    {
                        EmpID = evm.EmpID,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        DateofBirth = evm.DateofBirth,
                        Gender = evm.Gender,
                        Email = evm.Email,
                        Address = evm.Address,
                        Phone = evm.Phone,
                        PicturePath = filePath
                    };
                    db.Entry(e).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    admin_Employee e = new admin_Employee
                    {
                        EmpID = evm.EmpID,
                        FirstName = evm.FirstName,
                        LastName = evm.LastName,
                        DateofBirth = evm.DateofBirth,
                        Gender = evm.Gender,
                        Email = evm.Email,
                        Address = evm.Address,
                        Phone = evm.Phone,
                        PicturePath = filePath
                    };
                    db.Entry(e).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return PartialView(evm);
        }


        // DELETE: Employee

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            admin_Employee employee = db.admin_Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            admin_Employee employee = db.admin_Employee.Find(id);
            string file_name = employee.PicturePath;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.admin_Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}