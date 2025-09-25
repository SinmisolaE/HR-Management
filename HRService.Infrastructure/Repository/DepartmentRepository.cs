using HRService.Core.Entities;
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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HRDbContext _context;

        public DepartmentRepository(HRDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> GetDepartmentByNameAsync(string name)
        {
            return await _context.Departments.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartmentListAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<bool> DeleteDepartmentAsync(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
