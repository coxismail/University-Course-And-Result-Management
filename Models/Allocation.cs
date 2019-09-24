using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace UniversityManagementApp.Models
{
    public class Allocation
    {
        [Required(ErrorMessage = "Select a department")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Select a Course")]
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        [Required(ErrorMessage = "Select  Room No")]
        public int? RoomNo { get; set; }

        [Required(ErrorMessage = "Select a Day")]
        public string Day { get; set; }




        [Required(ErrorMessage = "Time is Required")]
        //validate:Must be greater than current date
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm}")]
      //  [Remote("isBooked", "Allocation", ErrorMessage = "This time allready sheduled for another")]
         [RegularExpression(@"^(1[0-2]|0?[1-9]):([0-5]?[0-9])([AP]M)?$",ErrorMessage = "Time is not in Correct Format")]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }














        [Required(ErrorMessage = "Time is  Required")]
        //validate:must be greater than StartDate
        [DataType(DataType.Time)]

        [RegularExpression(@"^(1[0-2]|0?[1-9]):([0-5]?[0-9])([AP]M)?$", ErrorMessage = "Time is not in Correct Format")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm}")]
        public string EndTime { get; set; }

    }
}