using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.RepositroyInterface
{
    public interface IJobRepository
    {
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> GetJobByNameAsync(string name);
        Task<IEnumerable<Job>> GetJobsByDepartmentAsync(int departmentId);
        Task<IEnumerable<Job>> GetAllJobsAsync();
    }
}
