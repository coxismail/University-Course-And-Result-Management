using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private DepartmentManager departmentManager;
        private StudentManager studentManager;
       

        public StudentController() 
        {
            departmentManager = new DepartmentManager();
            studentManager = new StudentManager();
        }
        //
        // GET: /Student/
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
   
            return View();
        }

        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
           ViewBag.message = studentManager.RegisterStudent(student);
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            Student registredStudent = studentManager.registerdStudent(student);
            ViewBag.Data = registredStudent;
            return View();
        }



        [HttpPost]
        public JsonResult isExistMail(Student student)
        {
            bool status = studentManager.isExistMail(student);
            if (status == false)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }


        [HttpPost]
        public JsonResult isExistNumber(Student student)
        {
            bool status =studentManager.isExistNumber(student);
            if (status == false)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
	}
}