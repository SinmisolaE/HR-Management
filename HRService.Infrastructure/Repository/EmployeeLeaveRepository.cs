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
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly HRDbContext _context;

        public EmployeeLeaveRepository(HRDbContext context) { _context = context; }
        public async Task<IEnumerable<Employee_leave>> GetAllEmployeeLeavesAsync()
        {
            return await _context.Employee_Leaves.ToListAsync();
        }

        public async Task<Employee_leave> GetEmployeeLeaveByIdAsync(int id)
        {
            return await _context.Employee_Leaves.FindAsync(id);
        }

        public async Task<Employee_leave> GetEmployeeLeaveByLeaveIdAsync(int leave_id)
        {
            return await _context.Employee_Leaves.Where(a => a.LeaveId == leave_id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee_leave>> GetEmployeeLeavesByEmployeeIdAsync(int employee_id)
        {
            return await _context.Employee_Leaves.Where(a => a.EmployeeId == employee_id).ToListAsync();
        }

        public async Task<Employee_leave> AddEmployeeLeaveAsync(Employee_leave entity)
        {
            await _context.Employee_Leaves.AddAsync(entity);

            _context.SaveChanges();

            return entity;
        }
    }
}
