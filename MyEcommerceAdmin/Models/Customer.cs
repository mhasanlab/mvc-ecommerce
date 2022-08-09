using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            this.RecentlyViews = new HashSet<RecentlyView>();
            this.Reviews = new HashSet<Review>();
            this.Wishlists = new HashSet<Wishlist>();
        }
        [Key]
        public int CustomerID { get; set; }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RecentlyView> RecentlyViews { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}