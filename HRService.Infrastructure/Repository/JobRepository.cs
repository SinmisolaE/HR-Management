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
    public class JobRepository : IJobRepository
    {
        private readonly HRDbContext _context;

        public JobRepository(HRDbContext context) { _context = context; }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task<Job> GetJobByNameAsync(string name)
        {
            return await _context.Jobs.Where(a => a.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Job>> GetJobsByDepartmentAsync(int departmentId)
        {
            return await _context.Jobs.Where(a => a.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _context.Jobs.Include(e => e.Department).ToListAsync();
        }
    }
}
