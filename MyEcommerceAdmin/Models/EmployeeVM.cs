using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public class EmployeeVM
    {
        public int EmpID { get; set; }
        [Display(Name = "First Name")]
        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string LastName { get; set; }
        [
            Required,
            Display(Name = "Birth Date"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            DataType(DataType.Date)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Required, DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number contains only Numbers")]
        public string Phone { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
        public HttpPostedFileBase Picture { get; set; }

    }
}