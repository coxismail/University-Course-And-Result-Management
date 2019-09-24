using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherManager teacherManager;
         ComponentManager componentManager;
        DepartmentManager departmentManager;
       

        public TeacherController()
        {
            componentManager = new ComponentManager();
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
          
           
        }






        //
        // GET: /Teacher/

        [HttpGet]
        public ActionResult Teacher()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();

            ViewBag.AllDesignations = componentManager.GetAllDesignationforDropdown();
            return View();
        }
        [HttpPost]
        public ActionResult Teacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                string message = teacherManager.SaveTeacher(teacher);
                ViewBag.message = message;
                
            }
            else
            {
                ViewBag.message = "Try Again Something occured wrong";
            }
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();

            ViewBag.AllDesignations = componentManager.GetAllDesignationforDropdown();
            return View();
           

        }


        [HttpPost]
        public JsonResult isExistMail(Teacher teacher)
        {
           bool status =teacherManager.isExistMail(teacher);
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
        public JsonResult isExistNumber(Teacher teacher)
        {
            bool status = teacherManager.isExistNumber(teacher);
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