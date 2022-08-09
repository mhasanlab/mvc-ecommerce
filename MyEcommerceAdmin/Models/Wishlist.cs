using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Wishlist
    {
        [Key]
        public int WishlistID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Nullable<bool> isActive { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}