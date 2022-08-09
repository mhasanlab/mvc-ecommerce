using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            this.Payments = new HashSet<Payment>();
        }
        [Key]
        public int PayTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}