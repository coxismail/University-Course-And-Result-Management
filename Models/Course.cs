using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace UniversityManagementApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Corse Code")]
        [MinLength(5, ErrorMessage = "Code at least 5 Character long")]
        [Remote("isExistCode", "Course", HttpMethod = "Post", ErrorMessage = "* Course Code is Already Exist")]

        public string Code { get; set; }


        
        [Required(ErrorMessage = "Enter course name")]
        [Remote("isExistName", "Course", HttpMethod = "Post", ErrorMessage = "* Course Name is Already Exist")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter course credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be between 0.5 and 5")]
        public double Credit { get; set; }


        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }



        [Required(ErrorMessage = "Select Department")]
        public string DepartmentCode { get; set; }



        [Required(ErrorMessage = "Select Semester")]
        public string Semester { get; set; }

       public string AssignTo { get; set; }
       public int TeacherId { get; set; }
    }
}
