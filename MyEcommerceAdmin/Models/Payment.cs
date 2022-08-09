using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Payment
    {
        public Payment()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int PaymentID { get; set; }
        public int Type { get; set; }
        public Nullable<decimal> CreditAmount { get; set; }
        public Nullable<decimal> DebitAmount { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<System.DateTime> PaymentDateTime { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}