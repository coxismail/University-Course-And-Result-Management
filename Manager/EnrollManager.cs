using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class EnrollManager
    {

        private EnrollGateway enrollGateway;

        public EnrollManager()
        {
            enrollGateway = new EnrollGateway();
        }

        public List<Enroll> GetAllRegNo()
        {
            return enrollGateway.GetAllRegNo();
        }

        // Enroll successfull code here
        public string EnrollCourse(Enroll enrull)
        {
            if (enrollGateway.allreadyEnrolled(enrull))
            {
                int rowAffect = enrollGateway.UpdateEnrolledCourse(enrull);
                if (rowAffect>0)
                {
                    return "Enrolled Course Updated Successful";
                }
                else
                {
                    return "Operation Failed";
                }
            }
            else
            {
                int rowAffact = enrollGateway.EnrollCourse(enrull);
                if (rowAffact > 0)
                {
                    return "Course Enrolledment Successful";
                }
                else
                {
                    return "Operation Failed";
                }
            }
        }



        public List<SelectListItem> GetAllRegNoForDropdown()
        {
            List<Enroll> RegNoList = GetAllRegNo();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem() {Value = "", Text = "--Choice--"}
            };
            foreach (Enroll RegNo in RegNoList)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = RegNo.RegNo;
                selectListItem.Text = RegNo.RegNo;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;

        }


        public Enroll GetStudentbyRegNo(string RegNo)
        {
            return enrollGateway.GetStudentbyRegNo(RegNo);
        }


// after selecting studnet reginstration number
        public List<Course> GetTotalCourselist(string departmentCode)
        {
            return enrollGateway.GetTotalCourseistbyStuentDepartmentCode(departmentCode);
        }

    }
}