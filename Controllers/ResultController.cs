using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Rotativa.MVC;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;


namespace UniversityManagementApp.Controllers
{
    public class ResultController : Controller
    {
        private EnrollManager enrollManager;
        private ResultManager resultManager;
        private ComponentManager componentManager;

        public ResultController()
        {
            enrollManager = new EnrollManager();
            resultManager = new ResultManager();
            componentManager = new ComponentManager();
        }
        //
        // GET: /Result/
        public ActionResult SaveStudentResult()
        {
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            ViewBag.Gradelist = componentManager.GetGradeforDropdown();
            return View();
        }
        public JsonResult GetStudentbyregNo(string regNo)
        {
            List<Course> CourseList = resultManager.GetTotalCourseListbyStuentRegNo(regNo);
            return Json(CourseList);

        }
        [HttpPost]
        public ActionResult SaveStudentResult(Enroll enroll)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = resultManager.UpdateEnrolledCourseResult(enroll);
            }
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();
            ViewBag.Gradelist = componentManager.GetGradeforDropdown();
            return View();
        }



        [HttpGet]
        public ActionResult ViewResult()
        {
            ViewBag.RegNo = enrollManager.GetAllRegNoForDropdown();

            return View();
        }
     
        public JsonResult GetStudentResultbyregNo(string regNo)
        {
            List<Enroll> CourseList = resultManager.GetStudentResultbyRegNo(regNo);

            return Json(CourseList);

        }
      

  


    }
}