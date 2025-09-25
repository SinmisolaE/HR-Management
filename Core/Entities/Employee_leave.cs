using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Entities
{
    public enum Status
    {
        Approved, Pending, Rejected
    }
    public class Employee_leave
    {

        

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveId {  get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public int NumDays { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Employee_leave(int employeeId, int leaveId, DateOnly startDate, DateOnly endDate, int numDays)
        {
            EmployeeId = employeeId;
            LeaveId = leaveId;
            StartDate = startDate;
            EndDate = endDate;
            NumDays = numDays;
        }
    }
}
