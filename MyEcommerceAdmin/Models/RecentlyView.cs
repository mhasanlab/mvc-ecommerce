using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class RecentlyView
    {
        [Key]
        public int RViewID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime ViewDate { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}