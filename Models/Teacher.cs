using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagementApp.Controllers;
using UniversityManagementApp.Manager;

namespace UniversityManagementApp.Models
{
    public class Teacher
    {
        private TeacherManager teacherManager;
        public Teacher()
        {
          teacherManager = new TeacherManager();  
        }
        public int Id    { get; set; }
        [Required(ErrorMessage = "Please Enter Teacher Name Fisrt")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Special Character is not Allowed")]
      public string Name   { get; set; }



        // property for teacher

        [Required(ErrorMessage = "Please provide teacher Address")]
        public string Address { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a vaild Email")]
        [Remote("isExistMail", "Teacher", HttpMethod = "Post", ErrorMessage = "* This Email is Already in use")]
        public string Email { get; set; }


        // Property for Moble number
        [Required]
        [RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Please enter vaild Mobile Number")]
        [Remote("isExistNumber", "Teacher", HttpMethod = "Post", ErrorMessage = "* Number Already in use")]
        public string Contact { get; set; }



        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Please Select Designation")]
        public string Designation { get; set; }

        public int RemainingCredit { get; set; }

        



        [Required(ErrorMessage = "Credit Limitaion Required")]
        [RegularExpression(@"^(\d*\.)?\d+$", ErrorMessage = "Please Provide vaild credit")]
        public int CreditbeTaken { get; set; }





       





    }
}