using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class AssignCourseController : Controller
    {
       
        DepartmentManager departmentManager;
        CourseManager courseManager;
        private TeacherManager teacherManager;
        public AssignCourseController()
        {
    
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            teacherManager = new TeacherManager();
        }
        //
        // GET: /AssignCourse/

        [HttpGet]
        public ActionResult AssignCourse()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

        public JsonResult GetTeacherlist(string departmentCode)
        {
            List<Teacher> teachers = teacherManager.GetTotalTeacherByDepartmentCode(departmentCode);
           
            return Json(teachers);
        }

        public JsonResult GetCourseList(string departmentCode)
        {
            List<Course> courseslist = courseManager.GetTotalCourselist(departmentCode);
            return Json(courseslist);
        }

        public JsonResult GetTeacherCredit(string teacherId)
        {
            Teacher teacher = teacherManager.GetTeacherbyTeacherID(teacherId);
            return Json(teacher);

        }

        public JsonResult GetTakenCredit(string TeacherId)
        {
            Course TakenCourseCredit = courseManager.GetTaeknCredit(TeacherId);
            return Json(TakenCourseCredit);
        }

        // display couse name and credt
        public JsonResult GetCourseNameAndCredit(string courseCode)
        {
            Course courseslist = courseManager.GetCoursebyCourseCode(courseCode);
            return Json(courseslist);
        }
        // Exist Check
        public JsonResult isAlreadyAssigned(AssignCourse course)
        {
            bool status = courseManager.isAlreadyAssigned(course);
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
        public ActionResult AssignCourse(AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = courseManager.AssignToTeacher(assignCourse);
            }
            
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }




    }
}