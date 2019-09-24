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
    public class ComponentManager
    {
        ComponentsGateway componentsGateway;
      

        public ComponentManager()
        {
            componentsGateway= new ComponentsGateway();
        }
        public List<Components> GetAllSameesters()
        {
            return componentsGateway.GetAllSameesters();
        }

        public List<Components> GetAllDesignation()
        {
            return componentsGateway.GetAllDesignation();
        }
        public List<Components> GetAllRoomNo()
        {
            return componentsGateway.AllRoomNo();
        }
        public List<Components> GetDays()
        {
            return componentsGateway.AllDays();
        }
        public List<Components> GetGrade()
        {
            return componentsGateway.AllGrade();
        }

// list for dropdown



        public List<SelectListItem> GetAllSemesterforDropdown()
        {
            List<Components> Semesters = GetAllSameesters();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Choice--", Value = ""}
            };
            foreach (Components semester in Semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Semeester;
                selectListItem.Value = semester.Semeester;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }









        // for designation
        public List<SelectListItem> GetAllDesignationforDropdown()
        {
            List<Components> Designation = GetAllDesignation();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Choice--", Value = ""}
            };
            foreach (Components designation in Designation)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Designation;
                selectListItem.Value = designation.Designation;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }

        // for Room NO
        public List<SelectListItem> GetAllRoomNoforDropdown()
        {
            List<Components> Roomlist = GetAllRoomNo();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Choice--", Value = ""}
            };
            foreach (Components roomlist in Roomlist)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = roomlist.RoomNo;
                selectListItem.Value = roomlist.RoomNo;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }


        // for Day
        public List<SelectListItem> GetDayforDropdown()
        {
            List<Components> daylist = GetDays();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Day--", Value = ""}
            };
            foreach (Components Daylist in daylist)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = Daylist.Days;
                selectListItem.Value = Daylist.Days;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }


        // for Grade 
        public List<SelectListItem> GetGradeforDropdown()
        {
            List<Components> gradeListItem = GetGrade();
            List<SelectListItem> selectListItemList = new List<SelectListItem>
            {
                new SelectListItem(){ Text = "--Select Grade--", Value = ""}
            };
            foreach (Components gradeList in gradeListItem)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = gradeList.Grade;
                selectListItem.Value = gradeList.Grade;
                selectListItemList.Add(selectListItem);
            }
            return selectListItemList;
        }
    }
}