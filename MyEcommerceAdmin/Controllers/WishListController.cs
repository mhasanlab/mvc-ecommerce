using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyEcommerceAdmin.Models;

namespace MyEcommerceAdmin.Controllers
{
    public class WishListController : Controller
    {
        MyEcommerceDbContext db = new MyEcommerceDbContext();

        // GET: WishList
        public ActionResult Index()
        {
            this.GetDefaultData();

            var wishlistProducts = db.Wishlists.Where(x => x.CustomerID == TempShpData.UserID).ToList();
            return View(wishlistProducts);
        }

        //REMOVE ITEM FROM WISHLIST
        public ActionResult Remove(int id)
        {
            db.Wishlists.Remove(db.Wishlists.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //ADD TO CART WISHLIST
        public ActionResult AddToCart(int id)
        {
            OrderDetail OD = new OrderDetail();

            int pid = db.Wishlists.Find(id).ProductID;
            OD.ProductID = pid;
            int Qty = 1;
            decimal price = db.Products.Find(pid).UnitPrice;
            OD.Quantity = Qty;
            OD.UnitPrice = price;
            OD.TotalAmount = Qty * price;
            OD.Product = db.Products.Find(pid);

            if (TempShpData.items == null)
            {
                TempShpData.items = new List<OrderDetail>();
            }
            TempShpData.items.Add(OD);

            db.Wishlists.Remove(db.Wishlists.Find(id));
            db.SaveChanges();

            return Redirect(TempData["returnURL"].ToString());

        }
    }
}