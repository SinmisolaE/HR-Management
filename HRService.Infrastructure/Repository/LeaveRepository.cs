using HRService.Core.Entities;
using HRService.Core.Interfaces.RepositroyInterface;
using HRService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly HRDbContext _context;

        public LeaveRepository(HRDbContext context)
        {
            _context = context;
        }

        public async Task<Leave> GetLeaveByIdAsync(int id)
        {
            return await _context.Leaves.FindAsync(id);
        }

        public async Task<IEnumerable<Leave>> GetAllLeavesAsync()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<Leave> GetLeavesByLeaveTypeAsync(string leaveType)
        {
            return await _context.Leaves.Where(a => a.LeaveType == leaveType).FirstOrDefaultAsync();
        }
    }
}
