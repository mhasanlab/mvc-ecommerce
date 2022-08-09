using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class Category
    {
        public Category()
        {
            this.genPromoRights = new HashSet<genPromoRight>();
            this.Products = new HashSet<Product>();
            this.SubCategories = new HashSet<SubCategory>();
        }

        [Key]
        public int CategoryID { get; set; }
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> isActive { get; set; }

        public virtual ICollection<genPromoRight> genPromoRights { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}