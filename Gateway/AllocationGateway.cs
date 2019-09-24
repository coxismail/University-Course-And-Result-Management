using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class AllocationGateway : ConnectionGateway
    {

        public int RommAllocation(Allocation allocation)
        {
            Connection.Open();
            string query = "INSERT INTO Allocation(CourseCode, DepartmentCode, RoomNo, Day, StartTime, EndTime, Shedule)VALUES(@courseCode,@departmentCode, @RoomNo,@Day,@startTime,@endTime, 1)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseCode", allocation.CourseCode);
            Command.Parameters.AddWithValue("@departmentCode", allocation.DepartmentCode);
            Command.Parameters.AddWithValue("@RoomNo", allocation.RoomNo);
            Command.Parameters.AddWithValue("@Day", allocation.Day);
            Command.Parameters.AddWithValue("@startTime", allocation.StartTime);
            Command.Parameters.AddWithValue("@endTime", allocation.EndTime);



            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }

        // Allreday Booking check

        public bool isBooked(Allocation allocation)
        {
            Connection.Open();
            // Start Time Between privious limitation
            string query = "SELECT * FROM Allocation WHERE RoomNo = @roomNo AND Day = @day AND CAST(StartTime As Time(0))<= @startTime AND CAST(EndTime As Time(0)) > @startTime AND Shedule=1";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@roomNo", allocation.RoomNo);
            Command.Parameters.AddWithValue("@day", allocation.Day);
            Command.Parameters.AddWithValue("@startTime", allocation.StartTime);
            //Command.Parameters.AddWithValue("@endTime", allocation.EndTime);
            Reader = Command.ExecuteReader();
            bool isBooked = Reader.HasRows;
            Connection.Close();
            return isBooked;
        }
        public bool isBookedEndTime(Allocation allocation)
        {
            Connection.Open();
            // End time is booked for another course
            string query = "SELECT * FROM Allocation WHERE RoomNo = @roomNo AND Day = @day AND CAST(StartTime As Time(0)) > @startTime AND CAST(StartTime As Time(0)) < @endTime AND Shedule=1";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@roomNo", allocation.RoomNo);
            Command.Parameters.AddWithValue("@day", allocation.Day);
            Command.Parameters.AddWithValue("@startTime", allocation.StartTime);
            Command.Parameters.AddWithValue("@endTime", allocation.EndTime);
            Reader = Command.ExecuteReader();
            bool isBooked = Reader.HasRows;
            Connection.Close();
            return isBooked;
        }



        public List<Allocation> listofshedule(string corseCode)
        {
            Connection.Open();
            // Ent time is booked for another course
            string query = "SELECT RoomNo, Day, CAST(StartTime As Time(0)) as StartTime, CAST(EndTime As Time(0)) as EndTime FROM Allocation WHERE CourseCode =@courseCode AND Shedule=1";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("courseCode", corseCode);
            Reader = Command.ExecuteReader();
            List<Allocation> shedules = new List<Allocation>();
            while (Reader.Read())
            {
                Allocation shedule = new Allocation();
                shedule.RoomNo = Convert.ToInt32(Reader["RoomNo"]);
                shedule.Day = Reader["Day"].ToString();
                shedule.StartTime = Reader["StartTime"].ToString();
                shedule.EndTime = Reader["EndTime"].ToString();
                shedules.Add(shedule);
            }


            Connection.Close();
            return shedules;
        }







        // according to department code
        public List<Allocation> listofshedulebyDepartment(string departmentcode)
        {
            Connection.Open();
            // Ent time is booked for another course
            string query = "SELECT CourseCode, dbo.Course.Name, RoomNo, Day, CAST(StartTime As Time(0)) as StartTime, CAST(EndTime As Time(0)) as EndTime FROM Course INNER JOIN Allocation on dbo.Course.Code =dbo.Allocation.CourseCode  WHERE dbo.Allocation.DepartmentCode =@departmentCode AND Shedule=1";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("departmentCode", departmentcode);
            Reader = Command.ExecuteReader();
            List<Allocation> shedules = new List<Allocation>();
            while (Reader.Read())
            {
                Allocation shedule = new Allocation();
                shedule.CourseCode = Reader["CourseCode"].ToString();
                shedule.CourseName = Reader["Name"].ToString();
                shedule.RoomNo = Convert.ToInt32(Reader["RoomNo"]);
                shedule.Day = Reader["Day"].ToString();
                shedule.StartTime = Reader["StartTime"].ToString();
                shedule.EndTime = Reader["EndTime"].ToString();
                shedules.Add(shedule);
            }


            Connection.Close();
            return shedules;
        }




        //from view department code
        public List<Allocation> SheduleFromViw(string departmentcode)
        {
            Connection.Open();
            // Ent time is booked for another course
            //  string query = "SELECT CourseCode, dbo.Course.Name, RoomNo, Day, CAST(StartTime As Time(0)) as StartTime, CAST(EndTime As Time(0)) as EndTime FROM Course INNER JOIN Allocation on dbo.Course.Code =dbo.Allocation.CourseCode  WHERE dbo.Allocation.DepartmentCode =@departmentCode AND Shedule=1";
            string query = "SELECT dbo.Course.Code, dbo.Course.Name, dbo.Allocation.RoomNo, dbo.Allocation.Day, dbo.Allocation.StartTime,dbo.Allocation.EndTime FROM dbo.Course LEFT OUTER JOIN dbo.Allocation ON dbo.Course.Code = dbo.Allocation.CourseCode WHERE (dbo.Course.DepartmentCode = @departmentCode)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("departmentCode", departmentcode);
            Reader = Command.ExecuteReader();
            List<Allocation> shedules = new List<Allocation>();
            while (Reader.Read())
            {
                Allocation shedule = new Allocation();
                shedule.CourseCode = Reader["Code"].ToString();
                shedule.CourseName = Reader["Name"].ToString();
                if (Reader["RoomNo"] == DBNull.Value)
                {
                    shedule.RoomNo = 0;
                }
                else
                {
                    shedule.RoomNo = Convert.ToInt32(Reader["RoomNo"]);
                }

                //shedule.RoomNo = Convert.ToInt32(Reader["RoomNo"]);
                if (Reader["Day"] == DBNull.Value)
                {
                    shedule.Day = "";
                }
                else
                {
                    shedule.Day = Reader["Day"].ToString();
                }


                //shedule.Day = Reader["Day"].ToString();
                if (Reader["StartTime"] == DBNull.Value)
                {
                    shedule.StartTime = "";
                }
                else
                {
                    shedule.StartTime = Reader["StartTime"].ToString();
                }

                //shedule.StartTime = Reader["StartTime"].ToString();
                if (Reader["EndTime"] == DBNull.Value)
                {
                    shedule.EndTime = "";
                }
                else
                {
                    shedule.EndTime = Reader["EndTime"].ToString();
                }
                //shedule.EndTime = Reader["EndTime"].ToString();
                shedules.Add(shedule);

            }

            Connection.Close();
            return shedules;

        }











        // Un Allocate Class Shedule

        public int unAllocateClass()
        {
            Connection.Open();
            string query = "UPDATE Allocation SET Shedule=0 WHERE RoomNo IS NOT NULL";
            Command = new SqlCommand(query, Connection);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }



        public int Bakupdata()
        {
            Connection.Open();
            string query = "INSERT INTO AllocationBackup(DepartmentCode, CourseCode, RoomNo, Day, StartTime, EndTime) SELECT DepartmentCode, CourseCode, RoomNo, Day, StartTime, EndTime FROM Allocation WHERE RoomNo IS NOT NULL";
            Command = new SqlCommand(query, Connection);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }








        public int ResetData()
        {
            Connection.Open();
            string query = "DELETE FROM Allocation WHERE Shedule=0";
            Command = new SqlCommand(query, Connection);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }





        public List<Allocation> unAllocationHistory()
        {
            Connection.Open();
            // Ent time is booked for another course
            string query = "SELECT * FROM AllocationBackup";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Allocation> history = new List<Allocation>();
            while (Reader.Read())
            {
                Allocation shedule = new Allocation();
                shedule.CourseCode = Reader["CourseCode"].ToString();
                shedule.RoomNo = Convert.ToInt32(Reader["RoomNo"]);
                shedule.Day = Reader["Day"].ToString();
                shedule.StartTime = Reader["StartTime"].ToString();
                shedule.EndTime = Reader["EndTime"].ToString();
                history.Add(shedule);
            }


            Connection.Close();
            return history;
        }





    }

}
