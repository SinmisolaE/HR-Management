using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.RepositoryInterface
{
    public interface IEmployeeLeaveRepository
    {
        Task<Employee_leave> GetEmployeeLeaveByIdAsync(int id);
        Task<IEnumerable<Employee_leave>> GetEmployeeLeavesByEmployeeIdAsync(int employee_id);
        Task<Employee_leave> GetEmployeeLeaveByLeaveIdAsync(int leave_id);

        Task<IEnumerable<Employee_leave>> GetAllEmployeeLeavesAsync();

        Task<Employee_leave> AddEmployeeLeaveAsync(Employee_leave entity);
    }
}
