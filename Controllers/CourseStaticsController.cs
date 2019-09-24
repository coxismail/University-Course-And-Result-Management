using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class CourseStaticsController : Controller
    {
        private CourseManager courseManager;
        private DepartmentManager departmentManager;


        public CourseStaticsController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            
        }
        //
        // GET: /CourseStatics/

        [HttpGet]
        public ActionResult CourseStatics()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }


        public JsonResult ViewCourseStatics(string DepartmentCode)

        {

            List<Course> CourseStatics = courseManager.ViewCourseStatics(DepartmentCode);
  

            return Json(CourseStatics);
        }

	}
}