using HRService.Core.DTO;
using HRService.Core.Entity;
using HRService.Core.Interfaces.RepositoryInterface;
using HRService.Core.Interfaces.RepositroyInterface;
using HRService.Core.Interfaces.ServiceInterface;
using HRService.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IJobRepository _jobRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository, IJobRepository jobRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _jobRepository = jobRepository;
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            var job = await _jobRepository.GetJobByNameAsync(employeeDTO.JobName);
            if (job == null) { throw new Exception("Job not found"); }

            var dept = await _departmentRepository.GetDepartmentByNameAsync(employeeDTO.DeptName);
            if (dept == null) { throw new Exception("Department not found"); }

            if (job.DepartmentId != dept.Id) { throw new Exception("Job does not match Department"); }


            var employee = new Employee(
                employeeDTO.FirstName, employeeDTO.LastName, employeeDTO.Email,
                employeeDTO.DOB, employeeDTO.Address, job.Id, job.DepartmentId, employeeDTO.Grade, employeeDTO.Salary
            );
            return await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(DepartmentDTO departmentDTO)
        {
            var dept = await _departmentRepository.GetDepartmentByNameAsync(departmentDTO.Name);
            if (dept == null)
            {
                throw new Exception("Department not found");
            }
            return await _employeeRepository.GetEmployeesByDepartmentAsync(dept.Id);
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            return await _employeeRepository.GetEmployeeByEmailAsync(email);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string name)
        {
            return await _employeeRepository.GetEmployeesByNameAsync(name);
        }

        public async Task<Employee> GetEmployeeByJobAsync(int jobId)
        {
            var job = await _jobRepository.GetJobByIdAsync(jobId);
            if (job == null)
            {
                throw new Exception("Job doesn't exists");
            }

            return await _employeeRepository.GetEmployeeByJobAsync(jobId);
        }

        public async Task<Employee> TerminateEmployeeByIdAsync(string email)
        {
            var employee = await GetEmployeeByEmailAsync(email);

            if (employee == null) { throw new Exception("Employee not found"); }

            employee.Status = EmpStatus.InActive;

            await _employeeRepository.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployeeSalaryAsync(EmployeeSalaryDTO employeeDTO)
        {
            var employee = await GetEmployeeByEmailAsync(employeeDTO.Email);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.Salary = employeeDTO.Salary;
            await _employeeRepository.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeJobAsync(EmployeeJobDTO employeeJobDTO)
        {
            var employee = await GetEmployeeByEmailAsync(employeeJobDTO.Email);
            if (employee == null) { throw new Exception("Employee not found!"); }

            var job = await _jobRepository.GetJobByNameAsync(employeeJobDTO.JobName);

            if (job == null) { throw new Exception("Job post not found"); }

            employee.JobId = job.Id;
            await _employeeRepository.SaveChangesAsync();

            return employee;
        }
    }
}
