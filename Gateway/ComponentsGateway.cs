using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class ComponentsGateway: ConnectionGateway
    {
        public List<Components> GetAllSameesters()
        {
            Connection.Open();
            string query = "SELECT Semeester from Components Where Semeester is NOT Null";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Components> sameesters = new List<Components>();

            while (Reader.Read())
            {
                Components sameester = new Components();
                sameester.Semeester = Reader["Semeester"].ToString();

                sameesters.Add(sameester);
            }

            Connection.Close();

            return sameesters;
        }

// Following code for designatin query
        public List<Components> GetAllDesignation()
        {

            Connection.Open();
            string query = "SELECT Designation from Components Where Designation is NOT Null";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Components> DesignationList = new List<Components>();

            while (Reader.Read())
            {
                Components designation = new Components();
                designation.Designation = Reader["Designation"].ToString();
                DesignationList.Add(designation);
            }

            Connection.Close();

            return DesignationList;

        }




        // Following code for Room NO Query query
        public List<Components> AllRoomNo()
        {

            Connection.Open();
            string query = "SELECT RoomNo FROM Components WHERE RoomNo is NOT Null";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Components> RoomList = new List<Components>();

            while (Reader.Read())
            {
                Components roomNo = new Components();
                roomNo.RoomNo = Reader["RoomNo"].ToString();
                RoomList.Add(roomNo);
            }

            Connection.Close();

            return RoomList;

        }




        // Following code for Day Query 
        public List<Components> AllDays()
        {

            Connection.Open();
            string query = "SELECT Day FROM Components WHERE Day is NOT Null";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Components> DayList = new List<Components>();

            while (Reader.Read())
            {
                Components day = new Components();
                day.Days = Reader["Day"].ToString();
                DayList.Add(day);
            }

            Connection.Close();

            return DayList;

        }

        // Following code for Grade Query 
        public List<Components> AllGrade()
        {

            Connection.Open();
            string query = "SELECT Grade FROM Components WHERE Grade is NOT Null";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Components> Gradlist = new List<Components>();

            while (Reader.Read())
            {
                Components Grade = new Components();
                Grade.Grade = Reader["Grade"].ToString();
                Gradlist.Add(Grade);
            }

            Connection.Close();

            return Gradlist;

        }

    }
}