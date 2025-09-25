using HRService.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.RepositoryInterface
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name);

        Task<Employee> GetEmployeeByEmailAsync(string email);
        Task<IEnumerable<Employee>> GetEmployeesByGradeAsync(string grade);

        Task<bool> DeleteEmployeeAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
        Task<Employee> GetEmployeeByJobAsync(int jobId);
        Task SaveChangesAsync();

    }
}
