using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class CourseController : Controller
    {
        ComponentManager componentManager;
        DepartmentManager departmentManager;
        CourseManager courseManager;
        public CourseController()
        {
            componentManager = new ComponentManager();
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
        }
        //
        // GET: /Course/


        // Saving a course action goese from here
        [HttpGet]
        public ActionResult Course()
        {

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();

            ViewBag.SemesterList = componentManager.GetAllSemesterforDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Course(Course course)
        {
            if (ModelState.IsValid)
            {
                string message = courseManager.SaveCourse(course);
                ViewBag.message = message;
               
                
            }
            else
            {
                ViewBag.message = "Something error has been occured";

            }

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.SemesterList = componentManager.GetAllSemesterforDropdown();
            return View();
        }

        // Exist Check
        public JsonResult isExistCode(Course course)
        {
            bool status = courseManager.isExistCode(course);
            if (status == false)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }


        }
        public JsonResult isExistName(Course course)
        {
            bool status = courseManager.isExistName(course);
            if (status == false)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }


        }

        [HttpGet]
        public ActionResult UnassignCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UnAssignCourse()
        {
            
            ViewBag.message = courseManager.unAssignallCourse();
            return View();
        }

    }
}