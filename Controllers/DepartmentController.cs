using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
      DepartmentManager departmentManager;

      public DepartmentController() 
        {
            departmentManager = new DepartmentManager();
        }
        

        //
        // GET: /Department/
       [HttpGet]
        public ActionResult Department()
        {
            return View();
        }



        [HttpPost]
       public ActionResult Department(Department department)
       {
            if (ModelState.IsValid)
            {
                string message = departmentManager.SaveDepartment(department);
                ViewBag.message = message;
            }
            else
            {
                return View();
            }
    
           return View();
       }

        [HttpGet]
        public ActionResult AllDepartments(Department department)
        {

            List<Department> AllDepartments = departmentManager.GetAllDepartment();
            ViewBag.Alldepartments = AllDepartments;
            return View();
        }



        // Exist check
        [HttpPost]
        public JsonResult isExistCode(Department department)
        {
            bool status = departmentManager.isExistCode(department);
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
        public JsonResult isExistName(Department department)
        {
            bool status = departmentManager.isExistName(department);
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