using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class EnrollController : Controller
    {
        private EnrollManager enrollManager;
        private CourseManager courseManager;

        public EnrollController()
        {
            enrollManager = new EnrollManager();
            courseManager = new CourseManager();
            
        }


        //
        // GET: /Enroll/
        [HttpGet]
        public ActionResult EnrollCourse()
        {
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            return View();
        }


        public JsonResult GetStudentbyregNo(string regNo)
        {
            Enroll student = enrollManager.GetStudentbyRegNo(regNo);
            return Json(student);

        }
        public JsonResult GetCourseList(string DepartmentCode)
        {
            List<Course> courseslist = enrollManager.GetTotalCourselist(DepartmentCode);
            return Json(courseslist);
        }

        [HttpPost]
        public ActionResult EnrollCourse(Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = enrollManager.EnrollCourse(enroll);
            }
           ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            return View();
        }
	}
}