using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Student Name")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Special Character is not Allowed")]
        public string Name { get; set; }

        public string RegNo { get; set; }
    
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a vaild Email")]
        [Remote("isExistMail", "Student", HttpMethod = "Post", ErrorMessage = "* This Email is Already in use")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Please enter vaild Mobile Number")]
        [Remote("isExistNumber", "Student", HttpMethod = "Post", ErrorMessage = "* Number Already in use")]
        public string Contact { get; set; }

                [Required(ErrorMessage = "Please Student Address")]
        public string Address { get; set; }
        public string Date { get; set; }
        
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentCode { get; set; }
    }
}