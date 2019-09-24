using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ResultManager
    {
        private ResultGateway resultGateway;

        public ResultManager()
        {
            resultGateway = new ResultGateway();
        }


        public List<Course> GetTotalCourseListbyStuentRegNo(string RegNO) // just for dropdownlist
        {
            return resultGateway.GetTotalCourseListbyStuentRegNo(RegNO);
        }

        public List<SelectListItem> GetTotalCourseListbyStuentRegNoForDropdown(string RegNo)
        {
            List<Course> courselist = GetTotalCourseListbyStuentRegNo(RegNo);
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem() {Value = "", Text = "--Choice--"}
            };
            foreach (Course CourseList in courselist)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = CourseList.Code;
                selectListItem.Text = CourseList.Name;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;

        }

        public string UpdateEnrolledCourseResult(Enroll enrull)
        {
            int rowAffect = resultGateway.UpdateEnrolledCourseResult(enrull);
            if (rowAffect>0)
            {
                return "Result Save Successful";
            }
            else
            {
                return "Operation Failed try again";
            }
        }



        public List<Enroll> GetStudentResultbyRegNo(string RegNo)
        {
            return resultGateway.GetStudentResultbyRegNo(RegNo);
        }




























    }
}