using HRService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRService.Core.Interfaces.RepositoryInterface
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<Department>> GetDepartmentListAsync();
        Task<Department> GetDepartmentByNameAsync(string name);

        Task<Department> AddDepartmentAsync(Department department);

        Task<bool> DeleteDepartmentAsync(Department department);
    }
}