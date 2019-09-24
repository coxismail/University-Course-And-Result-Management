using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway = new DepartmentGateway();
        }

        public string SaveDepartment(Department department)
        {
           
                int rowAffact = departmentGateway.SaveDepartment(department);
                if (rowAffact>0)
                {
                    return "Department Save Successful";
                }
                else
                {
                    return "Department Not Saved";
                }
            
           
        }

        // exist data
        public bool isExistCode(Department department)
        {
            return departmentGateway.isExistDepartmentCode(department);
        }

        public bool isExistName(Department department)
        {
            return departmentGateway.isExistDepartmentName(department);
        }



        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }





        public List<SelectListItem> GetAllDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartment();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem() {Value = "", Text = "--Choice--"}
            };
            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();

                selectListItem.Value = department.Code;
                selectListItem.Text = department.Name;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;

        }




    }
}