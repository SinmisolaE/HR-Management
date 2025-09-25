using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Interfaces
{
    public interface IEmployeeLeaveService
    {
        Task<Employee_leave> GetEmployeeLeaveById(int id);
        Task<IEnumerable<Employee_leave>> GetAllLeavesForEmployee(int employeeId);


        
    }
}
