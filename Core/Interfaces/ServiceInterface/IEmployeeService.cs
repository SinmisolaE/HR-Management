using HR_Management.Models.DTO;
using HRService.Core.DTO;
using HRService.Core.Entity;
using HRService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string name);

        Task<Employee> GetEmployeeByJobAsync(int jobId);

        Task<Employee> GetEmployeeByEmailAsync(string email);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(DepartmentDTO departmentDTO);
        Task<Employee> TerminateEmployeeByIdAsync(string email);

        Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDTO);

        //Task<Employee> UpdateEmployeeSalaryAsync(EmployeeSalaryDTO employeeDTO);
        //Task<Employee> UpdateEmployeeJobAsync(EmployeeJobDTO employeeJobDTO);
    }
}
