using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementApp.Models
{
    public class AssignCourse
    {
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "Please Select Teacher")]
        public int TeacherId { get; set; }

        public int CreditbeTaken { get; set; }
        
        public int RemainingCredit { get; set; }
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Please Select Coure Code")]
        [Remote("isAlreadyAssigned", "AssignCourse", HttpMethod = "Post", ErrorMessage = "This Course Already Assigned")]
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public int Credit { get; set; }
    }
}