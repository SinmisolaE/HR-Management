using HRService.Core.Entities;
using HRService.Core.Entity;
using HRService.Core.Interfaces.RepositoryInterface;
using HRService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Repository
{
    //The employee repository for direct db interactions
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRDbContext _context;  //instance for interacting with db
        public EmployeeRepository(HRDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            
            var customer =  await _context.Employees.FindAsync(id);

            if (customer == null)
            {
                return false;
            }

            _context.Employees.Remove(customer);
            _context.SaveChanges();
            return true;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByGrade(string grade)
        {
            return await _context.Employees.Where(a => a.Grade == grade).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByNameAsync(string name)
        {
             return await _context.Employees.Where(a => a.FirstName == name || a.LastName == name).ToListAsync(); 
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            var employee = await _context.Employees
                .Where(a => a.Email == email)
                .Include(e => e.Job)
                .Include(e => e.Department)
                .FirstOrDefaultAsync();

            return employee == null ? throw new Exception("Employee not found!") : employee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var employee1 = await _context.AddAsync(employee);
            if (employee1 != null) { throw new Exception("Employee not added"); }
            _context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Job)
                .Include(e => e.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            return await _context.Employees.Where(a => a.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByJobAsync(int jobId)
        {
            return await _context.Employees.Where(a => a.JobId == jobId).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Employee>> GetEmployeesByGradeAsync(string grade)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
