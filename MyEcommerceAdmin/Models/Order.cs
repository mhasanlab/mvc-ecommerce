using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<int> ShippingID { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Taxes { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<bool> isCompleted { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<bool> DIspatched { get; set; }
        public Nullable<System.DateTime> DispatchedDate { get; set; }
        public Nullable<bool> Shipped { get; set; }
        public Nullable<System.DateTime> ShippingDate { get; set; }
        public Nullable<bool> Deliver { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> CancelOrder { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}