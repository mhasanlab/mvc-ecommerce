using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        public int SupplierID { get; set; }
        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required, Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [Required, Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}