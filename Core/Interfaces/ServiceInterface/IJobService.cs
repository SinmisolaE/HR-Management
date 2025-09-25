using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Infrastructure.Interfaces
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<Job> GetJobByNameAsync(string name);
        Task<IEnumerable<Job>> GetJobsByDepartmentIdAsync(int departmentId);

        Task<string> GetJobNameByIdAsync(int id);
    }
}
