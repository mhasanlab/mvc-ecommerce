using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;
using System.Data;

namespace MyEcommerceAdmin.Controllers
{
    public class CheckOutController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();
        // GET: CheckOut
        public ActionResult Index()
        {
            ViewBag.PayMethod = new SelectList(db.PaymentTypes, "PayTypeID", "TypeName");


            var data = this.GetDefaultData();

            return View(data);
        }


        //PLACE ORDER--LAST STEP
        public ActionResult PlaceOrder(FormCollection getCheckoutDetails)
        {

            int shpID = 1;
            if (db.ShippingDetails.Count() > 0)
            {
                shpID = db.ShippingDetails.Max(x => x.ShippingID) + 1;
            }
            int payID = 1;
            if (db.Payments.Count() > 0)
            {
                payID = db.Payments.Max(x => x.PaymentID) + 1;
            }
            int orderID = 1;
            if (db.Orders.Count() > 0)
            {
                orderID = db.Orders.Max(x => x.OrderID) + 1;
            }



            ShippingDetail shpDetails = new ShippingDetail();
            shpDetails.ShippingID = shpID;
            shpDetails.FirstName = getCheckoutDetails["FirstName"];
            shpDetails.LastName = getCheckoutDetails["LastName"];
            shpDetails.Email = getCheckoutDetails["Email"];
            shpDetails.Mobile = getCheckoutDetails["Mobile"];
            shpDetails.Address = getCheckoutDetails["Address"];
            shpDetails.City = getCheckoutDetails["City"];
            shpDetails.PostCode = getCheckoutDetails["PostCode"];
            db.ShippingDetails.Add(shpDetails);
            db.SaveChanges();

            Payment pay = new Payment();
            pay.PaymentID = payID;
            pay.Type = Convert.ToInt32(getCheckoutDetails["PayMethod"]);
            db.Payments.Add(pay);
            db.SaveChanges();

            Order o = new Order();
            o.OrderID = orderID;
            o.CustomerID = TempShpData.UserID;
            o.PaymentID = payID;
            o.ShippingID = shpID;
            o.Discount = Convert.ToInt32(getCheckoutDetails["discount"]);
            o.TotalAmount = Convert.ToInt32(getCheckoutDetails["totalAmount"]);
            o.isCompleted = true;
            o.OrderDate = DateTime.Now;
            db.Orders.Add(o);
            db.SaveChanges();

            foreach (var OD in TempShpData.items)
            {
                OD.OrderID = orderID;
                OD.Order = db.Orders.Find(orderID);
                OD.Product = db.Products.Find(OD.ProductID);
                db.OrderDetails.Add(OD);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "ThankYou");

        }

    }
}