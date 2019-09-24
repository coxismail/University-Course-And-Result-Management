using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class AllocationController : Controller
    {
        private DepartmentManager departmentManager;
        private CourseManager courseManager;
        private ComponentManager componentManager;
        private AllocationManager allocationManager;
        public AllocationController()
        {
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
            componentManager = new ComponentManager();
            allocationManager = new AllocationManager();
        }
        //
        // GET: /Allocation/


        [HttpGet]
        public ActionResult RoomAllocation()
        {

            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.RoomNo = componentManager.GetAllRoomNoforDropdown();
            ViewBag.Days = componentManager.GetDayforDropdown();
            return View();
        }


        public JsonResult GetCourseList(string departmentCode)
        {
            List<Course> courseslist = courseManager.GetTotalCourselist(departmentCode);
            return Json(courseslist);
        }
        [HttpPost]
        public ActionResult RoomAllocation(Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                ViewBag.messagge = allocationManager.RommAllocation(allocation); 
            }
            else
            {
                ViewBag.messagge = "Model State is not vaild";
            }
            
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            ViewBag.RoomNo = componentManager.GetAllRoomNoforDropdown();
            ViewBag.Days = componentManager.GetDayforDropdown();
            return View();
        }



      
        [HttpGet]

        public ActionResult ViewRoomAllocation()
        {
            ViewBag.Departments = departmentManager.GetAllDepartmentForDropdown();
            return View();
        }

           
        public JsonResult ViewSheduleInfo(string courseCode)
        {
            List<Allocation> listofAllocations = allocationManager.listofshedule(courseCode);
            return Json(listofAllocations);
        }
        public JsonResult ViewSheduleInfobtDepartment(string departmentCode)
        {
            List<Allocation> listofAllocations = allocationManager.listofshedulebyDepartmentcode(departmentCode);
            return Json(listofAllocations);
        }



        //from view
        public JsonResult shedulebyDepartment(string departmentCode)
        {
            List<Allocation> listofAllocations = allocationManager.shedulebyDepartment(departmentCode);
            return Json(listofAllocations);
        }




        [HttpGet]
        public ActionResult UnAllocate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Unallocate()
        {
            ViewBag.message = allocationManager.unAllocateClass();
            return View();
        }


        [HttpGet]
        public ActionResult History()
        {
            ViewBag.history = allocationManager.unAllocationHistory();
            return View();
        }
        [HttpPost]
        public ActionResult history()
        {
            ViewBag.history = allocationManager.unAllocationHistory();
            return View();
        }

    }
}