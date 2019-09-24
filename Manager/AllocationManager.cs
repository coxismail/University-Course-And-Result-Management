using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class AllocationManager
    {

        private AllocationGateway allocationGateway;

        public AllocationManager()
        {
            allocationGateway = new AllocationGateway();
        }







        public string RommAllocation(Allocation allocation)
        {
            if (allocationGateway.isBooked(allocation))
            {
                return "You can not start from here";
            }
            else if (allocationGateway.isBookedEndTime(allocation))
            {
                return "Endtime is booked for another course";
            }
            //else if (allocationGateway.isBookedEndTime(allocation))
            //{
            //    return "End Time is booked for another course";
            //}
            else
            {
                int rowAffect = allocationGateway.RommAllocation(allocation);
                if (rowAffect > 0)
                {
                    return "Course Allocation Successfull";
                }
                else
                {
                    return "Failed to Allocation";
                }
            }

           
        }



        // remote Time validation
        //public bool isBooked(Allocation allocation)
        //{
        //    return allocationGateway.isBooked(allocation);
        //}


        public List<Allocation> listofshedule(string corseCode)
        {
            return allocationGateway.listofshedule(corseCode);
        }
        public List<Allocation> listofshedulebyDepartmentcode(string departmentcode)
        {
            return allocationGateway.listofshedulebyDepartment(departmentcode);
        }
        //from view
        public List<Allocation> shedulebyDepartment(string departmentcode)
        {
            return allocationGateway.SheduleFromViw(departmentcode);
        }









// Un Allocation 
        public string unAllocateClass()
        {
            int rowAffact = allocationGateway.unAllocateClass();
            if (rowAffact>0)
            {
               int backup = allocationGateway.Bakupdata();
                int reset = allocationGateway.ResetData();
                if (backup>0 || reset>0  )
                {
                    return "Class Shedule Un Allocated Successful";
                }
                else
                {
                    return "Any Kind of Mistake Has been occurd, Fix it";
                }
            }
            else
            {
                return "Allready Un Allocated or Not Allocate Yet";
            }
        }


// un Allocation History
        public List<Allocation> unAllocationHistory()
        {
           return allocationGateway.unAllocationHistory();
        }



    }
}