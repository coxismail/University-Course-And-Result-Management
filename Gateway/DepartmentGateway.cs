using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class DepartmentGateway:ConnectionGateway
    {
        public int SaveDepartment(Department department)
        {
            Connection.Open();
            string query = "INSERT INTO Department(Code, Name) VALUES(@code, @name)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffect;
        }
   

        public List<Department> GetAllDepartment()
        {
            Connection.Open();
            string query = "select * from Department";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (Reader.Read())
            {
                Department department = new Department();
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();

                departments.Add(department);
            }

            Connection.Close();

            return departments;
        }

        public bool isExistDepartmentCode(Department department)
        {
            Connection.Open();

            string query = "select * from Department where Code = @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Connection.Close();
            return isExist;
        }

        public bool isExistDepartmentName(Department department)
        {
            Connection.Open();

            string query = "select * from Department WHERE Name = @name";
            
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", department.Name);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
    }
}