using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public class SupplierVM
    {
        public int SupplierID { get; set; }
        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required, Display(Name = "Contact Name"), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string ContactName { get; set; }
        [Required, Display(Name = "Contact Title"), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number contains only Numbers")]
        public string Phone { get; set; }
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}