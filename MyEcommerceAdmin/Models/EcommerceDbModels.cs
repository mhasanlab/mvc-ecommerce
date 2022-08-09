using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class MyEcommerceDbContext : DbContext
    {
        public MyEcommerceDbContext()
            : base("name=MyEcommerceDbContext")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        public virtual DbSet<admin_Employee> admin_Employee { get; set; }
        public virtual DbSet<admin_Login> admin_Login { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<genMainSlider> genMainSliders { get; set; }
        public virtual DbSet<genPromoRight> genPromoRights { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RecentlyView> RecentlyViews { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingDetail> ShippingDetails { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
    }
}