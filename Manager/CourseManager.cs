using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway = new CourseGateway();
        }
        public string SaveCourse(Course course)
        {
            int rowAffact = courseGateway.SaveCourse(course);
            if (rowAffact > 0)
            {
                return "Course Save Successful";
            }
            else
            {
                return "Does not saved";
            }


        }
        // Assign course
        public string AssignToTeacher(AssignCourse course)
        {
            int rowAffact = courseGateway.AssignToTeacher(course);
            if (rowAffact > 0)
            {
                return "Course Assign Successful";
            }
            else
            {
                return "Something Went Wrong";
            } 
        }


        //isAlready Assigned
        public bool isAlreadyAssigned(AssignCourse course)
        {
            return courseGateway.isAlreadyAssigned(course);
        }

        // Availabilty check
        public bool isExistCode(Course course)
        {
            return courseGateway.isExistCode(course);
        }
        public bool isExistName(Course course)
        {
            return courseGateway.isExistName(course);
        }


        // View Statics
        public List<Course> ViewCourseStatics(string departmentCode)
        {
            return courseGateway.ViewCourseStatics(departmentCode);
        }



        // Course Query according to deparment code
        public List<Course> GetTotalCourselist(string departmentCode)
        {
            return courseGateway.GetTotalCourseistbyDepartment(departmentCode);
        }




        // Binding for dropdown
        public List<SelectListItem> GetCouseListForDropDown(string departmentCode)
        {
            List<Course> courselist = GetTotalCourselist(departmentCode);
            List<SelectListItem> selectlist = new List<SelectListItem>();
            {
                new SelectListItem() { Value = "", Text = "--Choice--" };
            }

            foreach (Course course in courselist)
            {
                SelectListItem selectListItems = new SelectListItem();
                selectListItems.Value = course.Code;
                selectListItems.Text = course.Name;
                selectlist.Add(selectListItems);
            }
            return selectlist;
        }



        // Course Query according to course id



        public Course GetCoursebyCourseCode(string CourseID)
        {
            return courseGateway.GetCoursebyCourseCode(CourseID);
        }

        // Taken Query Search
        public Course GetTaeknCredit(string teacherId)
        {
            return courseGateway.GetTaeknCredit(teacherId);
        }




       // Un Assign All course
        public string unAssignallCourse()
        {
            int rowAffect = courseGateway.unAssignallCourse();
            if (rowAffect == 0)
            {
                return "You Allready Unassigned or Not Assignd Yet";
            }
            else if (rowAffect > 0)
            {
                return "Course Unassign Successful";
            }

            return "Something Went Wrong";
        }

    }
}