using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class admin_Login
    {
        [Key]
        public int LoginID { get; set; }
        public int EmpID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleType { get; set; }
        public string Notes { get; set; }

        public virtual admin_Employee admin_Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}