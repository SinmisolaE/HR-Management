using HRService.Core.Entities;
using HRService.Core.Interfaces.RepositoryInterface;
using HRService.Core.Interfaces.RepositroyInterface;
using HRService.Infrastructure.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Services
{
    public class LeaveService : ILeaveService, IEmployeeLeaveService
    {
        private readonly IEmployeeLeaveRepository _employeeLeaveRepository;
        private readonly ILeaveRepository _leaveRepository;
        private IEmployeeService _employeeService;

        public LeaveService(IEmployeeLeaveRepository employeeLeaveRepository, ILeaveRepository leaveRepository, IEmployeeService employeeService)
        {
            _employeeLeaveRepository = employeeLeaveRepository;
            _leaveRepository = leaveRepository;
            _employeeService = employeeService;
            
        }
        public async Task<Leave> AddLeave(LeaveDTO leaveDTO)
        {
            var get_leave = await _leaveRepository.GetLeavesByLeaveTypeAsync(leaveDTO.LeaveType);

            if (get_leave == null)
            {
                throw new Exception("Leave type not found");
            }

            var employee = await _employeeService.GetEmployeeByEmailAsync(leaveDTO.EmployeeEmail);

            if (employee == null)
            {
                throw new Exception("Employee not found!");
            }

            var demo_emp_leave = new Employee_leave(employee.Id, get_leave.Id, leaveDTO.StartDate, leaveDTO.EndDate, leaveDTO.NumDays);

            var employee_leave = await _employeeLeaveRepository.AddEmployeeLeaveAsync(demo_emp_leave);

            return get_leave;
        }

        public async Task<IEnumerable<Leave>> GetAllLeaves()
        {
            return await _leaveRepository.GetAllLeavesAsync();
        }

        public async Task<IEnumerable<Employee_leave>> GetAllLeavesForEmployee(int employeeId)
        {
            return await _employeeLeaveRepository.GetEmployeeLeavesByEmployeeIdAsync(employeeId);
        }

        public async Task<Employee_leave> GetEmployeeLeaveById(int id)
        {
            return await _employeeLeaveRepository.GetEmployeeLeaveByLeaveIdAsync(id);
        }

        public async Task<Leave> GetLeaveById(int leaveId)
        {
            return await _leaveRepository.GetLeaveByIdAsync(leaveId);
        }
    }
}
