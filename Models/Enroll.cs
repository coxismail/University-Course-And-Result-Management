using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class Enroll
    {
        [Required(ErrorMessage = "Please Select Registration Number")]
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public string CourseCode { get; set; }
        public DateTime Date { get; set; }
        public string Grade { get; set; }
    }
}