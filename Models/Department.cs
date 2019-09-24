using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementApp.Models
{
    public class Department
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Enter Department Code")]
        [StringLength(7, ErrorMessage = " Department Code Should be 2 to 7 character long", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Special Character is not Allowed")]
        [Remote("isExistCode", "Department", HttpMethod = "Post", ErrorMessage = "* Department code is Already Exist")]

        public string Code { get; set; }




        [Required(ErrorMessage = "Enter your department name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Special Character is not Allowed")]
        [Remote("isExistName", "Department", HttpMethod = "Post", ErrorMessage = "* Department Name is Already Exist")]
        public string Name { get; set; }
    }
}