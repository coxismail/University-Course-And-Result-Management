using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;
        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string SaveTeacher(Teacher teacher)
        {

            int rowAffact = teacherGateway.SaveTeacher(teacher);
            if (rowAffact > 0)
            {
                return "Save Teacher Successful";
            }
            else
            {
                return "Somethin went Wrong, Try again later";
            }



        }

        public bool isExistMail(Teacher teacher)
        {
            return teacherGateway.isExistMail(teacher);
        }


        public bool isExistNumber(Teacher teacher)
        {
            return teacherGateway.isExistNumber(teacher);
        }


        // 
        public List<Teacher> GetTotalTeacherByDepartmentCode(string departmentcode)
        {

            return teacherGateway.GetTotalTeacherlist(departmentcode);
        }
        // Teacher query according to Teacher id
        public Teacher GetTeacherbyTeacherID(string Teacherid) // just for dropdownlist
        {
            return teacherGateway.GetTeacherbyTeacherID(Teacherid);

        }

        // just for dropdown
        public List<SelectListItem> GetTeacherByDepartmentCodeForDropdown(string departmentcode)
        {
            List<Teacher> teachers = GetTotalTeacherByDepartmentCode(departmentcode);
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem() {Value = "", Text = "--Choice--"}
            };
            foreach (Teacher teacher in teachers)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = teacher.Id.ToString();
                selectListItem.Text = teacher.Name;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;

        }





    }
}